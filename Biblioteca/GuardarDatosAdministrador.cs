using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Biblioteca
{
    public class GuardarDatosAdministrador
    {
        // Directorio que es el escritorio donde se almacenarán los archivos.
        private static string directorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\documentos";

        // Nombre del archivo JSON en el que se guardarán los datos de los administradores.
        private static string archivoAdministradores = "administrador.json";

        public static void CrearCarpeta()
        {
            // Comprobar si la carpeta ya existe, si no, crearla.
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        }

        // Lee datos en formato JSON desde un archivo y los deserializa en una lista de Administrador.
        public static List<Administrador> ReadStreamJSON(string v)
        {
            CrearCarpeta();
            var path = ObtenerRutaCompleta(archivoAdministradores);
            var lista = new List<Administrador>();

            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    var json = reader.ReadToEnd();
                    var listaAux = JsonSerializer.Deserialize<List<Administrador>>(json);

                    if (listaAux != null)
                    {
                        lista = listaAux;
                    }
                }
            }

            return lista;
        }

        // Escribe datos en formato JSON en un archivo, fusionándolos con los datos existentes.
        public static void WriteStreamJSON(string file, List<Administrador> administradores)
        {
            var path = Combine(file);

            // Lee los datos existentes del archivo JSON y los almacena en una lista.
            var lista = ReadStreamJSON(file);
            lista.AddRange(administradores);

            using (var writer = new StreamWriter(path))
            {
                var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                var json = JsonSerializer.Serialize(lista, options);
                writer.Write(json);
            }
        }

        // Método privado para combinar el nombre de archivo con la ubicación en el escritorio.
        private static string Combine(string file)
        {
            Environment.SpecialFolder escritorio = Environment.SpecialFolder.DesktopDirectory;
            var desktop = Environment.GetFolderPath(escritorio);
            var path = Path.Combine(desktop, "documentos", file);
            return path;
        }

        // Método privado para combinar la ruta del directorio con el nombre del archivo.
        private static string ObtenerRutaCompleta(string archivo)
        {
            return Path.Combine(directorio, archivo);
        }
    }
}
