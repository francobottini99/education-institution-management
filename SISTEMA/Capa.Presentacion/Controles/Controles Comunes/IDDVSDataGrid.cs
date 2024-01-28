using Capa.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles
{
    public class IDDVSDataGrid : DataGridView
    {
        private DataGridViewAutoSizeColumnsMode defaultAutoSizeColumnMode = DataGridViewAutoSizeColumnsMode.Fill;

        public DataGridViewAutoSizeColumnsMode DefaultAutoSizeColumnMode { get => defaultAutoSizeColumnMode; set => defaultAutoSizeColumnMode = value; }

        public IDDVSDataGrid()
        {
            var DataGridViewCellStyle1 = new DataGridViewCellStyle();
            var DataGridViewCellStyle2 = new DataGridViewCellStyle();
            var DataGridViewCellStyle3 = new DataGridViewCellStyle();
            var DataGridViewCellStyle4 = new DataGridViewCellStyle();

            SuspendLayout();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            EnableHeadersVisualStyles = false;

            BorderStyle = BorderStyle.None;

            CellBorderStyle = DataGridViewCellBorderStyle.None;

            BackgroundColor = Color.FromArgb(33, 35, 38);

            SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            RowTemplate.Height = 25;

            TabStop = false;

            GridColor = Color.DimGray;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToOrderColumns = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;

            ReadOnly = true;

            MultiSelect = false;

            DataGridViewCellStyle1.BackColor = Color.FromArgb(35, 45, 60);
            DataGridViewCellStyle1.ForeColor = Color.White;
            DataGridViewCellStyle1.Font = new Font("Calibri", 12.0f);
            DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 120, 214);
            DataGridViewCellStyle1.SelectionForeColor = Color.White;
            DataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;

            AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1;

            DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewCellStyle2.BackColor = Color.FromArgb(33, 35, 38);
            DataGridViewCellStyle2.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
            DataGridViewCellStyle2.ForeColor = Color.White;
            DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(33, 35, 38);
            DataGridViewCellStyle2.SelectionForeColor = Color.White;
            DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;

            ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2;

            DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle3.BackColor = Color.FromArgb(33, 35, 38);
            DataGridViewCellStyle3.Font = new Font("Calibri", 12.0f);
            DataGridViewCellStyle3.ForeColor = Color.White;
            DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 120, 214);
            DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(33, 35, 38);
            DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;

            RowHeadersDefaultCellStyle = DataGridViewCellStyle3;

            DataGridViewCellStyle4.BackColor = Color.FromArgb(33, 35, 38);
            DataGridViewCellStyle4.ForeColor = Color.White;
            DataGridViewCellStyle4.Font = new Font("Calibri", 12.0f);
            DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 120, 214);
            DataGridViewCellStyle4.SelectionForeColor = Color.White;
            DataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;

            RowsDefaultCellStyle = DataGridViewCellStyle4;

            ColumnHeadersHeight = 30;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            RowHeadersWidth = 20;
            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            ResumeLayout();
        }

        private void DgvHeader()
        {
            if (Rows.Count == 0)
            {
                ColumnHeadersVisible = false;
                DefaultAutoSizeColumnMode = AutoSizeColumnsMode;
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
        {
            base.OnRowsRemoved(e);
            DgvHeader();
        }

        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);

            ColumnHeadersVisible = true;
            AutoSizeColumnsMode = DefaultAutoSizeColumnMode;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left)
            {
                if (object.ReferenceEquals(HitTest(e.X, e.Y), HitTestInfo.Nowhere))
                {
                    ClearSelection();
                    CurrentCell = null;
                }
            }
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);

            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;

            DgvHeader();
        }

        public void AddRowsColumnsData<T>(List<T> listado)
        {
            Rows.Clear();
            Columns.Clear();

            GenerateColumns(typeof(T).GetProperties(), typeof(T).Name);

            foreach (T Item in listado)
            {
                Rows.Add();

                foreach (PropertyInfo property in typeof(T).GetProperties())
                    if (Columns.Contains(property.Name))
                        Rows[Rows.Count - 1].Cells[property.Name].Value = property.GetValue(Item);
            }

            ClearSelection();
            CurrentCell = null;
        }

        public void ConcatColumnsData<T>(List<T> listado)
        {
            if (Rows.Count > 0)
            {
                if (Rows.Count >= listado.Count)
                {
                    GenerateColumns(typeof(T).GetProperties(), typeof(T).Name);

                    for (int i = 0, loopTo = listado.Count - 1; i <= loopTo; i++)
                        foreach (PropertyInfo property in typeof(T).GetProperties())
                            if (Columns.Contains(property.Name))
                                Rows[i].Cells[property.Name].Value = property.GetValue(listado[i]);

                    ClearSelection();
                    CurrentCell = null;
                }
                else
                {
                    throw new Exception("El numero de filas en el control " + Name + " no coincide con el numero de filas del listado dado");
                }
            }
            else
            {
                throw new Exception("El control " + Name + " se encuentra vacio, no es posible concatenarle informacion");
            }
        }

        private void GenerateColumns(PropertyInfo[] colection, string className)
        {
            foreach (PropertyInfo property in colection)
            {
                if (!typeof(IDTO).IsAssignableFrom(property.PropertyType) && !property.PropertyType.IsAbstract)
                {
                    if (!Columns.Contains(property.Name))
                    {
                        Columns.Add(property.Name, property.Name.ToUpper());
                        Columns[Columns.Count - 1].ValueType = property.GetType();

                        if (Columns[Columns.Count - 1].Name == "Eliminado" || Columns[Columns.Count - 1].Name == "Id" + className)
                            Columns[Columns.Count - 1].Visible = false;
                    }
                }
            }
        }
    }

    public delegate void CheckBoxClickedHandler(int columnIndex, bool state);
    public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
    {
        bool _bChecked;
        public DataGridViewCheckBoxHeaderCellEventArgs(int columnIndex, bool bChecked)
        {
            _bChecked = bChecked;
        }
        public bool Checked
        {
            get { return _bChecked; }
        }
    }
    class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState = System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;

        public bool Checked { get => _checked; set { _checked = value; this.DataGridView.InvalidateCell(this); } }

        public event CheckBoxClickedHandler OnCheckBoxClicked;

        public DatagridViewCheckBoxHeaderCell()
        {
        }

        protected override void Paint(System.Drawing.Graphics graphics,
        System.Drawing.Rectangle clipBounds,
        System.Drawing.Rectangle cellBounds,
        int rowIndex,
        DataGridViewElementStates dataGridViewElementState,
        object value,
        object formattedValue,
        string errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
            dataGridViewElementState, value,
            formattedValue, errorText, cellStyle,
            advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics,
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X +
            (cellBounds.Width / 2) - (s.Width / 2);
            p.Y = cellBounds.Location.Y +
            (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (Checked)
                _cbState = System.Windows.Forms.VisualStyles.
                CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
            (graphics, checkBoxLocation, _cbState);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <=
            checkBoxLocation.X + checkBoxSize.Width
            && p.Y >= checkBoxLocation.Y && p.Y <=
            checkBoxLocation.Y + checkBoxSize.Height)
            {
                Checked = !Checked;
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(e.ColumnIndex, Checked);
                    this.DataGridView.InvalidateCell(this);
                }
            }
            base.OnMouseClick(e);
        }
    }

    class DataGridViewColumnSelector
    {
        // the DataGridView to which the DataGridViewColumnSelector is attached
        private DataGridView mDataGridView = null;
        // a CheckedListBox containing the column header text and checkboxes
        private CheckedListBox mCheckedListBox;
        // a ToolStripDropDown object used to show the popup
        private ToolStripDropDown mPopup;

        /// <summary>
        /// The max height of the popup
        /// </summary>
        public int MaxHeight = 300;
        /// <summary>
        /// The width of the popup
        /// </summary>
        public int Width = 200;

        /// <summary>
        /// Gets or sets the DataGridView to which the DataGridViewColumnSelector is attached
        /// </summary>
        public DataGridView DataGridView
        {
            get { return mDataGridView; }
            set
            {
                // If any, remove handler from current DataGridView 
                if (mDataGridView != null) mDataGridView.CellMouseClick -= new DataGridViewCellMouseEventHandler(mDataGridView_CellMouseClick);
                // Set the new DataGridView
                mDataGridView = value;
                // Attach CellMouseClick handler to DataGridView
                if (mDataGridView != null) mDataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(mDataGridView_CellMouseClick);
            }
        }

        // When user right-clicks the cell origin, it clears and fill the CheckedListBox with
        // columns header text. Then it shows the popup. 
        // In this way the CheckedListBox items are always refreshed to reflect changes occurred in 
        // DataGridView columns (column additions or name changes and so on).
        void mDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                mCheckedListBox.Items.Clear();
                foreach (DataGridViewColumn c in mDataGridView.Columns)
                {
                    mCheckedListBox.Items.Add(c.HeaderText, c.Visible);
                }
                int PreferredHeight = (mCheckedListBox.Items.Count * 16) + 7;
                mCheckedListBox.Height = (PreferredHeight < MaxHeight) ? PreferredHeight : MaxHeight;
                mCheckedListBox.Width = this.Width;
                mPopup.Show(mDataGridView.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        // The constructor creates an instance of CheckedListBox and ToolStripDropDown.
        // the CheckedListBox is hosted by ToolStripControlHost, which in turn is
        // added to ToolStripDropDown.
        public DataGridViewColumnSelector()
        {
            mCheckedListBox = new CheckedListBox();
            mCheckedListBox.CheckOnClick = true;
            mCheckedListBox.ItemCheck += new ItemCheckEventHandler(mCheckedListBox_ItemCheck);

            ToolStripControlHost mControlHost = new ToolStripControlHost(mCheckedListBox);
            mControlHost.Padding = Padding.Empty;
            mControlHost.Margin = Padding.Empty;
            mControlHost.AutoSize = false;

            mPopup = new ToolStripDropDown();
            mPopup.Padding = Padding.Empty;
            mPopup.Items.Add(mControlHost);
        }

        public DataGridViewColumnSelector(DataGridView dgv)
            : this()
        {
            this.DataGridView = dgv;
        }

        // When user checks / unchecks a checkbox, the related column visibility is 
        // switched.
        void mCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            mDataGridView.Columns[e.Index].Visible = (e.NewValue == CheckState.Checked);
        }
    }
}