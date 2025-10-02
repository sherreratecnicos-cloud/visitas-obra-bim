namespace Autodesk.Revit.UI {
    public interface IExternalCommand {
        Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements);
    }
    public enum Result { Succeeded, Failed, Cancelled }
    public class ExternalCommandData {}
    public class ElementSet {}
    public class UIControlledApplication {}
    public interface IExternalApplication {
        Result OnStartup(UIControlledApplication app);
        Result OnShutdown(UIControlledApplication app);
    }
}

namespace Autodesk.Revit.Attributes {
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class TransactionAttribute : System.Attribute {
        public TransactionAttribute(TransactionMode mode) {}
    }
    public enum TransactionMode { Manual, Automatic }
}
