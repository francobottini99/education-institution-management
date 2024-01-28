using System;

namespace Capa.Datos.Modelos
{
    public class CierreMatricula : IModelo
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public string Observaciones { get; set; }
        public bool Eliminado { get; set; }

        public virtual Matricula Matricula { get; set; }
    }
}
