using System;
using System.Collections.Generic;

namespace AdresBack.Models
{
    public partial class Adquisicion
    {
        public int Id { get; set; }
        public decimal? Presupuesto { get; set; }
        public string? UnidadAdministrativa { get; set; }
        public string? BienesServicios { get; set; }
        public int? Cantidad { get; set; }
        public decimal? ValorUnitario { get; set; }
        public decimal? ValorTotal { get; set; }
        public DateTime? FechaAdquisicion { get; set; }
        public string? EntidadProveedora { get; set; }
        public string? Documentacion { get; set; }
    }
}
