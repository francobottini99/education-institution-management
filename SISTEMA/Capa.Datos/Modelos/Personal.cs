namespace Capa.Datos.Modelos
{
    public class Personal : IModelo
    {
        public int ID { get; set; }
        public string CUIT { get; set; }
        public string CBU { get; set; }
        public bool Eliminado { get; set; }

        public virtual Individuo Individuo { get; set; }
    }
}
