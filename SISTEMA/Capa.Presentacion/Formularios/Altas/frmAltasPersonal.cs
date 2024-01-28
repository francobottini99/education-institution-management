using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Capa.Negocio.DTO;
using Capa.Presentacion.Utilidades;
using Capa.Negocio.Servicios;
using Capa.Negocio.Servicios.Implementacion;
using Capa.Presentacion.Controles;
using Capa.Presentacion.Controles.Formularios_Auxiliares;
using Capa.Presentacion.Controles.Formularios_Auxiliares.Importar;

namespace Capa.Presentacion.Formularios.Altas
{
    public partial class frmAltasPersonal : Form
    {
        private readonly IServicioPersonal servicioPersonal;
        private IEnumerable<PersonalDTO> personalList;
        private int selectedPersonalID;
        private int selectedIndividuoID;
        private WritingOperations operation;

        private static frmAltasPersonal instance;

        private static readonly object _lock = new object();

        public static frmAltasPersonal GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new frmAltasPersonal();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private frmAltasPersonal()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            servicioPersonal = new ServicioPersonal();
        }

        private void frmAltasPersonal_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            Cancelar();

            btnNuevo.Focus();
        }

        private void Cancelar()
        {
            dgvPersonal.Enabled = true;
            txtBuscar.Enabled = true;

            txtFechaIngreso.Enabled = false;
            txtFechaNac.Enabled = false;
            txtLegajo.Enabled = false;
            cbxGenero.Enabled = false;
            txtApellidos.Enabled = false;
            txtNombres.Enabled = false;
            txtDNI.Enabled = false;
            txtDireccion.Enabled = false;
            txtLocalidad.Enabled = false;
            txtCP.Enabled = false;
            cbxProvincia.Enabled = false;
            txtPais.Enabled = false;
            txtNacionalidad.Enabled = false;
            txtTelefono.Enabled = false;
            txtMail.Enabled = false;
            txtWeb.Enabled = false;
            txtCuit.Enabled = false;
            txtCbu.Enabled = false;

            txtBuscar.Text = "";

            ClearData();

            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;
            btnImportar.Enabled = true;

            Application.DoEvents();

            RefreshPersonalList();

            btnNuevo.Focus();
        }

        private void Activar()
        {
            dgvPersonal.Enabled = false;
            txtBuscar.Enabled = false;

            txtFechaIngreso.Enabled = true;
            txtFechaNac.Enabled = true;
            txtLegajo.Enabled = true;
            cbxGenero.Enabled = true;
            txtApellidos.Enabled = true;
            txtNombres.Enabled = true;
            txtDNI.Enabled = true;
            txtDireccion.Enabled = true;
            txtLocalidad.Enabled = true;
            txtCP.Enabled = true;
            cbxProvincia.Enabled = true;
            txtPais.Enabled = true;
            txtNacionalidad.Enabled = true;
            txtTelefono.Enabled = true;
            txtMail.Enabled = true;
            txtWeb.Enabled = true;
            txtCuit.Enabled = true;
            txtCbu.Enabled = true;

            txtFechaAlta.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaIngreso.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaNac.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtPais.Text = "Argentina";
            cbxProvincia.Text = "Córdoba";
            txtNacionalidad.Text = "Argentino";

            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            btnImportar.Enabled = false;

            txtFechaIngreso.Focus();
        }

        private void ClearData()
        {
            selectedPersonalID = -1;
            selectedIndividuoID = -1;

            dgvPersonal.ClearSelection();
            dgvPersonal.CurrentCell = null;

            txtFechaAlta.Text = "";
            txtFechaIngreso.Text = "";
            txtFechaNac.Text = "";
            txtLegajo.Text = "";
            cbxGenero.Text = "";
            txtApellidos.Text = "";
            txtNombres.Text = "";
            txtDNI.Text = "";
            txtDireccion.Text = "";
            txtLocalidad.Text = "";
            txtCP.Text = "";
            cbxProvincia.Text = "";
            txtPais.Text = "";
            txtNacionalidad.Text = "";
            txtTelefono.Text = "";
            txtMail.Text = "";
            txtWeb.Text = "";
            txtCuit.Text = "";
            txtCbu.Text = "";
        }

        private async void RefreshPersonalList()
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE PERSONAL");

            personalList = (await servicioPersonal.ConsultarTodos()).OrderBy(x => x.Individuo.Apellidos).ThenBy(x => x.Individuo.Nombres); ;

            RefreshPersonalDataGrid();

            IDDVSLoadingBox.Hide();
        }

        private void RefreshPersonalDataGrid()
        {
            if (personalList == null)
                return;
           
            IEnumerable<PersonalDTO> data;

            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
                data = personalList.Where(p => string.Concat(p.Individuo.Apellidos, ", ", p.Individuo.Nombres).Contains(txtBuscar.Text));
            else
                data = personalList;
        
            dgvPersonal.Columns.Clear();
            dgvPersonal.Columns.Add("ID", "ID");
            dgvPersonal.Columns.Add("Nombre_Apellido", "NOMBRE Y APELLIDO");

            dgvPersonal.Columns["ID"].Visible = false;
            dgvPersonal.ColumnHeadersVisible = false;

            foreach (PersonalDTO personal in data)
                dgvPersonal.Rows.Add(personal.ID, personal.Individuo.Apellidos + ", " + personal.Individuo.Nombres);

            ClearData();

            dgvPersonal.ClearSelection();
            dgvPersonal.CurrentCell = null;
        }

        private void pbxX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgvPersonal.ClearSelection();
            dgvPersonal.CurrentCell = null;

            ClearData();
            Activar();

            operation = WritingOperations.NEW;

            txtFechaIngreso.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (selectedPersonalID != -1)
            {
                Activar();

                operation = WritingOperations.UPDATE;

                txtFechaIngreso.Focus();
            }
            else
                IDDVSMsgBox.Show("Debes seleccionar del listado el registro que deseas modificar !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedPersonalID != -1)
            {
                DialogResult response = IDDVSMsgBox.Show("Seguro que deseas eliminar el registro ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                if (response == DialogResult.OK)
                {
                    try
                    {
                        IDDVSLoadingBox.Show("ELIMINANDO REGISTRO");

                        await servicioPersonal.Eliminar(selectedPersonalID);

                        RefreshPersonalList();

                        IDDVSMsgBox.Show("Registro eliminado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                    }
                    catch (Exception ex)
                    {
                        if (!(ex is ArgumentException))
                            RefreshPersonalList();

                        IDDVSLoadingBox.Hide();
                        IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                    }
                }
            }
            else
                IDDVSMsgBox.Show("Debes seleccionar del listado el registro que deseas eliminar !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void dgvPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                PersonalDTO selectedListRegister = personalList.FirstOrDefault(x => x.ID == (int)dgvPersonal.CurrentRow.Cells["ID"].Value);

                if (selectedListRegister != null)
                {
                    selectedPersonalID = selectedListRegister.ID;
                    selectedIndividuoID = selectedListRegister.Individuo.ID;

                    txtCbu.Text = selectedListRegister.CBU;
                    txtCuit.Text = selectedListRegister.CUIT;
                    txtFechaAlta.Text = selectedListRegister.Individuo.FechaAlta.ToString("dd/MM/yyyy");
                    txtFechaNac.Text = selectedListRegister.Individuo.FechaNacimiento.ToString("dd/MM/yyyy");
                    txtFechaIngreso.Text = selectedListRegister.Individuo.FechaIngreso.ToString("dd/MM/yyyy");
                    txtLegajo.Text = string.Format("{0:#,##0}", Convert.ToDouble(selectedListRegister.Individuo.NumeroLegajo));
                    cbxGenero.Text = selectedListRegister.Individuo.Genero;
                    txtApellidos.Text = selectedListRegister.Individuo.Apellidos;
                    txtNombres.Text = selectedListRegister.Individuo.Nombres;
                    txtDNI.Text = string.Format("{0:#,##0}", Convert.ToDouble(selectedListRegister.Individuo.DNI));
                    txtDireccion.Text = selectedListRegister.Individuo.Direccion;
                    txtLocalidad.Text = selectedListRegister.Individuo.Localidad;
                    txtCP.Text = selectedListRegister.Individuo.CP;
                    cbxProvincia.Text = selectedListRegister.Individuo.Provincia;
                    txtPais.Text = selectedListRegister.Individuo.Pais;
                    txtNacionalidad.Text = selectedListRegister.Individuo.Nacionalidad;
                    txtTelefono.Text = selectedListRegister.Individuo.Telefonos;
                    txtMail.Text = selectedListRegister.Individuo.Mail;
                    txtWeb.Text = selectedListRegister.Individuo.Web;

                    btnModificar.Select();
                }
                else
                    ClearData();
            }
            else
                ClearData();
        }

        private void txtBuscar__TextChanged(object sender, EventArgs e)
        {
            RefreshPersonalDataGrid();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            string err_personal = null;
            string err_individuo = null;

            PersonalDTO personal = new PersonalDTO
            {
                ID = selectedPersonalID > 0 ? selectedPersonalID : 0,
                CBU = txtCbu.Text.Trim(),
                CUIT = txtCuit.Text.Trim(),
                Individuo = new IndividuoDTO
                {
                    ID = selectedIndividuoID > 0 ? selectedIndividuoID : 0,
                    FechaAlta = DateTime.Parse(txtFechaAlta.Text),
                    FechaNacimiento = DateTime.Parse(txtFechaNac.Text),
                    FechaIngreso = DateTime.Parse(txtFechaIngreso.Text),
                    NumeroLegajo = txtLegajo.Text.Replace(".", "").Trim(),
                    Genero = cbxGenero.Text.Trim(),
                    Apellidos = txtApellidos.Text.Trim(),
                    Nombres = txtNombres.Text.Trim(),
                    DNI = txtDNI.Text.Replace(".", "").Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Localidad = txtLocalidad.Text.Trim(),
                    CP = txtCP.Text.Trim(),
                    Provincia = cbxProvincia.Text.Trim(),
                    Pais = txtPais.Text.Trim(),
                    Nacionalidad = txtNacionalidad.Text.Trim(),
                    Telefonos = txtTelefono.Text.Trim(),
                    Mail = txtMail.Text.Trim(),
                    Web = txtWeb.Text.Trim()
                }
            };

            if (!Tools.Validate(personal.Individuo, out ICollection<ValidationResult> results))
                err_individuo += string.Join("\n\n", results.Select(o => o.ErrorMessage));

            if (!Tools.Validate(personal, out results))
                err_personal += string.Join("\n\n", results.Select(o => o.ErrorMessage));

            if (!string.IsNullOrWhiteSpace(err_personal) || !string.IsNullOrWhiteSpace(err_individuo))
                IDDVSMsgBox.Show(err_individuo + "\n\n" + err_personal, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
            else
            {
                try
                {
                    if (operation == WritingOperations.NEW)
                    {
                        DialogResult response = IDDVSMsgBox.Show("Seguro que deseas guardar el registro ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                        if(response == DialogResult.OK)
                        {
                            IDDVSLoadingBox.Show("GUARDANDO REGISTRO");

                            await servicioPersonal.Insertar(personal);

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

                            await servicioPersonal.Modificar(personal);

                            Cancelar();

                            IDDVSMsgBox.Show("Registro modificado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!(ex is ArgumentException))
                        RefreshPersonalList();

                    IDDVSLoadingBox.Hide();                 
                    IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (IDDVSImportar.Show(new PersonalImport()) != null)
                RefreshPersonalList();
        }

        private void frmAltasPersonal_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void dgvPersonal_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvPersonal.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
                ClearData();
        }
    }
}
