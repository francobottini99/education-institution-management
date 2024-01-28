using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Negocio.DTO
{
    public class PerfilUsuarioDTO : IDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "El ID no puede ser negativo")]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es un dato obligatorio")]
        [StringLength(45, ErrorMessage = "El nombre no puede exceder los 45 caracteres")]
        [RegularExpression("(^[a-zA-Z0-9 ]+$)", ErrorMessage = "El nombre solo puede contener letras (minisculas o mayusculas), espacios y numeros")]
        public string Nombre { get; set; }
    }
}
