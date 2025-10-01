using Autodesk.Revit.UI;
using System;

namespace RevitVisitasObra
{
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            Ribbon.CreateRibbon(application);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}