namespace AddresFront.Models
{
    public class Historial
    {
        public int Id { get; set; }
        public int? IdAdquisicion { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public List<Adquisicion> Adquisiciones { get; set; }
    }
}
