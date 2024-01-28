using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Datos.Modelos
{
    public class Usuario : IModelo
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Estado { get; set; }
        public bool Eliminado { get; set; }

        public virtual PerfilUsuario PerfilUsuario { get; set; }
    }
}
