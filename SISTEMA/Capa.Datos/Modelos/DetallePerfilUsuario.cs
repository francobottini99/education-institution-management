using System.ComponentModel.DataAnnotations.Schema;

namespace Capa.Datos.Modelos
{
    public class DetallePerfilUsuario : IModelo
    {
        public int ID { get; set; }
        public string Menu { get; set; }
        public bool Eliminado { get; set; }

        public virtual PerfilUsuario PerfilUsuario { get; set; }
    }
}
