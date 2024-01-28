using Capa.Negocio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios
{
    public interface IServicioCurso : IServicioGenerico<CursoDTO>
    {
        Task<IEnumerable<CursoDTO>> ConsultarPorIDCicloLectivo(int IDCicloLectivo);
        Task<bool> ExistenGruposAsociadoAlCurso(int ID);
    }
}
