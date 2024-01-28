using System.ComponentModel.DataAnnotations;

namespace Capa.Negocio.DTO
{
    public class CicloLectivoDTO : IDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "El ID no puede ser negativo")]
        public int ID { get; set; }

        [Required(ErrorMessage = "El año es un dato obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El año no puede ser negativo")]
        public int Año { get; set; }
    }
}
