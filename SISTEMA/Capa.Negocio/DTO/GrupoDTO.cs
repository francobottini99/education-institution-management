using System.ComponentModel.DataAnnotations;

namespace Capa.Negocio.DTO
{
    public class GrupoDTO : IDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "El ID no puede ser negativo")]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es un dato obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        [RegularExpression("(^[a-zA-Z0-9 ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "El nombre solo puede contener letras (minusculas o mayusculas), números y espacios")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La informacion del curso es obligatoria")]
        public CursoDTO Curso { get; set; }

        [Required(ErrorMessage = "La informacion del ciclo lectivo es obligatoria")]
        public CicloLectivoDTO CicloLectivo { get; set; }
    }
}
