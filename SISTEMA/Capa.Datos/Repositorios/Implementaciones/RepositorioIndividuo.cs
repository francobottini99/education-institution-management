using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public class RepositorioIndividuo : RepositorioGenerico<Individuo>, IRepositorioIndividuo
    {
        public RepositorioIndividuo() : base(ContextoIDDVS.GetInstance())
        {
            
        }

        public async Task<Individuo> ConsultarPorDNI(string DNI)
        {
            return await contexto.Set<Individuo>().FirstOrDefaultAsync(x => !x.Eliminado && x.DNI == DNI);
        }
    }
}
