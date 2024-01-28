using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public class RepositorioMateria : RepositorioGenerico<Materia>, IRepositorioMateria
    {
        public RepositorioMateria() : base(ContextoIDDVS.GetInstance())
        {

        }

        public async override Task<IEnumerable<Materia>> ConsultarTodos()
        {
            return await contexto.Set<Materia>().Include("Curso").Include("Grupo").Include("CicloLectivo").Where(x => !x.Eliminado).ToListAsync();
        }

        public async override Task<Materia> ConsultarPorID(int ID)
        {
            return await contexto.Set<Materia>().Include("Curso").Include("Grupo").Include("CicloLectivo").FirstOrDefaultAsync(x => !x.Eliminado && x.ID == ID);
        }

        public async Task<Materia> ConsultarPorNombreIDGrupoYIDCicloLectivo(string nombre, int IDGrupo, int IDCicloLectivo)
        {
            return await contexto.Set<Materia>().Include("Curso").Include("Grupo").Include("CicloLectivo").FirstOrDefaultAsync(x => !x.Eliminado && x.Nombre == nombre && x.Grupo.ID == IDGrupo && x.CicloLectivo.ID == IDCicloLectivo);
        }

        public async Task<IEnumerable<Materia>> ConsultarPorIDCurso(int IDCurso)
        {
            return await contexto.Set<Materia>().Include("Curso").Include("Grupo").Include("CicloLectivo").Where(x => !x.Eliminado && x.Curso.ID == IDCurso).ToListAsync();
        }

        public async Task<IEnumerable<Materia>> ConsultarPorIDGrupo(int IDGrupo)
        {
            return await contexto.Set<Materia>().Include("Curso").Include("Grupo").Include("CicloLectivo").Where(x => !x.Eliminado && x.Grupo.ID == IDGrupo).ToListAsync();
        }

        public async Task<IEnumerable<Materia>> ConsultarPorIDCicloLectivo(int IDCicloLectivo)
        {
            return await contexto.Set<Materia>().Include("Curso").Include("Grupo").Include("CicloLectivo").Where(x => !x.Eliminado && x.CicloLectivo.ID == IDCicloLectivo).ToListAsync();
        }
    }
}
