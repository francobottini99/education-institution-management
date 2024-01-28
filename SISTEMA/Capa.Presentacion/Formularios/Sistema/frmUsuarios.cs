using Capa.Negocio.DTO;
using Capa.Negocio.Servicios;
using Capa.Negocio.Servicios.Implementacion;
using Capa.Presentacion.Controles;
using Capa.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion.Formularios.Altas
{
    public partial class frmUsuarios : Form
    {
        private static frmUsuarios instance;

        private static readonly object _lock = new object();

        private readonly IServicioUsuario servicioUsuario;
        private readonly IServicioPerfilUsuario servicioPerfil;
        private IEnumerable<PerfilUsuarioDTO> perfilesList;
        private IEnumerable<UsuarioDTO> usuarioList;
        private int selectedPerfilID;
        private int selectedUsuarioID;
        private WritingOperations operation;

        public static frmUsuarios GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new frmUsuarios();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private frmUsuarios()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            servicioPerfil = new ServicioPerfilUsuario();
            servicioUsuario = new ServicioUsuario();
        }

        private void frmUsuarios_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            Cancelar();

            btnNuevo.Select();
        }

        private void frmUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void Cancelar()
        {
            dgvUsuario.Enabled = true;
            dgvPerfiles.Enabled = false;
            dgvAccesos.Enabled = false;
            txtBuscar.Enabled = true;

            txtApellidos.Enabled = false;
            txtNombres.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtContraseña.Enabled = false;
            txtReingreso.Enabled = false;
            cbxEstado.Enabled = false;

            txtBuscar.Text = "";

            ClearAllData();

            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;

            Application.DoEvents();

            RefreshPerfilesList();
            RefreshUsuariosList();

            if (perfilesList.Count() < 1)
            {
                IDDVSMsgBox.Show("No hay perfiles de usuario cargados en el sistema. No puedes crear nuevos usuarios sin un perfil de usuario !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
                this.Close();
            }

            btnNuevo.Select();
        }

        private void Activar()
        {
            dgvUsuario.Enabled = false;
            dgvPerfiles.Enabled = true;
            dgvAccesos.Enabled = true;
            txtBuscar.Enabled = true;

            txtApellidos.Enabled = true;
            txtNombres.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtContraseña.Enabled = true;
            txtReingreso.Enabled = true;
            cbxEstado.Enabled = true;

            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;

            txtApellidos.Select();
        }

        private void ClearAllData()
        {
            selectedUsuarioID = -1;

            txtApellidos.Text = "";
            txtNombres.Text = "";
            txtNombreUsuario.Text = "";
            txtContraseña.Text = "";
            txtReingreso.Text = "";
            cbxEstado.Text = "";

            ClearPerfilData();
        }

        private void ClearPerfilData()
        {
            dgvAccesos.Rows.Clear();
            dgvAccesos.Columns.Clear();

            selectedPerfilID = -1;
            txtPerfil.Text = "";
        }


        private async void RefreshPerfilesList()
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE PERFILES DE USUARIO");

            perfilesList = await servicioPerfil.ConsultarTodos();

            RefreshPerfilesDataGrid();

            IDDVSLoadingBox.Hide();
        }

        private async void RefreshUsuariosList()
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE USUARIOS");

            usuarioList = (await servicioUsuario.ConsultarTodos()).OrderBy(x => x.Apellidos).ThenBy(x => x.Nombres);

            RefreshUsuariosDataGrid();

            IDDVSLoadingBox.Hide();
        }

        private void RefreshUsuariosDataGrid()
        {
            if (perfilesList == null)
                return;

            IEnumerable<UsuarioDTO> data;

            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
                data = usuarioList.Where(p => p.NombreUsuario.Contains(txtBuscar.Text));
            else
                data = usuarioList;

            dgvUsuario.Columns.Clear();
            dgvUsuario.Columns.Add("ID", "ID");
            dgvUsuario.Columns.Add("usuario", "USUARIO");
            dgvUsuario.Columns.Add("nombre_apellido", "NOMBRE Y APELLIDO");

            dgvUsuario.Columns["ID"].Visible = false;
            dgvUsuario.ColumnHeadersVisible = false;

            dgvUsuario.Columns["nombre_apellido"].Width = 250;

            foreach (UsuarioDTO usuario in data)
                dgvUsuario.Rows.Add(usuario.ID, usuario.NombreUsuario, string.Concat(usuario.Apellidos, ", ", usuario.Nombres));

            ClearAllData();

            dgvUsuario.ClearSelection();
            dgvUsuario.CurrentCell = null;
        }

        private void RefreshPerfilesDataGrid()
        {
            if (perfilesList == null)
                return;

            dgvPerfiles.Columns.Clear();
            dgvPerfiles.Columns.Add("ID", "ID");
            dgvPerfiles.Columns.Add("Nombre", "NOMBRE");

            dgvPerfiles.Columns["ID"].Visible = false;
            dgvPerfiles.ColumnHeadersVisible = false;

            foreach (PerfilUsuarioDTO perfil in perfilesList)
                dgvPerfiles.Rows.Add(perfil.ID, perfil.Nombre);

            dgvPerfiles.ClearSelection();
            dgvPerfiles.CurrentCell = null;
        }

        private async void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearPerfilData();

            if (e.RowIndex > -1)
            {
                selectedPerfilID = (int)dgvPerfiles.CurrentRow.Cells["ID"].Value;
                txtPerfil.Text = dgvPerfiles.CurrentRow.Cells["Nombre"].Value.ToString();

                IEnumerable<DetallePerfilUsuarioDTO> detalle = await servicioPerfil.ConsultarDetallePerfil(selectedPerfilID);

                dgvAccesos.Columns.Add("Menu", "MENU");

                foreach (DetallePerfilUsuarioDTO item in detalle)
                    dgvAccesos.Rows.Add(item.Menu);
            }
            else
            {
                dgvPerfiles.ClearSelection();
                dgvPerfiles.CurrentCell = null;
            }
        }

        private async void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearAllData();

            dgvPerfiles.ClearSelection();
            dgvPerfiles.CurrentCell = null;

            if (e.RowIndex > -1)
            {
                UsuarioDTO selectedListRegister = usuarioList.FirstOrDefault(x => x.ID == (int)dgvUsuario.CurrentRow.Cells["ID"].Value);

                if(selectedListRegister != null)
                {
                    selectedUsuarioID = selectedListRegister.ID;
                    selectedPerfilID = selectedListRegister.PerfilUsuario.ID;

                    txtApellidos.Text = selectedListRegister.Apellidos;
                    txtNombres.Text = selectedListRegister.Nombres;
                    txtNombreUsuario.Text = selectedListRegister.NombreUsuario;
                    txtContraseña.Text = selectedListRegister.Contraseña;
                    txtReingreso.Text = selectedListRegister.Contraseña;
                    cbxEstado.Text = selectedListRegister.Estado;

                    IEnumerable<DetallePerfilUsuarioDTO> detalle = await servicioPerfil.ConsultarDetallePerfil(selectedPerfilID);

                    dgvAccesos.Columns.Add("Menu", "MENU");

                    foreach (DetallePerfilUsuarioDTO item in detalle)
                        dgvAccesos.Rows.Add(item.Menu);

                    foreach (DataGridViewRow row in dgvPerfiles.Rows)
                    {
                        if ((int)row.Cells["ID"].Value == selectedPerfilID)
                        {
                            row.Selected = true;
                            txtPerfil.Text = row.Cells["Nombre"].Value.ToString();
                        }
                    }

                    btnModificar.Select();
                }
                else
                {
                    dgvUsuario.ClearSelection();
                    dgvUsuario.CurrentCell = null;
                }
            }
            else
            {
                dgvUsuario.ClearSelection();
                dgvUsuario.CurrentCell = null;
            }
        }

        private void dgvPerfiles_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvPerfiles.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
                ClearPerfilData();
        }

        private void dgvUsuario_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvPerfiles.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
            {
                ClearAllData();

                dgvPerfiles.ClearSelection();
                dgvPerfiles.CurrentCell = null;
            }
        }

        private void txtBuscar__TextChanged(object sender, EventArgs e)
        {
            RefreshUsuariosDataGrid();
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
            dgvUsuario.ClearSelection();
            dgvUsuario.CurrentCell = null;

            dgvPerfiles.ClearSelection();
            dgvPerfiles.CurrentCell = null;

            ClearAllData();

            Activar();

            operation = WritingOperations.NEW;

            txtApellidos.Select();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (selectedUsuarioID != -1)
            {
                Activar();

                operation = WritingOperations.UPDATE;

                txtApellidos.Select();
            }
            else
                IDDVSMsgBox.Show("Debes seleccionar del listado el registro que deseas modificar !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);

        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedUsuarioID != -1)
            {
                DialogResult response = IDDVSMsgBox.Show("Seguro que deseas eliminar el registro ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                if (response == DialogResult.OK)
                {
                    try
                    {
                        IDDVSLoadingBox.Show("ELIMINANDO REGISTRO");

                        await servicioUsuario.Eliminar(selectedUsuarioID);

                        RefreshUsuariosList();
                        RefreshPerfilesList();

                        IDDVSMsgBox.Show("Registro eliminado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                    }
                    catch (Exception ex)
                    {
                        if (!(ex is ArgumentException))
                        {
                            RefreshUsuariosList();
                            RefreshPerfilesList();
                        }

                        IDDVSLoadingBox.Hide();
                        IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                    }
                }
            }
            else
                IDDVSMsgBox.Show("Debes seleccionar del listado el registro que deseas eliminar !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text != txtReingreso.Text)
            {
                IDDVSMsgBox.Show("Las contraseñas no coinciden", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                return;
            }

            if (selectedPerfilID < 0)
            {
                IDDVSMsgBox.Show("Se debe seleccionar un perfil para el usuario", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                return;
            }

            UsuarioDTO usuario = new UsuarioDTO()
            {
                ID = selectedUsuarioID > 0 ? selectedUsuarioID : 0,
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                NombreUsuario = txtNombreUsuario.Text.Trim(),
                Contraseña = txtContraseña.Text.Trim(),
                Estado = cbxEstado.Text.Trim(),
                PerfilUsuario = new PerfilUsuarioDTO() { ID = selectedPerfilID }
            };

            if (!Tools.Validate(usuario, out ICollection<ValidationResult> results))
                IDDVSMsgBox.Show(string.Join("\n\n", results.Select(o => o.ErrorMessage)), IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
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

                            await servicioUsuario.Insertar(usuario);

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

                            await servicioUsuario.Modificar(usuario);

                            Cancelar();

                            IDDVSMsgBox.Show("Registro modificado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!(ex is ArgumentException))
                    {
                        RefreshPerfilesList();
                        RefreshUsuariosList();
                    }

                    IDDVSLoadingBox.Hide();
                    IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                }
            }
        }
    }
}
