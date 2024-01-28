using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public class RepositorioMatricula : RepositorioGenerico<Matricula>, IRepositorioMatricula
    {
        public RepositorioMatricula() : base(ContextoIDDVS.GetInstance())
        {

        }

        public async override Task<IEnumerable<Matricula>> ConsultarTodos()
        {
            return await contexto.Set<Matricula>().Include("Alumno").Include("Curso").Include("Grupo").Include("CicloLectivo").Where(x => !x.Eliminado).ToListAsync();
        }

        public async override Task<Matricula> ConsultarPorID(int ID)
        {
            return await contexto.Set<Matricula>().Include("Alumno").Include("Curso").Include("Grupo").Include("CicloLectivo").FirstOrDefaultAsync(x => !x.Eliminado && x.ID == ID);
        }

        public async Task<IEnumerable<Matricula>> ConsultarPorEstadoYCicloLectivo(string estado, int IDCicloLectivo)
        {
            return await contexto.Set<Matricula>().Include("Alumno").Include("Curso").Include("Grupo").Include("CicloLectivo").Where(x => !x.Eliminado && x.Estado.Equals(estado, System.StringComparison.OrdinalIgnoreCase) && x.CicloLectivo.ID == IDCicloLectivo).ToListAsync();
        }

        public async Task<IEnumerable<Matricula>> ConsultarPorEstadoGrupoYCicloLectivo(string estado, int IDGrupo, int IDCicloLectivo)
        {
            return await contexto.Set<Matricula>().Include("Alumno").Include("Curso").Include("Grupo").Include("CicloLectivo").Where(x => !x.Eliminado && x.Estado.Equals(estado, System.StringComparison.OrdinalIgnoreCase) && x.Grupo.ID == IDGrupo && x.CicloLectivo.ID == IDCicloLectivo).ToListAsync();
        }

        public async Task<IEnumerable<Matricula>> ConsultarPorEstadoAlumnoYCicloLectivo(string estado, int IDAlumno, int IDCicloLectivo)
        {
            return await contexto.Set<Matricula>().Include("Alumno").Include("Curso").Include("Grupo").Include("CicloLectivo").Where(x => !x.Eliminado && x.Estado.Equals(estado, System.StringComparison.OrdinalIgnoreCase) && x.Alumno.ID == IDAlumno && x.CicloLectivo.ID == IDCicloLectivo).ToListAsync();
        }
    }
}
