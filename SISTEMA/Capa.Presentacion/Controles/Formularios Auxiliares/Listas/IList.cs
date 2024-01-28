using Capa.Negocio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Presentacion.Controles.Formularios_Auxiliares.Listas
{
    public interface IList
    {
        Task<IEnumerable<IDTO>> LoadList(object argument = null);
        void LoadDataGrid(ref IDDVSDataGrid dgv, IEnumerable<IDTO> list, string filter = null);
    }
}
