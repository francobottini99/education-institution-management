using Capa.Negocio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios
{
    public interface IServicioMateria : IServicioGenerico<MateriaDTO>
    {
        Task<IEnumerable<MateriaDTO>> ConsultarPorIDCicloLectivo(int IDCicloLectivo);
    }
}
