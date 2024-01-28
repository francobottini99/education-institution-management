using System.ComponentModel.DataAnnotations;

namespace Capa.Negocio.DTO
{
    public class PersonalDTO : IDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "El ID no puede ser negativo")]
        public int ID { get; set; }

        [StringLength(45, ErrorMessage = "El CUIT no puede exceder los 45 caracteres")]
        [RegularExpression("(^[0-9-]+$)", ErrorMessage = "El CUIT solo puede contener números y guiones medios")]
        public string CUIT { get; set; }

        [StringLength(45, ErrorMessage = "El CBU no puede exceder los 45 caracteres")]
        [RegularExpression("(^[0-9.]+$)", ErrorMessage = "El CBU solo puede contener números")]
        public string CBU { get; set; }

        [Required(ErrorMessage = "La informacion del individuo es obligatoria")]
        public IndividuoDTO Individuo { get; set; }
    }
}
