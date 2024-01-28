using Capa.Datos.Modelos;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios
{
    public interface IRepositorioPerfilUsuario : IRepositorioGenerico<PerfilUsuario>
    {
        Task<PerfilUsuario> ConsultarPorNombre(string nombre);
    }
}
