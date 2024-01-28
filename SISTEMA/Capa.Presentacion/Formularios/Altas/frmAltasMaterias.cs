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
    public partial class frmAltasMaterias : Form
    {
        private static frmAltasMaterias instance;

        private static readonly object _lock = new object();

        private readonly IServicioMateria servicioMateria;
        private readonly IServicioGrupo servicioGrupo;
        private IEnumerable<MateriaDTO> materiaList;
        private CursoDTO selectedCurso;
        private GrupoDTO selectedGrupo;
        private int selectedMateriaID;
        private WritingOperations operation;

        public static frmAltasMaterias GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new frmAltasMaterias();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private frmAltasMaterias()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            servicioMateria = new ServicioMateria();
            servicioGrupo = new ServicioGrupo();
        }

        private void frmAltasMaterias_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            Cancelar();

            btnNuevo.Select();
        }

        private void frmAltasMaterias_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void Cancelar()
        {
            dgvMaterias.Enabled = true;
            txtBuscar.Enabled = true;

            txtNombreMateria.Enabled = false;
            txtHoras.Enabled = false;
            btnBuscarCurso.Enabled = false;
            btnBuscarGrupo.Enabled = false;

            txtBuscar.Text = "";

            ClearData();

            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;

            Application.DoEvents();

            RefreshMateriaList();

            btnNuevo.Select();
        }

        private void Activar()
        {
            dgvMaterias.Enabled = false;
            txtBuscar.Enabled = false;

            txtNombreMateria.Enabled = true;
            txtHoras.Enabled = true;
            btnBuscarCurso.Enabled = true;

            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;

            txtNombreMateria.Select();
        }

        private void ClearData()
        {
            selectedGrupo = null;
            selectedCurso = null;
            selectedMateriaID = -1;

            dgvMaterias.ClearSelection();
            dgvMaterias.CurrentCell = null;

            txtNombreMateria.Text = "";
            txtHoras.Text = "";
            txtCurso.Text = "";
            txtGrupo.Text = "";
        }

        private async void RefreshMateriaList()
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE MATERIAS");

            materiaList = (await servicioMateria.ConsultarPorIDCicloLectivo(Cache.CicloLectivo.ID)).OrderBy(x => x.Curso.Numero).ThenBy(x => x.Curso.Division).ThenBy(x => x.Grupo.Nombre).ThenBy(x => x.Nombre);

            RefreshMateriaDataGrid();

            IDDVSLoadingBox.Hide();
        }

        private void RefreshMateriaDataGrid()
        {
            if (materiaList == null)
                return;

            IEnumerable<MateriaDTO> data;

            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
                data = materiaList.Where(m => m.Nombre.ToUpper().Contains(txtBuscar.Text));
            else
                data = materiaList;

            dgvMaterias.Columns.Clear();
            dgvMaterias.Columns.Add("ID", "ID");
            dgvMaterias.Columns.Add("Curso", "CURSO");
            dgvMaterias.Columns.Add("Grupo", "GRUPO");
            dgvMaterias.Columns.Add("Nombre", "NOMBRE");

            dgvMaterias.Columns["ID"].Visible = false;
            dgvMaterias.ColumnHeadersVisible = false;

            dgvMaterias.Columns["Curso"].Width = 120;
            dgvMaterias.Columns["Grupo"].Width = 80;

            foreach (MateriaDTO materia in data)
                dgvMaterias.Rows.Add(materia.ID, materia.Curso.Division == "-" ? materia.Curso.Nombre : string.Concat(materia.Curso.Nombre, " \"", materia.Curso.Division, "\""), materia.Grupo.Nombre,materia.Nombre);

            ClearData();
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                MateriaDTO selectedListRegister = materiaList.FirstOrDefault(x => x.ID == (int)dgvMaterias.CurrentRow.Cells["ID"].Value);

                if (selectedListRegister != null)
                {
                    selectedMateriaID = selectedListRegister.ID;
                    selectedCurso = selectedListRegister.Curso;
                    selectedGrupo = selectedListRegister.Grupo;

                    txtNombreMateria.Text = selectedListRegister.Nombre;
                    txtHoras.Text = selectedListRegister.HorasCatedra.ToString();
                    txtCurso.Text = selectedListRegister.Curso.Division == "-" ? selectedListRegister.Curso.Nombre : string.Concat(selectedListRegister.Curso.Nombre, " \"", selectedListRegister.Curso.Division, "\"");
                    txtGrupo.Text = selectedListRegister.Grupo.Nombre;

                    btnModificar.Select();
                }
                else
                    ClearData();
            }
            else
                ClearData();
        }

        private void dgvMaterias_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvMaterias.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
                ClearData();
        }

        private void txtBuscar__TextChanged(object sender, EventArgs e)
        {
            RefreshMateriaDataGrid();
        }

        private async void btnBuscarCurso_Click(object sender, EventArgs e)
        {
            var curso = IDDVSList.Show<CursoDTO>(new CursosCicloLectivoList());

            if (curso != null)
            {
                txtCurso.Text = curso.Division == "-" ? curso.Nombre : string.Concat(curso.Nombre, " \"", curso.Division, "\"");
                selectedCurso = curso;

                var gruposAsociados = await servicioGrupo.ConsultarPorIDCurso(curso.ID);

                if (gruposAsociados.Count() > 1)
                {
                    btnBuscarGrupo.Enabled = true;
                    txtGrupo.Text = "";
                    selectedGrupo = null;
                }
                else
                {
                    btnBuscarGrupo.Enabled = false;
                    selectedGrupo = gruposAsociados.First();
                    txtGrupo.Text = selectedGrupo.Nombre;
                }
            }
        }

        private void btnBuscarGrupo_Click(object sender, EventArgs e)
        {
            var grupo = IDDVSList.Show<GrupoDTO>(new GrupoCursoList(), selectedCurso.ID);

            if (grupo != null)
            {
                txtGrupo.Text = grupo.Nombre;
                selectedGrupo = grupo;
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

            txtNombreMateria.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (selectedMateriaID != -1)
            {
                var gruposAsociados = await servicioGrupo.ConsultarPorIDCurso(selectedCurso.ID);

                if (gruposAsociados.Count() > 1)
                    btnBuscarGrupo.Enabled = true;

                Activar();

                operation = WritingOperations.UPDATE;

                txtNombreMateria.Select();
            }
            else
                IDDVSMsgBox.Show("Debes seleccionar del listado el registro que deseas modificar !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedMateriaID != -1)
            {
                DialogResult response = IDDVSMsgBox.Show("Seguro que deseas eliminar el registro ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                if (response == DialogResult.OK)
                {
                    try
                    {
                        IDDVSLoadingBox.Show("ELIMINANDO REGISTRO");

                        await servicioMateria.Eliminar(selectedMateriaID);

                        RefreshMateriaList();

                        IDDVSMsgBox.Show("Registro eliminado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                    }
                    catch (Exception ex)
                    {
                        if (!(ex is ArgumentException))
                            RefreshMateriaList();

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
            if (selectedCurso == null)
            {
                IDDVSMsgBox.Show("Se debe seleccionar un curso para la materia", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                return;
            }

            if (selectedGrupo == null)
            {
                IDDVSMsgBox.Show("Se debe seleccionar un grupo para la materia", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                return;
            }

            MateriaDTO materia = new MateriaDTO
            {
                ID = selectedMateriaID > 0 ? selectedMateriaID : 0,
                Nombre = txtNombreMateria.Text.Trim(),
                HorasCatedra = string.IsNullOrWhiteSpace(txtHoras.Text) ? 0 : int.Parse(txtHoras.Text),
                Curso = selectedCurso,
                Grupo = selectedGrupo,
                CicloLectivo = Cache.CicloLectivo
            };

            if (!Tools.Validate(materia, out ICollection<ValidationResult> results))
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

                            await servicioMateria.Insertar(materia);

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

                            await servicioMateria.Modificar(materia);

                            Cancelar();

                            IDDVSMsgBox.Show("Registro modificado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!(ex is ArgumentException))
                        RefreshMateriaList();

                    IDDVSLoadingBox.Hide();
                    IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                }
            }
        }
    }
}
