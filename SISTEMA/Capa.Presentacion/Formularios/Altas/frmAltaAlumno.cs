using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Capa.Negocio.DTO;
using Capa.Presentacion.Utilidades;
using Capa.Negocio.Servicios.Implementacion;
using Capa.Negocio.Servicios;
using Capa.Presentacion.Controles;
using Capa.Presentacion.Controles.Formularios_Auxiliares;
using Capa.Presentacion.Controles.Formularios_Auxiliares.Importar;

namespace Capa.Presentacion.Formularios
{
    public partial class frmAltaAlumno : Form
    {
        private static frmAltaAlumno instance;
        private static readonly object _lock = new object();

        private readonly IServicioAlumno servicioAlumno;
        private IEnumerable<AlumnoDTO> alumnolList;
        private int selectedAlumnoID;
        private int selectedIndividuoID;
        private WritingOperations operation;

        public static frmAltaAlumno GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new frmAltaAlumno();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private frmAltaAlumno()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            servicioAlumno = new ServicioAlumno();
        }

        private void frmAltaAlumno_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void Cancelar()
        {
            dgvAlumno.Enabled = true;
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
            cbxTipoIng.Enabled = false;
            txtTutor.Enabled = false;
            txtTETutor.Enabled = false;
            txtMailTutor.Enabled = false;
            txtDirTutor.Enabled = false;
            txtLocTutor.Enabled = false;
            cbxProvTutor.Enabled = false;
            txtCPTutor.Enabled = false;
            cbxEstado.Enabled = false;

            txtBuscar.Text = "";

            ClearData();

            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;
            btnImportar.Enabled = true;

            Application.DoEvents();

            RefreshAlumnoList();

            btnNuevo.Focus();
        }

        private void Activar()
        {
            dgvAlumno.Enabled = false;
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
            cbxTipoIng.Enabled = true;
            txtTutor.Enabled = true;
            txtTETutor.Enabled = true;
            txtMailTutor.Enabled = true;
            txtDirTutor.Enabled = true;
            txtLocTutor.Enabled = true;
            cbxProvTutor.Enabled = true;
            txtCPTutor.Enabled = true;
            cbxEstado.Enabled = true;

            txtFechaAlta.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaIngreso.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaNac.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtPais.Text = "Argentina";
            cbxProvincia.Text = "Córdoba";
            txtNacionalidad.Text = "Argentino";
            cbxProvTutor.Text = "Córdoba";
            cbxEstado.Text = "Activo";

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
            selectedAlumnoID = -1;
            selectedIndividuoID = -1;

            dgvAlumno.ClearSelection();
            dgvAlumno.CurrentCell = null;

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
            cbxTipoIng.Text = "";
            txtTutor.Text = "";
            txtTETutor.Text = "";
            txtMailTutor.Text = "";
            txtDirTutor.Text = "";
            txtLocTutor.Text = "";
            cbxProvTutor.Text = "";
            txtCPTutor.Text = "";
            cbxEstado.Text = "";
        }

        private async void RefreshAlumnoList()
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE ALUMNOS");

            alumnolList  = (await servicioAlumno.ConsultarTodos()).OrderBy(x => x.Individuo.Apellidos).ThenBy(x => x.Individuo.Nombres);

            RefreshAlumnoDataGrid();

            IDDVSLoadingBox.Hide();
        }

        private void RefreshAlumnoDataGrid()
        {
            if (alumnolList  == null)
                return;

            IEnumerable<AlumnoDTO> data;

            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
                data = alumnolList.Where(p => string.Concat(p.Individuo.Apellidos, ", ", p.Individuo.Nombres).Contains(txtBuscar.Text));
            else
                data = alumnolList;

            dgvAlumno.Columns.Clear();
            dgvAlumno.Columns.Add("ID", "ID");
            dgvAlumno.Columns.Add("Nombre_Apellido", "NOMBRE Y APELLIDO");

            dgvAlumno.Columns["ID"].Visible = false;
            dgvAlumno.ColumnHeadersVisible = false;

            foreach (AlumnoDTO alumno in data)
                dgvAlumno.Rows.Add(alumno.ID, alumno.Individuo.Apellidos + ", " + alumno.Individuo.Nombres);

            ClearData();
        }

        private void pbxX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ClearData();
            Activar();

            operation = WritingOperations.NEW;

            txtFechaIngreso.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (selectedAlumnoID != -1)
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
            if (selectedAlumnoID != -1)
            {
                DialogResult response = IDDVSMsgBox.Show("Seguro que deseas eliminar el registro ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                if (response == DialogResult.OK)
                {
                    try
                    {
                        IDDVSLoadingBox.Show("ELIMINANDO REGISTRO");

                        await servicioAlumno.Eliminar(selectedAlumnoID);

                        RefreshAlumnoList();

                        IDDVSMsgBox.Show("Registro eliminado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                    }
                    catch (Exception ex)
                    {
                        if (!(ex is ArgumentException))
                            RefreshAlumnoList();

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
            string err_alumno = null;
            string err_individuo = null;

            AlumnoDTO alumno = new AlumnoDTO
            {
                ID = selectedAlumnoID > 0 ? selectedAlumnoID : 0,
                TipoIngreso = cbxTipoIng.Text.Trim(),
                Tutores = txtTutor.Text.Trim(),
                TelefonoTutor = txtTETutor.Text.Trim(),
                MailTutor = txtMailTutor.Text.Trim(),
                DireccionTutor = txtDirTutor.Text.Trim(),
                LocalidadTutor = txtLocTutor.Text.Trim(),
                ProvinciaTutor = cbxProvTutor.Text.Trim(),
                CPTutor = txtCP.Text.Trim(),
                Estado = cbxEstado.Text.Trim(),
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

            if (!Tools.Validate(alumno.Individuo, out ICollection<ValidationResult> results))
                err_individuo += string.Join("\n\n", results.Select(o => o.ErrorMessage));

            if (!Tools.Validate(alumno, out results))
                err_alumno += string.Join("\n\n", results.Select(o => o.ErrorMessage));

            if (!string.IsNullOrWhiteSpace(err_alumno) || !string.IsNullOrWhiteSpace(err_individuo))
                IDDVSMsgBox.Show(err_individuo + "\n\n" + err_alumno, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
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

                            await servicioAlumno.Insertar(alumno);

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

                            await servicioAlumno.Modificar(alumno);

                            Cancelar();

                            IDDVSMsgBox.Show("Registro modificado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!(ex is ArgumentException))
                        RefreshAlumnoList();

                    IDDVSLoadingBox.Hide();
                    IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (IDDVSImportar.Show(new AlumnoImport()) != null)
                RefreshAlumnoList();
        }

        private void dgvAlumno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                AlumnoDTO selectedListRegister = alumnolList.FirstOrDefault(x => x.ID == (int)dgvAlumno.CurrentRow.Cells["ID"].Value);

                if (selectedListRegister != null)
                {
                    selectedAlumnoID = selectedListRegister.ID;
                    selectedIndividuoID = selectedListRegister.Individuo.ID;

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
                    cbxTipoIng.Text = selectedListRegister.TipoIngreso;
                    txtTutor.Text = selectedListRegister.Tutores;
                    txtTETutor.Text = selectedListRegister.TelefonoTutor;
                    txtMailTutor.Text = selectedListRegister.MailTutor;
                    txtDirTutor.Text = selectedListRegister.DireccionTutor;
                    txtLocTutor.Text = selectedListRegister.LocalidadTutor;
                    cbxProvTutor.Text = selectedListRegister.ProvinciaTutor;
                    txtCPTutor.Text = selectedListRegister.CPTutor;
                    cbxEstado.Text = selectedListRegister.Estado;

                    btnModificar.Select();
                }
                else
                    ClearData();
            }
            else
                ClearData();

        }

        private void frmAltaAlumno_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            Cancelar();

            btnNuevo.Focus();
        }

        private void txtBuscar__TextChanged(object sender, EventArgs e)
        {
            RefreshAlumnoDataGrid();
        }

        private void dgvAlumno_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvAlumno.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
                ClearData();
        }
    }
}
