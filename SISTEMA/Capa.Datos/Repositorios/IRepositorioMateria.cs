using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios
{
    public interface IRepositorioMateria : IRepositorioGenerico<Materia>
    {
        Task<Materia> ConsultarPorNombreIDGrupoYIDCicloLectivo(string nombre, int IDGrupo, int IDCicloLectivo);
        Task<IEnumerable<Materia>> ConsultarPorIDCurso(int IDCurso);
        Task<IEnumerable<Materia>> ConsultarPorIDGrupo(int IDGrupo);
        Task<IEnumerable<Materia>> ConsultarPorIDCicloLectivo(int IDCicloLectivo);
    }
}
