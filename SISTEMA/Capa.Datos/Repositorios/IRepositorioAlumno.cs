using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios
{
    public interface IRepositorioAlumno : IRepositorioGenerico<Alumno>
    {
        Task<IEnumerable<Alumno>> ConsultarPorEstado(string estado);
    }
}
