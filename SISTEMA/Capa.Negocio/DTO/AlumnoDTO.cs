using System.ComponentModel.DataAnnotations;

namespace Capa.Negocio.DTO
{
    public class AlumnoDTO : IDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "El ID no puede ser negativo")]
        public int ID { get; set; }

        [StringLength(45, ErrorMessage = "El tipo de ingreso no puede exceder los 45 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El tipo de ingreso es un dato obligatorio")]
        public string TipoIngreso { get; set; }
        
        [StringLength(255, ErrorMessage = "El tutor no puede exceder los 255 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El tutor es un dato obligatorio")]
        public string Tutores { get; set; }

        [StringLength(255, ErrorMessage = "El télefono no puede exceder los 255 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El teléfono del tutor es un dato obligatorio")]
        [RegularExpression("(^[0-9 ,-]+$)", ErrorMessage = "El teléfono del tutor solo puede contener números, guiones medios, comas y espacios")]
        public string TelefonoTutor { get; set; }

        [StringLength(255, ErrorMessage = "El mail del tutor no puede exceder los 255 caracteres")]
        public string MailTutor { get; set; }

        [StringLength(255, ErrorMessage = "La dirección del tuttor no puede exceder los 255 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La dirección del tuttor es un dato obligatorio")]
        public string DireccionTutor { get; set; }

        [StringLength(255, ErrorMessage = "La localidad del tuttor no puede exceder los 255 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La localidad del tuttor es un dato obligatorio")]
        public string LocalidadTutor { get; set; }

        [StringLength(100, ErrorMessage = "La provincia del tuttor no puede exceder los 255 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La provincia del tuttor es un dato obligatorio")]
        public string ProvinciaTutor { get; set; }

        [StringLength(45, ErrorMessage = "El código postal del tuttor no puede exceder los 45 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El código postal del tutor es un dato obligatorio")]
        public string CPTutor { get; set; }

        [StringLength(100, ErrorMessage = "El estado no puede exceder los 100 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El estado es un dato obligatorio")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "La informacion del individuo es obligatoria")]
        public IndividuoDTO Individuo { get; set; }
    }
}
