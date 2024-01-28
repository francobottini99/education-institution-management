using Capa.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios
{
    public interface IServicioMatricula
    {
        Task<IEnumerable<MatriculaDTO>> ConsultarActivasGrupo(int IDGrupo, int IDCicloLectivo);
        Task<MatriculaDTO> ConsultarActivaAlumno(int IDAlumno, int IDCicloLectivo);
        Task ActualizarMatriculas(IEnumerable<MatriculaDTO> matriculas, GrupoDTO grupo, DateTime fecha);
        Task<bool> ExistenCambios(IEnumerable<MatriculaDTO> matriculasNuevas, GrupoDTO grupo);
    }
}
