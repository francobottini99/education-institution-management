using Capa.Datos.Modelos;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios
{
    public interface IRepositorioCicloLectivo : IRepositorioGenerico<CicloLectivo>
    {
        Task<CicloLectivo> ConsultarPorAño(int año);
    }
}
