using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios
{
    public interface IRepositorioUsuario : IRepositorioGenerico<Usuario>
    {
        Task<Usuario> ConsultarPorUsuarioContraseña(string usuario, string contraseña); 
        Task<Usuario> ConsultarPorUsuario(string usuario);
        Task<IEnumerable<Usuario>> ConsultarPorIDPerfil(int IDPerfil);
    }
}
