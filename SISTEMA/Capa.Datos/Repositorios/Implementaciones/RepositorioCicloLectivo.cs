using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public class RepositorioCicloLectivo : RepositorioGenerico<CicloLectivo>, IRepositorioCicloLectivo
    {
        public RepositorioCicloLectivo() : base(ContextoIDDVS.GetInstance())
        {

        }

        public async Task<CicloLectivo> ConsultarPorAño(int año)
        {
            return await contexto.Set<CicloLectivo>().FirstOrDefaultAsync(x => !x.Eliminado && x.Año == año);
        }
    }
}
