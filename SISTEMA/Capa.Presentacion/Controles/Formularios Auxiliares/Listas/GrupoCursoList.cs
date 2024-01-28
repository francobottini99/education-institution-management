using Capa.Negocio.DTO;
using Capa.Negocio.Servicios.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Presentacion.Controles.Formularios_Auxiliares.Listas
{
    public class GrupoCursoList : IList
    {
        private string cursoName = "";

        public void LoadDataGrid(ref IDDVSDataGrid dgv, IEnumerable<IDTO> list, string filter = null)
        {
            IEnumerable<GrupoDTO> data;

            if (!string.IsNullOrWhiteSpace(filter))
                data = ((IEnumerable<GrupoDTO>)list).Where(g => g.Nombre.ToUpper().Contains(filter));
            else
                data = (IEnumerable<GrupoDTO>)list;

            dgv.Columns.Clear();
            dgv.Columns.Add("ID", "ID");
            dgv.Columns.Add("Grupo", "GRUPO");

            dgv.Columns["ID"].Visible = false;
            dgv.ColumnHeadersVisible = false;

            foreach (GrupoDTO grupo in data)
                dgv.Rows.Add(grupo.ID, grupo.Nombre);

            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        public async Task<IEnumerable<IDTO>> LoadList(object argument = null)
        {
            if(argument == null)
                throw new ArgumentException("No se especifico el ID del curso del cual se quieren mostrar los grupos");

            IDDVSLoadingBox.Show("CARGANDO LISTADO DE CURSOS");

            IEnumerable<GrupoDTO> list = (await new ServicioGrupo().ConsultarPorIDCurso((int)argument)).OrderBy(x => x.Curso.Numero).ThenBy(x => x.Curso.Division).ThenBy(x => x.Nombre);

            IDDVSLoadingBox.Hide();

            if (list.Count() > 0)
            {
                cursoName = list.First().Curso.Division == "-" ? list.First().Curso.Nombre : string.Concat(list.First().Curso.Nombre, " \"", list.First().Curso.Division, "\"");

                return list;
            }
            else
                throw new Exception("No hay cursos cargados en el sistema para el ciclo lectivo actual");
        }

        public override string ToString()
        {
            return string.Concat("LISTADO DE GRUPOS DEL CURSO: ", cursoName);
        }
    }
}
