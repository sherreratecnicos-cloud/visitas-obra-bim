using Newtonsoft.Json;
using RevitVisitasObra.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace RevitVisitasObra.Data
{
    public static class DataManager
    {
        private static string icloudPath = 
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\iCloudDrive\VisitasObra";

        private static string anotacionesFile = Path.Combine(icloudPath, "anotaciones.json");

        public static List<Anotacion> CargarAnotaciones()
        {
            if (!File.Exists(anotacionesFile)) return new List<Anotacion>();
            string json = File.ReadAllText(anotacionesFile);
            return JsonConvert.DeserializeObject<List<Anotacion>>(json);
        }

        public static void GuardarAnotaciones(List<Anotacion> anotaciones)
        {
            if (!Directory.Exists(icloudPath))
                Directory.CreateDirectory(icloudPath);

            string json = JsonConvert.SerializeObject(anotaciones, Formatting.Indented);
            File.WriteAllText(anotacionesFile, json);
        }

        public static string GuardarFoto(string rutaOrigen)
        {
            string fotosPath = Path.Combine(icloudPath, "Fotos");
            if (!Directory.Exists(fotosPath))
                Directory.CreateDirectory(fotosPath);

            string nombreArchivo = Path.GetFileName(rutaOrigen);
            string destino = Path.Combine(fotosPath, nombreArchivo);

            File.Copy(rutaOrigen, destino, true);
            return destino;
        }
    }
}