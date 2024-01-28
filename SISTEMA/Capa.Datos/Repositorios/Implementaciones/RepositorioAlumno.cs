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
    public class RepositorioAlumno : RepositorioGenerico<Alumno>, IRepositorioAlumno
    {
        public RepositorioAlumno() : base(ContextoIDDVS.GetInstance())
        {
            
        }

        public async Task<IEnumerable<Alumno>> ConsultarPorEstado(string estado)
        {
            return await contexto.Set<Alumno>().Include("Individuo").Where(x => !x.Eliminado && x.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }

        public async override Task<Alumno> ConsultarPorID(int ID)
        {
            return await contexto.Set<Alumno>().Include("Individuo").FirstOrDefaultAsync(x => !x.Eliminado && x.ID == ID);
        }

        public async override Task<IEnumerable<Alumno>> ConsultarTodos()
        {
            return await contexto.Set<Alumno>().Include("Individuo").Where(x => !x.Eliminado).ToListAsync();
        }
    }
}
