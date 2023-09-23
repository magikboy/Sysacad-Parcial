using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Biblioteca
{
    public class GuardarDatosCursos
    {
        private static string directorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\documentos";

        public static string archivoCursos = "cursos.json";

        public static void CrearCarpeta()
        {
            // Comprobar si la carpeta ya existe, si no, crearla.
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        }

        // Lee datos en formato JSON desde un archivo y los deserializa en una lista de Cursos.
        public static List<Cursos> ReadStreamJSON(string file)
        {
            CrearCarpeta();
            var path = ObtenerRutaCompleta(file);
            var lista = new List<Cursos>();

            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    var json = reader.ReadToEnd();
                    var listaAux = JsonSerializer.Deserialize<List<Cursos>>(json);

                    if (listaAux != null)
                    {
                        lista = listaAux;
                    }
                }
            }

            return lista;
        }

        // Escribe datos en formato JSON en un archivo, fusionándolos con los datos existentes.
        public static void WriteStreamJSON(string file, List<Cursos> nuevosCursos)
        {
            // Obtiene la lista actual de cursos desde el archivo JSON
            var listaExistente = ReadStreamJSON(file);

            // Agrega los nuevos cursos a la lista existente
            listaExistente.AddRange(nuevosCursos);

            var path = Combine(file);

            using (var writer = new StreamWriter(path))
            {
                var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                var json = JsonSerializer.Serialize(listaExistente, options);
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


        // Actualiza la informacion en el archivo JSON de los Cursos.
        public static void ActualizarCursos(List<Cursos> cursos)
        {
            var path = Combine(archivoCursos);

            using (var writer = new StreamWriter(path))
            {
                var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                var json = JsonSerializer.Serialize(cursos, options);
                writer.Write(json);
            }
        }

        //elimina un curso del archivo JSON
        public static void EliminarCurso(int codigo)
        {
            var lista = ReadStreamJSON(archivoCursos);
            var curso = lista.Find(curso => curso.Codigo == codigo);
            lista.Remove(curso);
            ActualizarCursos(lista);
        }

        // Método privado para combinar la ruta del directorio con el nombre del archivo.
        private static string ObtenerRutaCompleta(string archivo)
        {
            return Path.Combine(directorio, archivo);
        }
    }
}
