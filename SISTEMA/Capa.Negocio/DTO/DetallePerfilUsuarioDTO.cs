using System.ComponentModel.DataAnnotations;

namespace Capa.Negocio.DTO
{
    public class DetallePerfilUsuarioDTO : IDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "El ID no puede ser negativo")]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El menu es un dato obligatorio")]
        [StringLength(100, ErrorMessage = "El menu no puede exceder los 100 caracteres")]
        [RegularExpression("(^[a-zA-Z0-9]+$)", ErrorMessage = "El menu solo puede contener letras (minisculas o mayusculas) y numeros")]
        public string Menu { get; set; }

        [Required(ErrorMessage = "La informacion del perfil de usuario es obligatoria")]
        public PerfilUsuarioDTO PerfilUsuario { get; set; }
    }
}
