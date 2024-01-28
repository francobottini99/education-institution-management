using Capa.Negocio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios
{
    public interface IServicioPerfilUsuario
    {
        Task<IEnumerable<PerfilUsuarioDTO>> ConsultarTodos();
        Task<PerfilUsuarioDTO> ConsultarPorID(int ID);
        Task<PerfilUsuarioDTO> Insertar(PerfilUsuarioDTO perfil, IEnumerable<DetallePerfilUsuarioDTO> detalle);
        Task<PerfilUsuarioDTO> Modificar(PerfilUsuarioDTO perfil, IEnumerable<DetallePerfilUsuarioDTO> detalle);
        Task Eliminar(int ID);
        Task<bool> ExistenUsuariosAsociadoAlPerfil(int ID);
        Task<IEnumerable<DetallePerfilUsuarioDTO>> ConsultarDetallePerfil(int IDPerfil);
    }
}
