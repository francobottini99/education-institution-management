using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios
{
    public interface IRepositorioGenerico<Modelo> where Modelo : class, IModelo
    {
        Task<IEnumerable<Modelo>> ConsultarTodos();
        Task<Modelo> ConsultarPorID(int ID);
        Task<Modelo> Insertar(Modelo modelo);
        Task<Modelo> Modificar(Modelo modelo);
        Task Eliminar(int ID);
    }
}
