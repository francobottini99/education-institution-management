using Capa.Datos.Modelos;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios
{
    public interface IRepositorioIndividuo : IRepositorioGenerico<Individuo>
    {
        Task<Individuo> ConsultarPorDNI(string DNI);
    }
}
