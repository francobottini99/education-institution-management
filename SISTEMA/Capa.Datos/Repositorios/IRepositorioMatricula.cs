using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios
{
    public interface IRepositorioMatricula : IRepositorioGenerico<Matricula>
    {
        Task<IEnumerable<Matricula>> ConsultarPorEstadoYCicloLectivo(string estado, int IDCicloLectivo);
        Task<IEnumerable<Matricula>> ConsultarPorEstadoAlumnoYCicloLectivo(string estado, int IDAlumno, int IDCicloLectivo);
        Task<IEnumerable<Matricula>> ConsultarPorEstadoGrupoYCicloLectivo(string estado, int IDGrupo, int IDCicloLectivo);
    }
}
