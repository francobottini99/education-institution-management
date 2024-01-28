using Capa.Negocio.DTO;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios
{
    public interface IServicioUsuario : IServicioGenerico<UsuarioDTO>
    {
        Task<UsuarioDTO> IniciarSesion(string usuario, string contraseña);
    }
}
