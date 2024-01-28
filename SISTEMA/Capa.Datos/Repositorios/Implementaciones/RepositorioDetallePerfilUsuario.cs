using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public class RepositorioDetallePerfilUsuario : RepositorioGenerico<DetallePerfilUsuario>, IRepositorioDetallePerfilUsuario
    {
        public RepositorioDetallePerfilUsuario() : base(ContextoIDDVS.GetInstance())
        {

        }

        public async override Task<DetallePerfilUsuario> ConsultarPorID(int ID)
        {
            return await contexto.Set<DetallePerfilUsuario>().Include("PerfilUsuario").FirstOrDefaultAsync(x => !x.Eliminado && x.ID == ID);
        }

        public async override Task<IEnumerable<DetallePerfilUsuario>> ConsultarTodos()
        {
            return await contexto.Set<DetallePerfilUsuario>().Include("PerfilUsuario").Where(x => !x.Eliminado).ToListAsync();
        }

        public async Task<IEnumerable<DetallePerfilUsuario>> ConsultarPorIDPerfil(int IDPerfil)
        {
            return await contexto.Set<DetallePerfilUsuario>().Include("PerfilUsuario").Where(x => !x.Eliminado && x.PerfilUsuario.ID == IDPerfil).ToListAsync();
        }

        public async Task EliminarPermanente(int ID)
        {
            var modelo = await contexto.Set<DetallePerfilUsuario>().FirstOrDefaultAsync(x => x.ID == ID);
    
            if (modelo == null)
                throw new ArgumentException("No existe la entidad a eliminar");

            contexto.Set<DetallePerfilUsuario>().Remove(modelo);

            await contexto.SaveChangesAsync();
        }
    }
}
