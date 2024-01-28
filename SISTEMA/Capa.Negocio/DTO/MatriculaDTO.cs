using Capa.Negocio.Utilidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace Capa.Negocio.DTO
{
    public class MatriculaDTO : IDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "El ID no puede ser negativo")]
        public int ID { get; set; }

        [Required(ErrorMessage = "La fecha es un dato obligatorio")]
        [DateTime(ErrorMessage = "Fecha invalida")]
        public DateTime Fecha { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El numero de matricula es un dato obligatorio")]
        [RegularExpression("(^[0-9.]+$)", ErrorMessage = "El numero de matricula solo puede contener números")]
        [StringLength(45, ErrorMessage = "El numero de matricula no puede exceder los 45 caracteres")]
        public string Numero { get; set; }

        [StringLength(45, ErrorMessage = "El estado no puede exceder los 45 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El estado es un dato obligatorio")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "La informacion del alumno es obligatoria")]
        public virtual AlumnoDTO Alumno { get; set; }

        [Required(ErrorMessage = "La informacion del curso es obligatoria")]
        public virtual CursoDTO Curso { get; set; }

        [Required(ErrorMessage = "La informacion del grupo es obligatoria")]
        public virtual GrupoDTO Grupo { get; set; }

        [Required(ErrorMessage = "La informacion del ciclo lectivo es obligatoria")]
        public virtual CicloLectivoDTO CicloLectivo { get; set; }
    }
}
