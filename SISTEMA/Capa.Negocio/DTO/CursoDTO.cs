using System.ComponentModel.DataAnnotations;

namespace Capa.Negocio.DTO
{
    public class CursoDTO : IDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "El ID no puede ser negativo")]
        public int ID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El número debe ser mayor que 0")]
        [Required(ErrorMessage = "El número es un dato obligatorio")]
        public int Numero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La division es un dato obligatorio")]
        [StringLength(1, ErrorMessage = "La division debe ser especificada por un unico caracter")]
        [RegularExpression("(^[A-Z-]+$)", ErrorMessage = "La division debe ser especificada por una letra mayuscula")]
        public string Division { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es un dato obligatorio")]
        [StringLength(45, ErrorMessage = "El nombre no puede exceder los 45 caracteres")]
        [RegularExpression("(^[a-zA-Z0-9 ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "El nombre solo puede contener letras (minusculas o mayusculas), números y espacios")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La informacion del ciclo lectivo es obligatoria")]
        public CicloLectivoDTO CicloLectivo { get; set; }
    }
}
