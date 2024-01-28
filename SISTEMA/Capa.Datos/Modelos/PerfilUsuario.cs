using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Datos.Modelos
{
    public class PerfilUsuario : IModelo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }
        
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<DetallePerfilUsuario> DetallePerfilUsuario { get; set; }
    }
}
