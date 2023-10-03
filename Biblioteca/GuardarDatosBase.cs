using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Biblioteca
{
    public class GuardarDatosBase
    {
        protected static string directorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\documentos";

        protected static void CrearCarpeta()
        {
            // Comprobar si la carpeta ya existe, si no, crearla.
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        }

        public static List<T> ReadStreamJSON<T>(string file)
        {
            CrearCarpeta();
            var path = ObtenerRutaCompleta(file);
            var lista = new List<T>();

            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    var json = reader.ReadToEnd();
                    var listaAux = JsonSerializer.Deserialize<List<T>>(json);

                    if (listaAux != null)
                    {
                        lista = listaAux;
                    }
                }
            }

            return lista;
        }


        public static void WriteStreamJSON<T>(string file, List<T> data)
        {
            var path = Combine(file);

            using (var writer = new StreamWriter(path))
            {
                var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                var json = JsonSerializer.Serialize(data, options);
                writer.Write(json);
            }
        }

        protected static string Combine(string file)
        {
            Environment.SpecialFolder escritorio = Environment.SpecialFolder.DesktopDirectory;
            var desktop = Environment.GetFolderPath(escritorio);
            var path = Path.Combine(desktop, "documentos", file);
            return path;
        }

        private static string ObtenerRutaCompleta(string archivo)
        {
            return Path.Combine(directorio, archivo);
        }
    }
}
