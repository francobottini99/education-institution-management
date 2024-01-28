using Capa.Negocio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios
{
    public interface IServicioAlumno : IServicioGenerico<AlumnoDTO>
    {
        Task<IEnumerable<AlumnoDTO>> ConsultarActivos();
        Task<IEnumerable<AlumnoDTO>> ConsultarActivosSinMatricular(int IDCicloLectivo);
        Task<bool> ExisteAlumno(string DNI);
    }
}
