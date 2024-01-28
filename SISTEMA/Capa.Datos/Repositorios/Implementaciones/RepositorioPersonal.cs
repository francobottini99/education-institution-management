using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public class RepositorioPersonal : RepositorioGenerico<Personal>, IRepositorioPersonal
    {
        public RepositorioPersonal() : base(ContextoIDDVS.GetInstance())
        {

        }

        public async override Task<IEnumerable<Personal>> ConsultarTodos()
        {
            return await contexto.Set<Personal>().Include("Individuo").Where(x => !x.Eliminado).ToListAsync();
        }

        public async override Task<Personal> ConsultarPorID(int ID)
        {
            return await contexto.Set<Personal>().Include("Individuo").FirstOrDefaultAsync(x => !x.Eliminado && x.ID == ID);
        }
    }
}
