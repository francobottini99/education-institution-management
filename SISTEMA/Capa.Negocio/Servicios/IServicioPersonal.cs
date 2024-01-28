using Capa.Datos.Modelos;
using Capa.Negocio.DTO;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios
{
    public interface IServicioPersonal : IServicioGenerico<PersonalDTO>
    {
        Task<bool> ExistePersonal(string DNI);
    }
}
