using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public abstract class RepositorioGenerico<Modelo> : IRepositorioGenerico<Modelo> where Modelo : class, IModelo
    {
        protected readonly ContextoIDDVS contexto;

        public RepositorioGenerico(ContextoIDDVS contexto)
        {
            this.contexto = contexto;
        }

        public virtual async Task<Modelo> ConsultarPorID(int ID)
        {
            return await contexto.Set<Modelo>().FirstOrDefaultAsync(x => !x.Eliminado && x.ID == ID);
        }

        public virtual async Task<IEnumerable<Modelo>> ConsultarTodos()
        {
            return await contexto.Set<Modelo>().Where(x => !x.Eliminado).ToListAsync();
        }

        public virtual async Task Eliminar(int ID)
        {
            var modelo = await ConsultarPorID(ID);

            if (modelo == null)
                throw new ArgumentException("No existe la entidad a eliminar");

            modelo.Eliminado = true;

            contexto.Set<Modelo>().AddOrUpdate(modelo);

            await contexto.SaveChangesAsync();
        }

        /*public virtual async Task<Modelo> Restaurar(int ID)
        {
            var modelo = await contexto.Set<Modelo>().FirstOrDefaultAsync(x => x.ID == ID);

            if (modelo == null)
                throw new Exception("No existe la entidad a restaurar");

            if (!modelo.Eliminado)
                throw new Exception("La entidad que se intenta restaurar no se encuentra eliminada");

            modelo.Eliminado = false;

            contexto.Set<Modelo>().AddOrUpdate(modelo);

            await contexto.SaveChangesAsync();

            return modelo;
        }*/

        public virtual async Task<Modelo> Insertar(Modelo modelo)
        {
            modelo.Eliminado = false;

            contexto.Set<Modelo>().Add(modelo);

            await contexto.SaveChangesAsync();

            return modelo;
        }

        public virtual async Task<Modelo> Modificar(Modelo modelo)
        {
            var existingEntity = await ConsultarPorID(modelo.ID);

            contexto.Entry(existingEntity).CurrentValues.SetValues(modelo);

            await contexto.SaveChangesAsync();

            return existingEntity;
        }
    }
}
