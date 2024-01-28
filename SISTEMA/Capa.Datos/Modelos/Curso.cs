using System.Collections.Generic;

namespace Capa.Datos.Modelos
{
    public class Curso : IModelo
    {
        public int ID { get; set; }
        public int Numero { get; set; }
        public string Division { get; set; }
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }

        public virtual CicloLectivo CicloLectivo { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
