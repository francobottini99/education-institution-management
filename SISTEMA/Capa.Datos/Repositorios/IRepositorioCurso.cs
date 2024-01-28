using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios
{
    public interface IRepositorioCurso : IRepositorioGenerico<Curso>
    {
        Task<Curso> ConsultarPorNumeroDivisionYIDCicloLectivo(int numero, string division, int IDCicloLectivo);
        Task<IEnumerable<Curso>> ConsultarPorIDCicloLectivo(int IDCicloLectivo);
    }
}
