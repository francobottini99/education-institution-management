using System.ComponentModel.DataAnnotations;

namespace Capa.Negocio.DTO
{
    public class MateriaDTO : IDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "El ID no puede ser negativo")]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es un dato obligatorio")]
        [StringLength(255, ErrorMessage = "El nombre no puede exceder los 255 caracteres")]
        [RegularExpression("(^[a-zA-Z0-9-. ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "El nombre solo puede contener letras (minusculas o mayusculas), números y espacios")]
        public string Nombre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Las horas catedra deben ser mayor que 0")]
        [Required(ErrorMessage = "Horas catedra es un dato obligatorio")]
        public int HorasCatedra { get; set; }

        [Required(ErrorMessage = "La informacion del curso es obligatoria")]
        public CursoDTO Curso { get; set; }

        [Required(ErrorMessage = "La informacion del grupo es obligatoria")]
        public GrupoDTO Grupo { get; set; }

        [Required(ErrorMessage = "La informacion del ciclo lectivo es obligatoria")]
        public CicloLectivoDTO CicloLectivo { get; set; }
    }
}
