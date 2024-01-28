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
using Capa.Negocio.Datos;

namespace Capa.Presentacion.Formularios.Altas
{
    public partial class frmAltaCurso : Form
    {
        private static frmAltaCurso instance;

        private static readonly object _lock = new object();

        private readonly IServicioCurso servicioCurso;
        private IEnumerable<CursoDTO> cursoList;
        private int selectedCursoID;
        private WritingOperations operation;

        public static frmAltaCurso GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new frmAltaCurso();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private frmAltaCurso()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            servicioCurso = new ServicioCurso();
        }

        private void frmAltaCurso_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            Cancelar();

            btnNuevo.Select();
        }

        private void frmAltaCurso_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void Cancelar()
        {
            dgvCursos.Enabled = true;
            txtBuscar.Enabled = true;

            cbxDivisionCurso.Enabled = false;
            cbxNumCurso.Enabled = false;

            txtBuscar.Text = "";

            ClearData();

            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;

            Application.DoEvents();

            RefreshCursoList();

            btnNuevo.Focus();
        }

        private void Activar()
        {
            dgvCursos.Enabled = false;
            txtBuscar.Enabled = false;

            cbxDivisionCurso.Enabled = true;
            cbxNumCurso.Enabled = true;

            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;

            cbxNumCurso.Select();
        }

        private void ClearData()
        {
            selectedCursoID = -1;

            dgvCursos.ClearSelection();
            dgvCursos.CurrentCell = null;

            txtNombreCurso.Text = "";
            cbxNumCurso.Text = "";
            cbxDivisionCurso.Text = "";
        }

        private async void RefreshCursoList()
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE CURSOS");

            cursoList = (await servicioCurso.ConsultarPorIDCicloLectivo(Cache.CicloLectivo.ID)).OrderBy(x => x.Numero).ThenBy(x => x.Division);

            RefreshCursoDataGrid();

            IDDVSLoadingBox.Hide();
        }

        private void RefreshCursoDataGrid()
        {
            if (cursoList == null)
                return;

            IEnumerable<CursoDTO> data;

            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
                data = cursoList.Where(c => (c.Division == "-" ? c.Nombre : string.Concat(c.Nombre, " \"", c.Division, "\"")).Contains(txtBuscar.Text));
            else
                data = cursoList;

            dgvCursos.Columns.Clear();
            dgvCursos.Columns.Add("ID", "ID");
            dgvCursos.Columns.Add("Nombre", "NOMBRE");

            dgvCursos.Columns["ID"].Visible = false;
            dgvCursos.ColumnHeadersVisible = false;

            foreach (CursoDTO curso in data)
                dgvCursos.Rows.Add(curso.ID, curso.Division == "-" ? curso.Nombre : string.Concat(curso.Nombre, " \"", curso.Division, "\""));

            ClearData();
        }

        private void dgvCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                CursoDTO selectedListRegister = cursoList.FirstOrDefault(x => x.ID == (int)dgvCursos.CurrentRow.Cells["ID"].Value);

                if (selectedListRegister != null)
                {
                    selectedCursoID = selectedListRegister.ID;

                    txtNombreCurso.Text = selectedListRegister.Nombre;
                    cbxDivisionCurso.Text = selectedListRegister.Division == "-" ? "UNICA" : selectedListRegister.Division;
                    cbxNumCurso.Text = selectedListRegister.Numero.ToString();

                    btnModificar.Select();
                }
                else
                    ClearData();
            }
            else
                ClearData();
        }

        private void dgvCursos_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvCursos.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
                ClearData();
        }

        private void txtBuscar__TextChanged(object sender, EventArgs e)
        {
            RefreshCursoDataGrid();
        }

        private void cbxNumCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(int.Parse(cbxNumCurso.Text.Trim()))
            {
                case 1:
                    txtNombreCurso.Text = "PRIMER AÑO";
                    break;
                case 2:
                    txtNombreCurso.Text = "SEGUNDO AÑO";
                    break;
                case 3:
                    txtNombreCurso.Text = "TERCER AÑO";
                    break;
                case 4:
                    txtNombreCurso.Text = "CUARTO AÑO";
                    break;
                case 5:
                    txtNombreCurso.Text = "QUINTO AÑO";
                    break;
                case 6:
                    txtNombreCurso.Text = "SEXTO AÑO";
                    break;
                case 7:
                    txtNombreCurso.Text = "SEPTIMO AÑO";
                    break;
                case 8:
                    txtNombreCurso.Text = "OCTAVO AÑO";
                    break;
                case 9:
                    txtNombreCurso.Text = "NOVENO AÑO";
                    break;
            }
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

            cbxNumCurso.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (selectedCursoID != -1)
            {
                Activar();

                operation = WritingOperations.UPDATE;

                cbxNumCurso.Select();
            }
            else
                IDDVSMsgBox.Show("Debes seleccionar del listado el registro que deseas modificar !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedCursoID != -1)
            {
                DialogResult response = IDDVSMsgBox.Show("Seguro que deseas eliminar el registro ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                if (response == DialogResult.OK)
                {
                    if (await servicioCurso.ExistenGruposAsociadoAlCurso(selectedCursoID))
                        response = IDDVSMsgBox.Show("Existen grupos asociados al curso que quieres eliminar. Si continuas con la operacion, todos los grupos asociados al curso seran eliminados. Continuar de todas formas ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                    if (response == DialogResult.OK)
                    {
                        try
                        {
                            IDDVSLoadingBox.Show("ELIMINANDO REGISTRO");

                            await servicioCurso.Eliminar(selectedCursoID);

                            RefreshCursoList();

                            IDDVSMsgBox.Show("Registro eliminado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                        }
                        catch (Exception ex)
                        {
                            if (!(ex is ArgumentException))
                                RefreshCursoList();

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
            CursoDTO curso = new CursoDTO
            {
                ID = selectedCursoID > 0 ? selectedCursoID : 0,
                Numero = string.IsNullOrWhiteSpace(cbxNumCurso.Text.Trim()) ? 0 : int.Parse(cbxNumCurso.Text.Trim()),
                Division = cbxDivisionCurso.Text.Trim() == "UNICA" ? "-" : cbxDivisionCurso.Text.Trim(),
                Nombre = txtNombreCurso.Text.Trim(),
                CicloLectivo = Cache.CicloLectivo
            };

            if (!Tools.Validate(curso, out ICollection<ValidationResult> results))
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

                            await servicioCurso.Insertar(curso);

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

                            await servicioCurso.Modificar(curso);

                            Cancelar();

                            IDDVSMsgBox.Show("Registro modificado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!(ex is ArgumentException))
                        RefreshCursoList();

                    IDDVSLoadingBox.Hide();
                    IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                }
            }
        }
    }
}
