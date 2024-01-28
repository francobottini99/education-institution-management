using System.ComponentModel.DataAnnotations;

namespace Capa.Datos.Modelos
{
    public interface IModelo
    {
        int ID { get; set; }
        bool Eliminado { get; set; }
    }
}
