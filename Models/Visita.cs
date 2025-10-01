using System;

namespace RevitVisitasObra.Models
{
    public class Visita
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Responsable { get; set; }
    }
}