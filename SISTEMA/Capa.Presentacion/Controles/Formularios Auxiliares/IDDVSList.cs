using Capa.Negocio.DTO;
using Capa.Presentacion.Controles.Formularios_Auxiliares.Listas;
using Capa.Presentacion.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles.Formularios_Auxiliares
{
    public partial class IDDVSList : Form
    {
        private static IDDVSList instance;

        private static readonly object _lock = new object();

        private static object inputArgument;
        private static IEnumerable<IDTO> dataList;
        private static IDTO selectedItem;
        private static IList listType;

        private static IDDVSList GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new IDDVSList();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private IDDVSList()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void txtBuscar__TextChanged(object sender, EventArgs e)
        {
            listType.LoadDataGrid(ref dgvDatos, dataList, txtBuscar.Text);
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                selectedItem = dataList.FirstOrDefault(x => x.ID == (int)dgvDatos.CurrentRow.Cells["ID"].Value);

                if (selectedItem != null)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void pbxX_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void IDDVSList_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private async void IDDVSList_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            try
            {
                dataList = await listType.LoadList(inputArgument);

                lblTitulo.Text = listType.ToString();

                listType.LoadDataGrid(ref dgvDatos, dataList);
            }
            catch (Exception ex)
            {
                IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);

                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        public static T Show<T>(IList type, object argument = null) where T : IDTO
        {
            IDDVSList form = GetInstance();

            listType = type;
            inputArgument = argument;

            if (form.ShowDialog() == DialogResult.OK)
                return (T)selectedItem;
            else
                return default;
        }
    }
}
