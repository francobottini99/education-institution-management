using Capa.Datos.Modelos;
using Capa.Datos.Repositorios;
using Capa.Datos.Repositorios.Implementaciones;
using Capa.Negocio.DTO;
using System;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios.Implementacion
{
    public class ServicioUsuario : ServicioGenerico<UsuarioDTO, Usuario>, IServicioUsuario
    {
        private readonly IRepositorioUsuario repositorio;

        public ServicioUsuario() : base(new RepositorioUsuario())
        {
            repositorio = (IRepositorioUsuario)ObtenerRepositorio();
        }

        public async Task<UsuarioDTO> IniciarSesion(string usuario, string contraseña)
        {
            var modeloUsuario = await repositorio.ConsultarPorUsuarioContraseña(usuario, contraseña);

            if (modeloUsuario == null)
                throw new ArgumentException("Usuario y/o contraseña incorrectos");

            if (modeloUsuario.Estado != "Activo")
                throw new ArgumentException("Tu usuario no se encuentra habilitado para acceder al sistema");

            return mapeador.Map<UsuarioDTO>(modeloUsuario);
        }
    }
}
