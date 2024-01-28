using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public class RepositorioGrupo : RepositorioGenerico<Grupo>, IRepositorioGrupo
    {
        public RepositorioGrupo() : base(ContextoIDDVS.GetInstance())
        {

        }

        public async override Task<IEnumerable<Grupo>> ConsultarTodos()
        {
            return await contexto.Set<Grupo>().Include("CicloLectivo").Include("Curso").Where(x => !x.Eliminado).ToListAsync();
        }

        public async override Task<Grupo> ConsultarPorID(int ID)
        {
            return await contexto.Set<Grupo>().Include("CicloLectivo").Include("Curso").FirstOrDefaultAsync(x => !x.Eliminado && x.ID == ID);
        }

        public async Task<IEnumerable<Grupo>> ConsultarPorIDCicloLectivo(int IDCicloLectivo)
        {
            return await contexto.Set<Grupo>().Include("CicloLectivo").Include("Curso").Where(x => !x.Eliminado && x.CicloLectivo.ID == IDCicloLectivo).ToListAsync();
        }

        public async Task<Grupo> ConsultarPorNombreIDCursoYIDCicloLectivo(string nombre, int IDCurso, int IDCicloLectivo)
        {
            return await contexto.Set<Grupo>().Include("CicloLectivo").Include("Curso").FirstOrDefaultAsync(x => !x.Eliminado && x.Nombre == nombre && x.Curso.ID == IDCurso && x.CicloLectivo.ID == IDCicloLectivo);
        }

        public async Task<IEnumerable<Grupo>> ConsultarPorIDCurso(int IDCurso)
        {
            return await contexto.Set<Grupo>().Include("CicloLectivo").Include("Curso").Where(x => !x.Eliminado && x.Curso.ID == IDCurso).ToListAsync();
        }
    }
}
