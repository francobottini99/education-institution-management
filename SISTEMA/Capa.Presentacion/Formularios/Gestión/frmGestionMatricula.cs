using Capa.Negocio.Datos;
using Capa.Negocio.DTO;
using Capa.Negocio.Servicios;
using Capa.Negocio.Servicios.Implementacion;
using Capa.Presentacion.Controles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Capa.Presentacion.Formularios.Gestión
{
    public partial class frmGestionMatricula : Form
    {
        private static frmGestionMatricula instance;

        private static readonly object _lock = new object();

        private IEnumerable<GrupoDTO> grupoList;

        private List<AlumnoDTO> alumnoList;
        private List<MatriculaDTO> matriculasGrupoList;

        private readonly IServicioGrupo servicioGrupo;
        private readonly IServicioAlumno servicioAlumno;
        private readonly IServicioMatricula servicioMatricula;

        private GrupoDTO selectedGrupo;

        public static frmGestionMatricula GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new frmGestionMatricula();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private frmGestionMatricula()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            servicioGrupo = new ServicioGrupo();
            servicioAlumno = new ServicioAlumno();
            servicioMatricula = new ServicioMatricula();
        }

        private void frmGestionMatricula_Shown(object sender, EventArgs e)
        {
            pnlAlumnos.Height = (pnlDatos.Height - pnlCurso.Height) / 2;
            pnlMatriculas.Height = (pnlDatos.Height - pnlCurso.Height) / 2;

            Application.DoEvents();

            Cancelar();

            btnMatricular.Select();
        }

        private void frmGestionMatricula_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void Cancelar()
        {
            dgvAlumnos.Enabled = false;
            dgvMatriculas.Enabled = false;
            dgvCursos.Enabled = true;
            txtBuscarCurso.Enabled = true;

            selectedGrupo = null;

            rdbSinMatricular.Checked = false;
            rdbTodos.Checked = false;

            ClearData();

            txtBuscarAlumno.Enabled = false;

            txtBuscarCurso.Text = "";

            btnMatricular.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;

            Application.DoEvents();

            RefreshGrupoList();

            btnMatricular.Select();
        }

        private void Activar()
        {
            dgvAlumnos.Enabled = true;
            dgvMatriculas.Enabled = true;
            dgvCursos.Enabled = false;
            txtBuscarCurso.Enabled = false;

            rdbSinMatricular.Enabled = true;
            rdbTodos.Enabled = true;

            txtBuscarAlumno.Enabled = true;

            btnMatricular.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

            Application.DoEvents();

            rdbSinMatricular.Checked = true;
            rdbSinMatricular.Select();
        }

        private void ClearData()
        {
            txtBuscarAlumno.Text = "";

            dgvMatriculas.Rows.Clear();
            dgvMatriculas.Columns.Clear();

            dgvCursos.ClearSelection();
            dgvCursos.CurrentCell = null;

            dgvAlumnos.Rows.Clear();
            dgvAlumnos.Columns.Clear();

            txtCurso.Text = "";
            txtGrupo.Text = "";
        }

        private async void RefreshGrupoList()
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE CURSOS");

            grupoList = (await servicioGrupo.ConsultarPorIDCicloLectivo(Cache.CicloLectivo.ID)).OrderBy(x => x.Curso.Numero).ThenBy(x => x.Curso.Division).ThenBy(x => x.Nombre);

            RefreshCursoDataGrid();

            IDDVSLoadingBox.Hide();
        }

        private async void RefreshMatriculasList()
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE MATRICULAS");

            matriculasGrupoList = (await servicioMatricula.ConsultarActivasGrupo(selectedGrupo.ID, Cache.CicloLectivo.ID)).OrderBy(x => x.Alumno.Individuo.Apellidos).ThenBy(x => x.Alumno.Individuo.Nombres).ThenBy(x => x.Alumno.Individuo.DNI).ToList(); ;

            RefreshMatriculaDataGrid();

            IDDVSLoadingBox.Hide();
        }

        private async void RefreshAlumnoList()
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE ALUMNOS");

            IEnumerable<AlumnoDTO> data;

            if (rdbSinMatricular.Checked)
                data = await servicioAlumno.ConsultarActivosSinMatricular(Cache.CicloLectivo.ID);
            else
                data = await servicioAlumno.ConsultarActivos();

            alumnoList = data.OrderBy(x => x.Individuo.Apellidos).ThenBy(x => x.Individuo.Nombres).ToList();

            foreach (MatriculaDTO matricula in matriculasGrupoList)
                if (alumnoList.Contains(matricula.Alumno))
                    alumnoList.Remove(matricula.Alumno);

            RefreshAlumnoDataGrid();

            IDDVSLoadingBox.Hide();
        }

        private void RefreshAlumnoDataGrid()
        {
            if (alumnoList == null)
                return;

            IEnumerable<AlumnoDTO> data;

            if (!string.IsNullOrWhiteSpace(txtBuscarAlumno.Text))
                data = alumnoList.Where(p => string.Concat(p.Individuo.Apellidos, ", ", p.Individuo.Nombres).Contains(txtBuscarAlumno.Text));
            else
                data = alumnoList;

            int scrollIndex = dgvAlumnos.FirstDisplayedScrollingRowIndex;

            dgvAlumnos.Columns.Clear();

            dgvAlumnos.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "AddButton",
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                Width = 40,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
 
            dgvAlumnos.Columns.Add("ID", "ID");
            dgvAlumnos.Columns.Add("Nombre_Apellido", "NOMBRE Y APELLIDO");

            dgvAlumnos.Columns["ID"].Visible = false;
            dgvAlumnos.ColumnHeadersVisible = false;

            foreach (AlumnoDTO alumno in data)
                dgvAlumnos.Rows.Add("+", alumno.ID, alumno.Individuo.Apellidos + ", " + alumno.Individuo.Nombres);

            if (dgvAlumnos.Rows.Count > 0)
                dgvAlumnos.FirstDisplayedScrollingRowIndex = scrollIndex > 0 ? scrollIndex : 0;
        }

        private void RefreshCursoDataGrid()
        {
            if (grupoList == null)
                return;

            IEnumerable<GrupoDTO> data;

            if (!string.IsNullOrWhiteSpace(txtBuscarCurso.Text))
                data = grupoList.Where(g => g.Nombre.ToUpper().Contains(txtBuscarCurso.Text));
            else
                data = grupoList;

            dgvCursos.Columns.Clear();
            dgvCursos.Columns.Add("ID", "ID");
            dgvCursos.Columns.Add("Curso", "CURSO");
            dgvCursos.Columns.Add("Nombre", "NOMBRE");

            dgvCursos.Columns["ID"].Visible = false;
            dgvCursos.ColumnHeadersVisible = false;

            foreach (GrupoDTO grupo in data)
                dgvCursos.Rows.Add(grupo.ID, grupo.Curso.Division == "-" ? grupo.Curso.Nombre : string.Concat(grupo.Curso.Nombre, " \"", grupo.Curso.Division, "\""), grupo.Nombre);

            ClearData();
        }

        private void RefreshMatriculaDataGrid()
        {
            if (matriculasGrupoList == null)
                return;

            IEnumerable<MatriculaDTO> data;

            if (!string.IsNullOrWhiteSpace(txtBuscarMatricula.Text))
                data = matriculasGrupoList.Where(m => string.Concat(m.Alumno.Individuo.Apellidos, ", ", m.Alumno.Individuo.Nombres).Contains(txtBuscarMatricula.Text));
            else
                data = matriculasGrupoList;

            int scrollIndex = dgvMatriculas.FirstDisplayedScrollingRowIndex;

            dgvMatriculas.Columns.Clear();

            dgvMatriculas.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "RemoveButton",
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                Width = 40,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            dgvMatriculas.Columns.Add("ID", "ID");
            dgvMatriculas.Columns.Add("IDAlumno", "ID ALUMNO");
            dgvMatriculas.Columns.Add("Nombre_Apellido", "NOMBRE Y APELLIDO");
            dgvMatriculas.Columns.Add("Numero", "NÚMERO");

            dgvMatriculas.Columns["Numero"].Width = 100;
            dgvMatriculas.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMatriculas.Columns["Numero"].DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter };

            dgvMatriculas.Columns["ID"].Visible = false;
            dgvMatriculas.Columns["IDAlumno"].Visible = false;

            dgvMatriculas.ColumnHeadersVisible = false;

            foreach (MatriculaDTO matricula in data)
                dgvMatriculas.Rows.Add("-", matricula.ID, matricula.Alumno.ID, matricula.Alumno.Individuo.Apellidos + ", " + matricula.Alumno.Individuo.Nombres, matricula.Alumno.Individuo.DNI);

            if(dgvMatriculas.Rows.Count > 0)
                dgvMatriculas.FirstDisplayedScrollingRowIndex = scrollIndex > 0 ? scrollIndex : 0;
        }

        private void dgvCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
               selectedGrupo = grupoList.FirstOrDefault(x => x.ID == (int)dgvCursos.CurrentRow.Cells["ID"].Value);

                if (selectedGrupo != null)
                {
                    txtCurso.Text = selectedGrupo.Curso.Division == "-" ? selectedGrupo.Curso.Nombre : string.Concat(selectedGrupo.Curso.Nombre, " \"", selectedGrupo.Curso.Division, "\"");
                    txtGrupo.Text = selectedGrupo.Nombre;

                    RefreshMatriculasList();

                    btnMatricular.Select();
                }
                else
                    ClearData();
            }
            else
                ClearData();
        }

        private async void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAlumnos.Columns["AddButton"].Index && e.RowIndex > -1)
            {
                AlumnoDTO selectedAlumno = alumnoList.FirstOrDefault(x => x.ID == (int)dgvAlumnos.CurrentRow.Cells["ID"].Value);

                if (selectedAlumno != null)
                {
                    MatriculaDTO aux = await servicioMatricula.ConsultarActivaAlumno(selectedAlumno.ID, Cache.CicloLectivo.ID);

                    matriculasGrupoList.Add(new MatriculaDTO
                    {
                        ID = aux != null ? aux.ID : 0,
                        Numero = selectedAlumno.Individuo.DNI,
                        Alumno = selectedAlumno,
                        Curso = selectedGrupo.Curso,
                        Grupo = selectedGrupo,
                        CicloLectivo = Cache.CicloLectivo,
                    });

                    alumnoList.Remove(selectedAlumno);

                    matriculasGrupoList = matriculasGrupoList.OrderBy(x => x.Alumno.Individuo.Apellidos).ThenBy(x => x.Alumno.Individuo.Nombres).ThenBy(x => x.Alumno.Individuo.DNI).ToList();

                    RefreshAlumnoDataGrid();
                    RefreshMatriculaDataGrid();
                }
            }
        }

        private void dgvMatriculas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMatriculas.Columns["RemoveButton"].Index && e.RowIndex > -1)
            {
                MatriculaDTO selectedMatricula = matriculasGrupoList.FirstOrDefault(x => x.Alumno.ID == (int)dgvMatriculas.CurrentRow.Cells["IDAlumno"].Value);

                if (selectedMatricula != null)
                {
                    matriculasGrupoList.Remove(selectedMatricula);
                    alumnoList.Add(selectedMatricula.Alumno);

                    alumnoList = alumnoList.OrderBy(x => x.Individuo.Apellidos).ThenBy(x => x.Individuo.Nombres).ToList();

                    RefreshAlumnoDataGrid();
                    RefreshMatriculaDataGrid();
                }
            }
        }

        private void dgvCursos_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvCursos.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
                ClearData();
        }

        private void txtBuscarCurso__TextChanged(object sender, EventArgs e)
        {
            RefreshCursoDataGrid();
        }

        private void txtBuscarAlumno__TextChanged(object sender, EventArgs e)
        {
            RefreshAlumnoDataGrid();
        }

        private void txtBuscarMatricula__TextChanged(object sender, EventArgs e)
        {
            RefreshMatriculaDataGrid();
        }

        private void rdbSinMatricular_CheckedChanged(object sender, EventArgs e)
        {
            RefreshAlumnoList();
        }

        private void pbxX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnMatricular_Click(object sender, EventArgs e)
        {
            if (selectedGrupo != null)
                Activar();
            else
                IDDVSMsgBox.Show("Debes seleccionar del listado el grupo en el cual quieres matricular !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (await servicioMatricula.ExistenCambios(matriculasGrupoList, selectedGrupo))
            {
                try
                {
                    DialogResult response = IDDVSMsgBox.Show("Seguro que deseas guardar ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                    if (response == DialogResult.OK)
                    {
                        IDDVSLoadingBox.Show("GUARDANDO");

                        await servicioMatricula.ActualizarMatriculas(matriculasGrupoList, selectedGrupo, DateTime.Now);

                        Cancelar();

                        IDDVSMsgBox.Show("Guardado con exito !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
                    }
                }
                catch (Exception ex)
                {
                    IDDVSLoadingBox.Hide();
                    IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                }
            }
            else
                IDDVSMsgBox.Show("No hay ningun cambio para guardar !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
        }
    }
}
