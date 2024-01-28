using System.Collections.Generic;

namespace Capa.Datos.Modelos
{
    public class Alumno : IModelo
    {
        public int ID { get; set; }
        public string TipoIngreso { get; set; }
        public string Tutores { get; set; }
        public string TelefonoTutor { get; set; }
        public string MailTutor { get; set; }
        public string DireccionTutor { get; set; }
        public string LocalidadTutor { get; set; }
        public string ProvinciaTutor { get; set; }
        public string CPTutor { get; set; }
        public string Estado { get; set; }
        public bool Eliminado { get; set; }

        public virtual Individuo Individuo { get; set; }   
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
