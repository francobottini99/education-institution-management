using Capa.Negocio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios
{
    public interface IServicioGenerico<DTO> where DTO : class, IDTO
    {
        Task<IEnumerable<DTO>> ConsultarTodos();
        Task<DTO> ConsultarPorID(int ID);
        Task<DTO> Insertar(DTO dto);
        Task<DTO> Modificar(DTO dto);
        Task Eliminar(int ID);
    }
}
