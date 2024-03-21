using System;
using System.Collections.Generic;

namespace AdresBack.Models
{
    public partial class Historial
    {
        public int Id { get; set; }
        public int? IdAdquisicion { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
