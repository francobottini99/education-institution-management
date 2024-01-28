using System.ComponentModel.DataAnnotations;

namespace Capa.Negocio.DTO
{
    public class UsuarioDTO : IDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "El ID no puede ser negativo")]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es un dato obligatorio")]
        [StringLength(255, ErrorMessage = "El nombre no puede exceder los 255 caracteres")]
        [RegularExpression("(^[a-zA-Z ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "El nombre solo puede contener letras y espacios")]
        public string Nombres { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El apellido es un dato obligatorio")]
        [StringLength(255, ErrorMessage = "El apellido no puede exceder los 255 caracteres")]
        [RegularExpression("(^[a-zA-Z ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "El apellido solo puede contener letras y espacios")]
        public string Apellidos { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre de usuario es un dato obligatorio")]
        [StringLength(45, ErrorMessage = "El nombre de usuario no puede exceder los 45 caracteres")]
        [RegularExpression("(^[a-zA-Z0-9]+$)", ErrorMessage = "El nombre de usuario solo puede contener letras (minisculas o mayusculas) y numeros")]
        public string NombreUsuario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La contraseña es un dato obligatorio")]
        [StringLength(45, ErrorMessage = "La contraseña no puede exceder los 45 caracteres")]
        [RegularExpression("(^[a-zA-Z0-9@.!]+$)", ErrorMessage = "La contraseña solo puede contener letras (minisculas o mayusculas), numeros, \"@\", \".\" y \"!\"")]
        public string Contraseña { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El estado es un dato obligatorio")]
        [StringLength(45, ErrorMessage = "El estado no puede exceder los 45 caracteres")]
        [RegularExpression("(^[a-zA-Z]+$)", ErrorMessage = "El estado solo puede contener letras (minisculas o mayusculas)")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "La informacion del perfil de usuario es obligatoria")]
        public PerfilUsuarioDTO PerfilUsuario { get; set; }
    }
}
