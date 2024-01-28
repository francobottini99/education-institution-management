using System;
using System.Collections.Generic;

namespace Capa.Datos.Modelos
{
    public class Matricula : IModelo
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public bool Eliminado { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual CicloLectivo CicloLectivo { get; set; }
        public virtual ICollection<CierreMatricula> CierreMatriculas { get; set; }
    }
}
