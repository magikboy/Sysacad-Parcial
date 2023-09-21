using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO; // Se requiere la importación de System.IO para trabajar con archivos.

namespace Biblioteca
{
    public class GuardarDatos
    {
        // Directorio que es el escritorio donde se almacenarán los archivos.
        private static string directorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\documentos";

        // Nombre del archivo JSON en el que se guardarán los datos de los estudiantes.
        private static string archivoEstudiantes = "estudiantes.json";


        public static void CrearCarpeta()
        {
            // Comprobar si la carpeta ya existe, si no, crearla.
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        }

        // Lee datos en formato JSON desde un archivo y los deserializa en una lista de Estudiante.
        public static List<Estudiante> ReadStreamJSON(string v)
        {
            CrearCarpeta();
            var path = ObtenerRutaCompleta(archivoEstudiantes);
            var lista = new List<Estudiante>();

            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    var json = reader.ReadToEnd();
                    var listaAux = JsonSerializer.Deserialize<List<Estudiante>>(json);

                    if (listaAux != null)
                    {
                        lista = listaAux;
                    }
                }
            }

            return lista;
        }

        // Escribe datos en formato JSON en un archivo, fusionándolos con los datos existentes.
        public static void WriteStreamJSON(string file, List<Estudiante> estudiantes)
        {
            var path = Combine(file);

            // Lee los datos existentes del archivo JSON y los almacena en una lista.
            var lista = ReadStreamJSON(file);
            lista.AddRange(estudiantes);

            using (var writer = new StreamWriter(path))
            {
                var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                var json = JsonSerializer.Serialize(lista, options);
                writer.Write(json);
            }
        }

        // Lee datos de texto línea por línea desde un archivo y los almacena en una lista de Estudiante.
        public static List<Estudiante> ReadStream(string file)
        {
            var path = Combine(file);
            var lista = new List<Estudiante>();

            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    string? linea;

                    while ((linea = reader.ReadLine()) != null)
                    {
                        lista.Add(linea);
                    }
                }
            }

            return lista;
        }

        // Escribe datos de texto en un archivo.
        public static void WriteStream(string file, string body)
        {
            using (var writer = new StreamWriter(Combine(file)))
            {
                writer.Write(body);
            }
        }

        // Escribe los datos de un Estudiante en un archivo de texto.
        public static void WriteStream(string file, Estudiante estudiante)
        {
            using (var writer = new StreamWriter(Combine(file), true))
            {
                writer.WriteLine(estudiante.GetInstancias());
            }
        }

        // Escribe una lista de Estudiante en un archivo de texto.
        public static void WriteStream(string file, List<Estudiante> estudiantes)
        {
            using (var writer = new StreamWriter(Combine(file)))
            {
                foreach (var item in estudiantes)
                {
                    writer.WriteLine(item.GetInstancias());
                }
            }
        }

        // Escribe datos de texto en un archivo, sobrescribiendo el contenido existente.
        public static void WriteFile(string file, string body)
        {
            File.WriteAllText(Combine(file), body);
        }

        // Lee y muestra el contenido de un archivo de texto en la consola.
        public static void ReadFile(string file)
        {
            var path = Combine(file);

            if (File.Exists(path))
            {
                var texto = File.ReadAllText(path);
                Console.WriteLine(texto);
            }
            else
            {
                Console.WriteLine("El archivo no existe");
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

        // Actualiza la contraseña de un Estudiante en el archivo JSON.
        public static void ActualizarContraseñaEstudiante(Estudiante estudiante)
        {
            var path = Combine("estudiantes.json");

            // Lee los datos existentes del archivo JSON y los almacena en una lista.
            var lista = ReadStreamJSON("estudiantes.json");

            // Encuentra el estudiante en la lista y actualiza su contraseña
            Estudiante estudianteExistente = lista.FirstOrDefault(e => e.NumeroEstudiante == estudiante.NumeroEstudiante);

            if (estudianteExistente != null)
            {
                estudianteExistente.Contrasenia = estudiante.Contrasenia;

                // Guarda la lista actualizada en el archivo JSON
                using (var writer = new StreamWriter(path))
                {
                    var options = new JsonSerializerOptions();
                    options.WriteIndented = true;
                    var json = JsonSerializer.Serialize(lista, options);
                    writer.Write(json);
                }
            }
        }

        // Método privado para combinar la ruta del directorio con el nombre del archivo.
        private static string ObtenerRutaCompleta(string archivo)
        {
            return Path.Combine(directorio, archivo);
        }
    }
}
