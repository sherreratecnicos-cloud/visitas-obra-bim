// Stub mínimo para compilar en CI sin Revit instalado
namespace Autodesk.Revit.UI
{
    public class UIApplication {}
    public class ExternalCommandData {}
    public interface IExternalCommand
    {
        Result Execute(ExternalCommandData commandData, ref string message, object elements);
    }
    public enum Result
    {
        Succeeded,
        Failed,
        Cancelled
    }
}
