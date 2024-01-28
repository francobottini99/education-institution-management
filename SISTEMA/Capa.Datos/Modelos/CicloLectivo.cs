using System.Collections.Generic;

namespace Capa.Datos.Modelos
{
    public class CicloLectivo : IModelo
    {
        public int ID { get; set; }
        public int Año { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
