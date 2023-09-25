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

        // Actualiza las materias de un Estudiante en el archivo JSON.

        public static void ActualizarMateriasEstudiante(Estudiante estudiante)
        {
            var path = Combine("estudiantes.json");

            // Lee los datos existentes del archivo JSON y los almacena en una lista.
            var lista = ReadStreamJSON("estudiantes.json");

            // Encuentra el estudiante en la lista y actualiza sus materias
            Estudiante estudianteExistente = lista.FirstOrDefault(e => e.NumeroEstudiante == estudiante.NumeroEstudiante);

            if (estudianteExistente != null)
            {
                estudianteExistente.materiaUno = estudiante.materiaUno;
                estudianteExistente.materiaDos = estudiante.materiaDos;
                estudianteExistente.materiaTres = estudiante.materiaTres;
                estudianteExistente.materiaCuatro = estudiante.materiaCuatro;
                estudianteExistente.materiaCinco = estudiante.materiaCinco;
                estudianteExistente.materiaSeis = estudiante.materiaSeis;

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
