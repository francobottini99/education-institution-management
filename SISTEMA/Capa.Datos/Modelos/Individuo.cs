using System;

namespace Capa.Datos.Modelos
{
    public class Individuo : IModelo
    {
        public int ID { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NumeroLegajo { get; set; }
        public string Genero { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string DNI { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string CP { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public string Nacionalidad { get; set; }
        public string Telefonos { get; set; }
        public string Mail { get; set; }
        public string Web { get; set; }
        public bool Eliminado { get; set; }

        public virtual Personal Personal { get; set; }
        public virtual Alumno Alumno { get; set; }
    }
}
