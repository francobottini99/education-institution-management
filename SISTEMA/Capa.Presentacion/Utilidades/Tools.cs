using Capa.Presentacion.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion.Utilidades
{
    public enum WritingOperations
    {
        UPDATE,
        NEW
    }

    public static class Tools
    {
        public static bool IsNumeric(string valor)
        {
            return int.TryParse(valor, out _);
        }

        public static bool IsDate(string valor)
        {
            return DateTime.TryParse(valor, out _);
        }

        public static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
