using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public class RepositorioUsuario : RepositorioGenerico<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario() : base(ContextoIDDVS.GetInstance())
        {

        }

        public async override Task<Usuario> Modificar(Usuario modelo)
        {
            var existingEntity = await ConsultarPorID(modelo.ID);

            contexto.Entry(existingEntity).CurrentValues.SetValues(modelo);
            
            existingEntity.PerfilUsuario = modelo.PerfilUsuario;

            await contexto.SaveChangesAsync();

            return existingEntity;
        }

        public async Task<Usuario> ConsultarPorUsuarioContraseña(string usuario, string contraseña)
        {
            return await contexto.Set<Usuario>().Include("PerfilUsuario").FirstOrDefaultAsync(x => !x.Eliminado && x.NombreUsuario == usuario && x.Contraseña == contraseña);
        }

        public async Task<Usuario> ConsultarPorUsuario(string usuario)
        {
            return await contexto.Set<Usuario>().Include("PerfilUsuario").FirstOrDefaultAsync(x => !x.Eliminado && x.NombreUsuario == usuario);
        }

        public async override Task<Usuario> ConsultarPorID(int ID)
        {
            return await contexto.Set<Usuario>().Include("PerfilUsuario").FirstOrDefaultAsync(x => !x.Eliminado && x.ID == ID);
        }

        public async override Task<IEnumerable<Usuario>> ConsultarTodos()
        {
            return await contexto.Set<Usuario>().Include("PerfilUsuario").Where(x => !x.Eliminado).ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ConsultarPorIDPerfil(int IDPerfil)
        {
            return await contexto.Set<Usuario>().Include("PerfilUsuario").Where(x => !x.Eliminado && x.PerfilUsuario.ID == IDPerfil).ToListAsync();
        }
    }
}
