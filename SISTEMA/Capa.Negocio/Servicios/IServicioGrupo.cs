using Capa.Negocio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios
{
    public interface IServicioGrupo : IServicioGenerico<GrupoDTO>
    {
        Task<IEnumerable<GrupoDTO>> ConsultarPorIDCicloLectivo(int IDCicloLectivo);
        Task<IEnumerable<GrupoDTO>> ConsultarPorIDCurso(int IDCurso);
        Task<bool> ExistenRegistrosAsociadosAlGrupo(int ID);
    }
}
