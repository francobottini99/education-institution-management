using Capa.Negocio.DTO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles.Formularios_Auxiliares.Importar
{
    public abstract class Import : ITypeImport
    {
        private static readonly List<char> Letters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ' };

        protected readonly CancellationTokenSource stopSource = new CancellationTokenSource();
        protected CancellationToken stopToken;
        protected SynchronizationContext uiContext;

        protected Task workTask;
        protected IDDVSDataGrid dgv;       

        public event EventHandler<int> BeforeImport;
        public event EventHandler<int> ProgressChangedImport;
        public event EventHandler<IEnumerable<IDTO>> AfterImport;

        public event EventHandler<int> BeforeSave;
        public event EventHandler<int> ProgressChangedSave;
        public event EventHandler<IEnumerable<IDTO>> AfterSave;

        public abstract void Importar(string filePath, ref IDDVSDataGrid dgv);
        public abstract void Guardar(IEnumerable<IDTO> data, ref IDDVSDataGrid dgv);
        public abstract string MensajeDeAyuda();
        protected abstract bool IsValidColumns(DataColumnCollection columns);

        protected void OnBeforeImport(int rows)
        {
            BeforeImport?.Invoke(null, rows);
        }

        protected void OnProgressChangedImport(int progress)
        {
            ProgressChangedImport?.Invoke(null, progress);
        }

        protected void OnAfterImport(IEnumerable<IDTO> result)
        {
            AfterImport?.Invoke(null, result);
        }

        protected void OnBeforeSave(int items)
        {
            BeforeSave?.Invoke(null, items);
        }

        protected void OnProgressChangedSave(int progress)
        {
            ProgressChangedSave?.Invoke(null, progress);
        }

        protected void OnAfterSave(IEnumerable<IDTO> result)
        {
            AfterSave?.Invoke(null, result);
        }

        public void Stop()
        {
            stopSource?.Cancel();
            Wait();
        }

        public void Wait()
        {
            workTask?.Wait();
        }

        protected void SetDefaultColumnsAutoSizeMode()
        {
            dgv.DefaultAutoSizeColumnMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgv.Columns["Button"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgv.Columns["Button"].Width = 40;
        }

        protected void AddButtonAndImageColumns()
        {
            this.dgv.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "Button",
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                }
            });

            this.dgv.Columns.Add(new DataGridViewImageColumn()
            {
                Name = "Imagen",
                HeaderText = "VALIDO",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Padding = new Padding(4),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            this.dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Valid",
                HeaderText = "",
                Visible = false
            });
        }

        protected void AddColumns(PropertyInfo[] colection)
        {
            foreach (PropertyInfo property in colection)
            {
                if (!typeof(IDTO).IsAssignableFrom(property.PropertyType) && !property.PropertyType.IsAbstract)
                {
                    if (!dgv.Columns.Contains(property.Name) && property.Name != "ID")
                    {
                        dgv.Columns.Add(property.Name, property.Name.ToUpper());
                        dgv.Columns[dgv.Columns.Count - 1].ValueType = property.GetType();
                    }
                }
            }
        }

        protected DataTable ReadExcelTable(string filePath, string sheetName)
        {
            DataTable dataTable = new DataTable();

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(stream, false))
                {
                    WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                    IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                    string relationshipId = sheets.FirstOrDefault(s => s.Name == sheetName)?.Id.Value;

                    if (relationshipId == null)
                        throw new Exception("No se encontró la hoja \"" + sheetName + "\"");

                    WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                    Worksheet workSheet = worksheetPart.Worksheet;
                    SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                    IEnumerable<Row> rows = sheetData.Descendants<Row>();
                    int columnCount = rows.ElementAt(0).Count();

                    foreach (Cell cell in rows.ElementAt(0))
                        dataTable.Columns.Add(GetCellValue(spreadSheetDocument, cell));

                    if (!IsValidColumns(dataTable.Columns))
                        throw new Exception("Las columnas de la tabla no se corresponden con el formato aceptado");

                    foreach (Row row in rows.Skip(1))
                    {
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                        {
                            Cell cell = row.Descendants<Cell>().ElementAt(i);
                            int columnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));

                            dataRow[columnIndex] = GetCellValue(spreadSheetDocument, cell);
                        }

                        dataTable.Rows.Add(dataRow);
                    }
                }
            }

            return dataTable;
        }

        protected bool IsValidColumns<DTO>(DataColumnCollection columns) where DTO : IDTO
        {
            foreach (PropertyInfo property in typeof(DTO).GetProperties())
                if (property.Name != "ID" && property.Name != "FechaAlta" && !typeof(IDTO).IsAssignableFrom(property.PropertyType))
                    if (!columns.Contains(property.Name))
                        return false;

            return true;
        }

        protected void SetPropertyValue(IDTO element, PropertyInfo property, string value)
        {
            if (value != null)
            {
                Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                if (!typeof(IDTO).IsAssignableFrom(t))
                {
                    if (t.Name == "DateTime")
                    {
                        if (int.TryParse(value, out _))
                        {
                            value = new DateTime(1899, 12, 30).AddDays(int.Parse(value)).ToString("dd/MM/yyyy");

                            property.SetValue(element, Convert.ChangeType(value, t));
                        }
                    }
                    else
                        property.SetValue(element, Convert.ChangeType(value, t));
                }
            }
        }

        private string GetCellValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.CellValue.InnerText;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;

            return value;
        }

        private string GetColumnName(string cellReference)
        {
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);

            return match.Value;
        }

        private int? GetColumnIndexFromName(string columnName)
        {
            int? columnIndex = null;

            string[] colLetters = Regex.Split(columnName, "([A-Z]+)");

            colLetters = colLetters.Where(s => !string.IsNullOrEmpty(s)).ToArray();

            if (colLetters.Count() <= 2)
            {
                int index = 0;
                foreach (string col in colLetters)
                {
                    List<char> col1 = colLetters.ElementAt(index).ToCharArray().ToList();
                    int? indexValue = Letters.IndexOf(col1.ElementAt(index));

                    if (indexValue != -1)
                    {
                        if (index == 0 && colLetters.Count() == 2)
                            columnIndex = columnIndex == null ? (indexValue + 1) * 26 : columnIndex + ((indexValue + 1) * 26);
                        else
                            columnIndex = columnIndex == null ? indexValue : columnIndex + indexValue;
                    }

                    index++;
                }
            }

            return columnIndex;
        }
    }
}
