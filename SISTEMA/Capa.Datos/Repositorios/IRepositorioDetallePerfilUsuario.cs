using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios
{
    public interface IRepositorioDetallePerfilUsuario : IRepositorioGenerico<DetallePerfilUsuario>
    {
        Task<IEnumerable<DetallePerfilUsuario>> ConsultarPorIDPerfil(int IDPerfil);
        Task EliminarPermanente(int ID);
    }
}
