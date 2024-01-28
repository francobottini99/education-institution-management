using Capa.Negocio.Datos;
using Capa.Negocio.DTO;
using Capa.Negocio.Servicios;
using Capa.Negocio.Servicios.Implementacion;
using Capa.Presentacion.Controles;
using Capa.Presentacion.Controles.Formularios_Auxiliares;
using Capa.Presentacion.Controles.Formularios_Auxiliares.Listas;
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
    public partial class frmAltaGrupos : Form
    {
        private static frmAltaGrupos instance;

        private static readonly object _lock = new object();

        private readonly IServicioGrupo servicioGrupo;
        private IEnumerable<GrupoDTO> grupoList;
        private CursoDTO selectedCurso;
        private int selectedGrupoID;
        private WritingOperations operation;

        public static frmAltaGrupos GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new frmAltaGrupos();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private frmAltaGrupos()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            servicioGrupo = new ServicioGrupo();
        }

        private void frmAltaGrupos_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            Cancelar();

            btnNuevo.Select();
        }

        private void frmAltaGrupos_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void Cancelar()
        {
            dgvGrupos.Enabled = true;
            txtBuscar.Enabled = true;

            btnBuscarCurso.Enabled = false;
            txtNombreGrupo.Enabled = false;

            txtBuscar.Text = "";

            ClearData();

            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;

            Application.DoEvents();

            RefreshGrupoList();

            btnNuevo.Select();
        }

        private void Activar()
        {
            dgvGrupos.Enabled = false;
            txtBuscar.Enabled = false;

            btnBuscarCurso.Enabled = true;
            txtNombreGrupo.Enabled = true;

            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;

            txtNombreGrupo.Select();
        }

        private void ClearData()
        {
            selectedCurso = null;
            selectedGrupoID = -1;

            dgvGrupos.ClearSelection();
            dgvGrupos.CurrentCell = null;

            txtNombreGrupo.Text = "";
            txtCurso.Text = "";
        }

        private async void RefreshGrupoList()
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE GRUPOS");

            grupoList = (await servicioGrupo.ConsultarPorIDCicloLectivo(Cache.CicloLectivo.ID)).OrderBy(x => x.Curso.Numero).ThenBy(x => x.Curso.Division).ThenBy(x => x.Nombre);

            RefreshGrupoDataGrid();

            IDDVSLoadingBox.Hide();
        }

        private void RefreshGrupoDataGrid()
        {
            if (grupoList == null)
                return;

            IEnumerable<GrupoDTO> data;

            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
                data = grupoList.Where(g => g.Nombre.ToUpper().Contains(txtBuscar.Text) && g.Nombre != "GENERAL");
            else
                data = grupoList.Where(g => g.Nombre != "GENERAL");

            dgvGrupos.Columns.Clear();
            dgvGrupos.Columns.Add("ID", "ID");
            dgvGrupos.Columns.Add("Curso", "CURSO");
            dgvGrupos.Columns.Add("Nombre", "NOMBRE");

            dgvGrupos.Columns["ID"].Visible = false;
            dgvGrupos.ColumnHeadersVisible = false;

            foreach (GrupoDTO grupo in data)
                dgvGrupos.Rows.Add(grupo.ID, grupo.Curso.Division == "-" ? grupo.Curso.Nombre : string.Concat(grupo.Curso.Nombre, " \"", grupo.Curso.Division, "\""), grupo.Nombre);

            ClearData();
        }

        private void dgvGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GrupoDTO selectedListRegister = grupoList.FirstOrDefault(x => x.ID == (int)dgvGrupos.CurrentRow.Cells["ID"].Value);

                if (selectedListRegister != null)
                {
                    selectedGrupoID = selectedListRegister.ID;
                    selectedCurso = selectedListRegister.Curso;

                    txtNombreGrupo.Text = selectedListRegister.Nombre;
                    txtCurso.Text = selectedListRegister.Curso.Division == "-" ? selectedListRegister.Curso.Nombre : string.Concat(selectedListRegister.Curso.Nombre, " \"", selectedListRegister.Curso.Division, "\"");

                    btnModificar.Select();
                }
                else
                    ClearData();
            }
            else
                ClearData();
        }

        private void dgvGrupos_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvGrupos.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
                ClearData();
        }

        private void txtBuscar__TextChanged(object sender, EventArgs e)
        {
            RefreshGrupoDataGrid();
        }

        private void btnBuscarCurso_Click(object sender, EventArgs e)
        {
            var curso = IDDVSList.Show<CursoDTO>(new CursosCicloLectivoList());

            if (curso != null)
            {
                txtCurso.Text = curso.Division == "-" ? curso.Nombre : string.Concat(curso.Nombre, " \"", curso.Division, "\"");
                selectedCurso = curso;
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

            txtNombreGrupo.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (selectedGrupoID != -1)
            {
                Activar();

                operation = WritingOperations.UPDATE;

                txtNombreGrupo.Select();
            }
            else
                IDDVSMsgBox.Show("Debes seleccionar del listado el registro que deseas modificar !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedGrupoID != -1)
            {
                DialogResult response = IDDVSMsgBox.Show("Seguro que deseas eliminar el registro ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                if (response == DialogResult.OK)
                {
                    if (await servicioGrupo.ExistenRegistrosAsociadosAlGrupo(selectedGrupoID))
                        response = IDDVSMsgBox.Show("Existen registros asociados al grupo que quieres eliminar. Si continuas con la operacion, todos los registros asociados al grupo a eliminar seran trasladados al grupo \"GENERAL\" del curso. Continuar de todas formas ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                    if (response == DialogResult.OK)
                    {
                        try
                        {
                            IDDVSLoadingBox.Show("ELIMINANDO REGISTRO");

                            await servicioGrupo.Eliminar(selectedGrupoID);

                            RefreshGrupoList();

                            IDDVSMsgBox.Show("Registro eliminado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                        }
                        catch (Exception ex)
                        {
                            if (!(ex is ArgumentException))
                                RefreshGrupoList();

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
            if (selectedCurso == null)
            {
                IDDVSMsgBox.Show("Se debe seleccionar un curso para el grupo", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                return;
            }

            GrupoDTO grupo = new GrupoDTO
            {
                ID = selectedGrupoID > 0 ? selectedGrupoID : 0,
                Nombre = txtNombreGrupo.Text.Trim(),
                Curso = selectedCurso,
                CicloLectivo = Cache.CicloLectivo
            };

            if (!Tools.Validate(grupo, out ICollection<ValidationResult> results))
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

                            await servicioGrupo.Insertar(grupo);

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

                            await servicioGrupo.Modificar(grupo);

                            Cancelar();

                            IDDVSMsgBox.Show("Registro modificado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!(ex is ArgumentException))
                        RefreshGrupoList();

                    IDDVSLoadingBox.Hide();
                    IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                }
            }
        }
    }
}
