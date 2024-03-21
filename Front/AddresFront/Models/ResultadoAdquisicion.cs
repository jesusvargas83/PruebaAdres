namespace AddresFront.Models
{
    public class ResultadoAdquisicion
    {
        public string mensaje { get; set; }
        public IList<Adquisicion> response { get; set; } 
        public Adquisicion Adquisicion { get; set; } 
    }

    public class ResultadoHistorial
    {
        public string mensaje { get; set; } = string.Empty;
        public IList<Historial> response { get; set; }
    }
}
