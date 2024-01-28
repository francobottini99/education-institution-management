using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios
{
    public interface IRepositorioGrupo : IRepositorioGenerico<Grupo>
    {
        Task<Grupo> ConsultarPorNombreIDCursoYIDCicloLectivo(string nombre, int IDCurso, int IDCicloLectivo);
        Task<IEnumerable<Grupo>> ConsultarPorIDCurso(int IDCurso);
        Task<IEnumerable<Grupo>> ConsultarPorIDCicloLectivo(int IDCicloLectivo);
    }
}
