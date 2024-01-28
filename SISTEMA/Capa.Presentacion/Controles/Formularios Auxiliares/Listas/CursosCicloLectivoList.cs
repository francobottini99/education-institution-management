using Capa.Negocio.Datos;
using Capa.Negocio.DTO;
using Capa.Negocio.Servicios.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Presentacion.Controles.Formularios_Auxiliares.Listas
{
    public class CursosCicloLectivoList : IList
    {
        public void LoadDataGrid(ref IDDVSDataGrid dgv,IEnumerable<IDTO> list,  string filter = null)
        {
            IEnumerable<CursoDTO> data;

            if (!string.IsNullOrWhiteSpace(filter))
                data = ((IEnumerable<CursoDTO>)list).Where(c => (c.Division == "-" ? c.Nombre : string.Concat(c.Nombre, " \"", c.Division, "\"")).Contains(filter));
            else
                data = (IEnumerable<CursoDTO>)list;

            dgv.Columns.Clear();
            dgv.Columns.Add("ID", "ID");
            dgv.Columns.Add("Nombre", "NOMBRE");

            dgv.Columns["ID"].Visible = false;
            dgv.ColumnHeadersVisible = false;

            foreach (CursoDTO curso in data)
                dgv.Rows.Add(curso.ID, curso.Division == "-" ? curso.Nombre : string.Concat(curso.Nombre, " \"", curso.Division, "\""));

            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        public async Task<IEnumerable<IDTO>> LoadList(object argument = null)
        {
            IDDVSLoadingBox.Show("CARGANDO LISTADO DE CURSOS");

            IEnumerable<CursoDTO> list = (await new ServicioCurso().ConsultarPorIDCicloLectivo(Cache.CicloLectivo.ID)).OrderBy(x => x.Numero).ThenBy(x => x.Division);

            IDDVSLoadingBox.Hide();

            if (list.Count() > 0)
                return list;
            else
                throw new Exception("No hay cursos cargados en el sistema para el ciclo lectivo actual");
        }

        public override string ToString()
        {
            return "LISTADO DE CURSOS - CICLO LECTIVO ACTUAL";
        }
    }
}
