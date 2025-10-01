using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using RevitVisitasObra.Models;
using System;

namespace RevitVisitasObra.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CrearVisita : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Visita visita = new Visita
            {
                Numero = "001",
                Fecha = DateTime.Now,
                Responsable = "Técnico HG"
            };

            TaskDialog.Show("Nueva Visita", $"Se ha creado la visita Nº {visita.Numero} - {visita.Fecha.ToShortDateString()}");

            return Result.Succeeded;
        }
    }
}