using Capa.Negocio.DTO;
using Capa.Negocio.Servicios;
using Capa.Negocio.Servicios.Implementacion;
using Capa.Presentacion.Controles;
using Capa.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Capa.Presentacion.Formularios.Altas
{
    public partial class frmPerfiles : Form
    {
        private static frmPerfiles instance;

        private static readonly object _lock = new object();

        private readonly IServicioPerfilUsuario servicioPerfil;
        private IEnumerable<PerfilUsuarioDTO> perfilesList;
        private int selectedPerfilID;
        private WritingOperations operation;

        public static frmPerfiles GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new frmPerfiles();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private frmPerfiles()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            servicioPerfil = new ServicioPerfilUsuario();
        }

        private void frmPerfiles_Shown(object sender, EventArgs e)
        {
            pnlMenus.Height = (pnlDatos.Height - pnlNombre.Height) / 2;
            pnlAccesos.Height = (pnlDatos.Height - pnlNombre.Height) / 2;

            Application.DoEvents();

            LoadMenus();

            Cancelar();

            btnNuevo.Select();
        }

        private void frmPerfiles_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void frmPerfiles_SizeChanged(object sender, EventArgs e)
        {
            pnlMenus.Height = (pnlDatos.Height - pnlNombre.Height) / 2;
            pnlAccesos.Height = (pnlDatos.Height - pnlNombre.Height) / 2;
        }

        private void LoadMenus()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            DatagridViewCheckBoxHeaderCell checkBoxHeader = new DatagridViewCheckBoxHeaderCell();
            
            checkBoxColumn.HeaderCell = checkBoxHeader;
            checkBoxHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(checkBoxHeader_OnCheckBoxClicked);

            checkBoxColumn.Name = "Acceso";
            checkBoxColumn.HeaderText = "";

            dgvAccesos.Columns.Add("Menu", "MENU");

            dgvMenus.Columns.Add(checkBoxColumn);
            dgvMenus.Columns.Add("Menu", "MENU");
            dgvMenus.Columns["Acceso"].Width = 80;

            using (XmlReader reader = XmlReader.Create("..\\..\\Datos\\Perfiles de Usuario\\MenusList.xml"))
                while (reader.ReadToFollowing("Menu"))
                    dgvMenus.Rows.Add(false, reader.ReadElementContentAsString().Replace("\"", "").Trim());

        }

        private void Cancelar()
        {
            dgvPerfiles.Enabled = true;
            dgvMenus.Enabled = false;
            dgvAccesos.Enabled = false;
            txtBuscar.Enabled = true;

            txtNombPerfil.Enabled = false;

            txtBuscar.Text = "";

            ClearData();

            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;

            Application.DoEvents();

            RefreshPerfilesList();

            btnNuevo.Focus();
        }

        private void Activar()
        {
            dgvPerfiles.Enabled = false;
            dgvMenus.Enabled = true;
            dgvAccesos.Enabled = true;
            txtBuscar.Enabled = false;

            txtNombPerfil.Enabled = true;

            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;

            txtNombPerfil.Select();
        }

        private void ClearData()
        {
            selectedPerfilID = -1;

            txtNombPerfil.Text = "";

            dgvAccesos.Rows.Clear();

            ((DatagridViewCheckBoxHeaderCell)dgvMenus.Columns["Acceso"].HeaderCell).Checked = false;

            foreach (DataGridViewRow row in dgvMenus.Rows)
                row.Cells["Acceso"].Value = false;
        }

        private async void RefreshPerfilesList()
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE PERFILES DE USUARIO");

            perfilesList = (await servicioPerfil.ConsultarTodos()).OrderBy(x => x.Nombre);

            RefreshPerfilesDataGrid();

            IDDVSLoadingBox.Hide();
        }

        private void RefreshPerfilesDataGrid()
        {
            if (perfilesList == null)
                return;

            IEnumerable<PerfilUsuarioDTO> data;

            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
                data = perfilesList.Where(p => p.Nombre.Contains(txtBuscar.Text));
            else
                data = perfilesList;

            dgvPerfiles.Columns.Clear();
            dgvPerfiles.Columns.Add("ID", "ID");
            dgvPerfiles.Columns.Add("Nombre", "NOMBRE");

            dgvPerfiles.Columns["ID"].Visible = false;
            dgvPerfiles.ColumnHeadersVisible = false;

            foreach (PerfilUsuarioDTO perfil in data)
                dgvPerfiles.Rows.Add(perfil.ID, perfil.Nombre);

            ClearData();

            dgvPerfiles.ClearSelection();
            dgvPerfiles.CurrentCell = null;
        }

        private void checkBoxHeader_OnCheckBoxClicked(int columnIndex, bool state)
        {
            dgvAccesos.Rows.Clear();

            if (state)
            {
                foreach (DataGridViewRow row in dgvMenus.Rows)
                {
                    row.Cells["Acceso"].Value = true;
                    dgvAccesos.Rows.Add(row.Cells["Menu"].Value);
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvMenus.Rows)
                    row.Cells["Acceso"].Value = false;
            }

            if (string.IsNullOrWhiteSpace(txtNombPerfil.Text))
                txtNombPerfil.Select();
            else if (dgvAccesos.Rows.Count > 0)
                btnGuardar.Select();
        }

        private void dgvMenus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMenus.Columns["Acceso"].Index)
            {
                if (e.RowIndex > -1)
                {
                    DatagridViewCheckBoxHeaderCell checkBoxHeaderCell = (DatagridViewCheckBoxHeaderCell)dgvMenus.Columns["Acceso"].HeaderCell;

                    if (!(bool)dgvMenus.CurrentCell.Value)
                    {
                        bool selectedAll = true;

                        dgvMenus.CurrentCell.Value = true;
                        dgvAccesos.Rows.Add(dgvMenus.CurrentRow.Cells["Menu"].Value);

                        foreach (DataGridViewRow row in dgvMenus.Rows)
                        {
                            if (!(bool)row.Cells["Acceso"].Value)
                            {
                                selectedAll = false;
                                break;
                            }
                        }

                        if(selectedAll)
                            checkBoxHeaderCell.Checked = true;
                    }
                    else
                    {
                        dgvMenus.CurrentCell.Value = false;

                        checkBoxHeaderCell.Checked = false;

                        for (int i = dgvAccesos.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dgvAccesos.Rows[i].Cells["Menu"].Value == dgvMenus.CurrentRow.Cells["Menu"].Value)
                            {
                                dgvAccesos.Rows.Remove(dgvAccesos.Rows[i]);
                                break;
                            }
                        }
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(txtNombPerfil.Text))
                txtNombPerfil.Select();
            else if (dgvAccesos.Rows.Count > 0)
                btnGuardar.Select();
        }

        private async void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearData();

            if (e.RowIndex > -1)
            {
                bool selectedAll = true;

                selectedPerfilID = (int)dgvPerfiles.CurrentRow.Cells["ID"].Value;
                txtNombPerfil.Text = dgvPerfiles.CurrentRow.Cells["Nombre"].Value.ToString();

                IEnumerable<DetallePerfilUsuarioDTO> detalle = await servicioPerfil.ConsultarDetallePerfil(selectedPerfilID);

                foreach (DataGridViewRow row in dgvMenus.Rows)
                {
                    var exist = detalle.FirstOrDefault(x => x.Menu == row.Cells["Menu"].Value.ToString());

                    if (exist != null)
                    {
                        row.Cells["Acceso"].Value = true;
                        dgvAccesos.Rows.Add(row.Cells["Menu"].Value);
                    }
                    else
                        selectedAll = false;
                }

                if (selectedAll)
                    ((DatagridViewCheckBoxHeaderCell)dgvMenus.Columns["Acceso"].HeaderCell).Checked = true;

                btnModificar.Select();
            }
            else
            {
                dgvPerfiles.ClearSelection();
                dgvPerfiles.CurrentCell = null;
            }
        }

        private void dgvPerfiles_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvPerfiles.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
                ClearData();
        }

        private void txtBuscar__TextChanged(object sender, EventArgs e)
        {
            RefreshPerfilesDataGrid();
        }

        private void pbxX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgvPerfiles.ClearSelection();
            dgvPerfiles.CurrentCell = null;

            ClearData();
            Activar();

            operation = WritingOperations.NEW;

            txtNombPerfil.Select();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (selectedPerfilID != -1)
            {
                Activar();

                operation = WritingOperations.UPDATE;

                txtNombPerfil.Select();
            }
            else
                IDDVSMsgBox.Show("Debes seleccionar del listado el registro que deseas modificar !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedPerfilID != -1)
            {
                DialogResult response = IDDVSMsgBox.Show("Seguro que deseas eliminar el registro ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                if (response == DialogResult.OK)
                {
                    if(await servicioPerfil.ExistenUsuariosAsociadoAlPerfil(selectedPerfilID))
                        response = IDDVSMsgBox.Show("Existen usuarios asociados al perfil que quieres eliminar. Si continuas con la operacion, todos los usuarios asociados al perfil seran eliminados. Continuar de todas formas ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                    if (response == DialogResult.OK)
                    {
                        try
                        {
                            IDDVSLoadingBox.Show("ELIMINANDO REGISTRO");

                            await servicioPerfil.Eliminar(selectedPerfilID);

                            RefreshPerfilesList();

                            IDDVSMsgBox.Show("Registro eliminado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                        }
                        catch (Exception ex)
                        {
                            if (!(ex is ArgumentException))
                                RefreshPerfilesList();

                            IDDVSLoadingBox.Hide();
                            IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                        }
                    }
                }
            }
            else
                IDDVSMsgBox.Show("Debes seleccionar del listado el registro que deseas eliminar !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            PerfilUsuarioDTO perfil = new PerfilUsuarioDTO()
            {
                ID = selectedPerfilID > 0? selectedPerfilID : 0,
                Nombre = txtNombPerfil.Text.Trim()
            };

            List<DetallePerfilUsuarioDTO> detalle = new List<DetallePerfilUsuarioDTO>();

            foreach (DataGridViewRow row in dgvAccesos.Rows)
                detalle.Add(new DetallePerfilUsuarioDTO() 
                { 
                    Menu = row.Cells["Menu"].Value.ToString(), 
                    PerfilUsuario = perfil 
                });

            if (!Tools.Validate(perfil, out ICollection<ValidationResult> results))
                IDDVSMsgBox.Show(string.Join("\n\n", results.Select(o => o.ErrorMessage)), IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
            else if (detalle.Count == 0)
                IDDVSMsgBox.Show("No se puede insertar un perfil de usuario sin acceso a ningun menu", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
            else
            {
                try
                {
                    if (operation == WritingOperations.NEW)
                    {
                        DialogResult response = IDDVSMsgBox.Show("Seguro que deseas guardar el registro ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                        if (response == DialogResult.OK)
                        {
                            IDDVSLoadingBox.Show("GUARDANDO REGISTRO");

                            await servicioPerfil.Insertar(perfil, detalle);

                            Cancelar();

                            IDDVSMsgBox.Show("Registro guardado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                        }
                    }
                    else if (operation == WritingOperations.UPDATE)
                    {
                        DialogResult response = IDDVSMsgBox.Show("Seguro que deseas modificar el registro ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                        if (response == DialogResult.OK)
                        {
                            IDDVSLoadingBox.Show("MODIFICANDO REGISTRO");

                            await servicioPerfil.Modificar(perfil, detalle);

                            Cancelar();

                            IDDVSMsgBox.Show("Registro modificado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if(!(ex is ArgumentException))
                        RefreshPerfilesList();

                    IDDVSLoadingBox.Hide();
                    IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                }
            }
        }
    }
}
