using Capa.Datos.Datos;
using Capa.Datos.Modelos;

namespace Capa.Datos.Repositorios.Implementaciones
{
    public class RepositorioCierreMatricula : RepositorioGenerico<CierreMatricula>, IRepositorioCierreMatricula
    {
        public RepositorioCierreMatricula() : base(ContextoIDDVS.GetInstance())
        {

        }
    }
}
