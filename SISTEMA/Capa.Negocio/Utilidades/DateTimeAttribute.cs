using System;
using System.ComponentModel.DataAnnotations;

namespace Capa.Negocio.Utilidades
{
    public class DateTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Convert.ToDateTime(value);
            return true;
        }
    }
}
