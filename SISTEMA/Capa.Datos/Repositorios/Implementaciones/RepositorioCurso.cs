using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public class RepositorioCurso : RepositorioGenerico<Curso>, IRepositorioCurso
    {
        public RepositorioCurso() : base(ContextoIDDVS.GetInstance())
        {

        }

        public async override Task<IEnumerable<Curso>> ConsultarTodos()
        {
            return await contexto.Set<Curso>().Include("CicloLectivo").Where(x => !x.Eliminado).ToListAsync();
        }

        public async override Task<Curso> ConsultarPorID(int ID)
        {
            return await contexto.Set<Curso>().Include("CicloLectivo").FirstOrDefaultAsync(x => !x.Eliminado && x.ID == ID);
        }

        public async Task<Curso> ConsultarPorNumeroDivisionYIDCicloLectivo(int numero, string division, int IDCicloLectivo)
        {
            return await contexto.Set<Curso>().Include("CicloLectivo").FirstOrDefaultAsync(x => !x.Eliminado && x.Numero == numero && x.Division == division && x.CicloLectivo.ID == IDCicloLectivo);
        }

        public async Task<IEnumerable<Curso>> ConsultarPorIDCicloLectivo(int IDCicloLectivo)
        {
            return await contexto.Set<Curso>().Include("CicloLectivo").Where(x => !x.Eliminado && x.CicloLectivo.ID == IDCicloLectivo).ToListAsync();
        }
    }
}
