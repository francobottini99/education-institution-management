namespace Capa.Datos.Modelos
{
    public class Materia : IModelo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int HorasCatedra { get; set; }
        public bool Eliminado { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual CicloLectivo CicloLectivo { get; set; }
    }
}
