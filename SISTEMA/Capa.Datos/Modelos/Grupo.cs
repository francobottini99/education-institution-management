using System.Collections.Generic;

namespace Capa.Datos.Modelos
{
    public class Grupo : IModelo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual CicloLectivo CicloLectivo { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
