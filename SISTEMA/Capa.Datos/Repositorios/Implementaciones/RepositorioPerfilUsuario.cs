using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public class RepositorioPerfilUsuario : RepositorioGenerico<PerfilUsuario>, IRepositorioPerfilUsuario
    {
        public RepositorioPerfilUsuario() :base(ContextoIDDVS.GetInstance())
        {

        }

        public async Task<PerfilUsuario> ConsultarPorNombre(string nombre)
        {
            return await contexto.Set<PerfilUsuario>().FirstOrDefaultAsync(x => !x.Eliminado && x.Nombre == nombre);
        }
    }
}
