using System;

namespace RevitVisitasObra.Models
{
    public class Anotacion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ElementId { get; set; }
        public string Texto { get; set; }
        public Guid IdVisita { get; set; }
        public string FotoPath { get; set; }
    }
}