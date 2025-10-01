using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using RevitVisitasObra.Models;
using RevitVisitasObra.Data;
using System.Collections.Generic;
using Microsoft.Win32;

namespace RevitVisitasObra.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class AnotarElemento : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            Reference pickedRef = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Seleccione un elemento");
            Element elem = doc.GetElement(pickedRef);

            string texto = "Incidencia detectada en obra";

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Imágenes|*.jpg;*.png;*.jpeg";
            string fotoPath = null;
            if (dlg.ShowDialog() == true)
                fotoPath = DataManager.GuardarFoto(dlg.FileName);

            Anotacion anotacion = new Anotacion
            {
                ElementId = elem.Id.IntegerValue,
                Texto = texto,
                IdVisita = System.Guid.NewGuid(),
                FotoPath = fotoPath
            };

            List<Anotacion> anotaciones = DataManager.CargarAnotaciones();
            anotaciones.Add(anotacion);
            DataManager.GuardarAnotaciones(anotaciones);

            TaskDialog.Show("Anotación guardada", $"Elemento {elem.Id} anotado.\nTexto: {texto}\nFoto: {fotoPath}");

            return Result.Succeeded;
        }
    }
}