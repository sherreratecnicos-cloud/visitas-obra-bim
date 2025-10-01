using Autodesk.Revit.UI;
using System;
using System.Reflection;

namespace RevitVisitasObra
{
    public class Ribbon
    {
        public static void CreateRibbon(UIControlledApplication app)
        {
            string tabName = "Visitas Obra";
            try { app.CreateRibbonTab(tabName); } catch { }

            RibbonPanel panel = app.CreateRibbonPanel(tabName, "Gestión");

            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData btnVisita = new PushButtonData("CrearVisita", "Nueva Visita", assemblyPath, "RevitVisitasObra.Commands.CrearVisita");
            PushButtonData btnAnotar = new PushButtonData("AnotarElemento", "Anotar", assemblyPath, "RevitVisitasObra.Commands.AnotarElemento");

            panel.AddItem(btnVisita);
            panel.AddItem(btnAnotar);
        }
    }
}