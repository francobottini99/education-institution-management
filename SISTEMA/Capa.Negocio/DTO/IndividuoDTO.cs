using Capa.Negocio.Utilidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace Capa.Negocio.DTO
{
    public class IndividuoDTO : IDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "El ID no puede ser negativo")]
        public int ID { get; set; }

        [Required(ErrorMessage = "La fecha de alta es un dato obligatorio")]
        [DateTime(ErrorMessage = "Fecha de alta invalida")]
        public DateTime FechaAlta { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es un dato obligatorio")]
        [DateTime(ErrorMessage = "Fecha de nacimiento invalida")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es un dato obligatorio")]
        [DateTime(ErrorMessage = "Fecha de ingreso invalida")]
        public DateTime FechaIngreso { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El número de legajo es un dato obligatorio")]
        [RegularExpression("(^[0-9.]+$)", ErrorMessage = "El número de legajo solo puede contener números")]
        public string NumeroLegajo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El género es un dato obligatorio")]
        [StringLength(45, ErrorMessage = "El género no puede exceder los 45 caracteres")]
        [RegularExpression("(^[a-zA-Z ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "El género solo puede contener letras y espacios")]
        public string Genero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El apellido es un dato obligatorio")]
        [StringLength(255, ErrorMessage = "El apellido no puede exceder los 255 caracteres")]
        [RegularExpression("(^[a-zA-Z ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "El apellido solo puede contener letras y espacios")]
        public string Apellidos { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es un dato obligatorio")]
        [StringLength(255, ErrorMessage = "El nombre no puede exceder los 255 caracteres")]
        [RegularExpression("(^[a-zA-Z ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "El nombre solo puede contener letras y espacios")]
        public string Nombres { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El DNI es un dato obligatorio")]
        [RegularExpression("(^[0-9.]+$)", ErrorMessage = "El DNI solo puede contener números")]
        [StringLength(45, ErrorMessage = "El DNI no puede exceder los 45 caracteres")]
        public string DNI { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La dirección es un dato obligatorio")]
        [StringLength(255, ErrorMessage = "La dirección no puede exceder los 255 caracteres")]
        public string Direccion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La localidad es un dato obligatorio")]
        [StringLength(255, ErrorMessage = "La localidad no puede exceder los 255 caracteres")]
        [RegularExpression("(^[0-9a-zA-Z ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "La localidad solo puede contener letras, números y espacios")]
        public string Localidad { get; set; }

        [RegularExpression("(^[0-9.]+$)", ErrorMessage = "El codigo postal solo puede contener números")]
        [StringLength(45, ErrorMessage = "El codigo postal no puede exceder los 45 caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El código postal es un dato obligatorio")]
        public string CP { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La provincia es un dato obligatorio")]
        [StringLength(100, ErrorMessage = "La provincia no puede exceder los 100 caracteres")]
        [RegularExpression("(^[0-9a-zA-Z ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "La provincia solo puede contener letras, números y espacios")]
        public string Provincia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El país es un dato obligatorio")]
        [StringLength(100, ErrorMessage = "El país no puede exceder los 100 caracteres")]
        [RegularExpression("(^[0-9a-zA-Z ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "El país solo puede contener letras, números y espacios")]
        public string Pais { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La nacionalidad es un dato obligatorio")]
        [StringLength(100, ErrorMessage = "La nacionalidad no puede exceder los 100 caracteres")]
        [RegularExpression("(^[a-zA-Z ÁÉÍÓÚáéíóúñÑ]+$)", ErrorMessage = "La nacionalidad solo puede contener letras y espacios")]
        public string Nacionalidad { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El teléfono es un dato obligatorio")]
        [RegularExpression("(^[0-9 ,-]+$)", ErrorMessage = "El teléfono solo puede contener números, guiones medios, comas y espacios")]
        [StringLength(255, ErrorMessage = "El teléfono no puede exceder los 255 caracteres")]
        public string Telefonos { get; set; }

        //[EmailAddress(ErrorMessage = "El texto no corresponde con un mail valido")]
        [StringLength(255, ErrorMessage = "El mail no puede exceder los 255 caracteres")]
        public string Mail { get; set; }

        [StringLength(255, ErrorMessage = "La pagina web no puede exceder los 255 caracteres")]
        public string Web { get; set; }
    }
}
