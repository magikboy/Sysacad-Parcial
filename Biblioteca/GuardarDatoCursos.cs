using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class GuardarDatoCursos
    {

        private static string directorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\documentos";

        private static string archivoCursos = "cursos.json";

        // Lee datos en formato JSON desde un archivo y los deserializa en una lista de Curso.

        public static void CrearCarpeta()
        {
            // Comprobar si la carpeta ya existe, si no, crearla.
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        }

        public static List<Cursos> ReadCursosJSON()
        {
            CrearCarpeta();
            var path = ObtenerRutaCompleta(archivoCursos);
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

        // Escribe datos en formato JSON en un archivo de cursos, fusionándolos con los datos existentes.
        public static void WriteCursosJSON(List<Cursos> cursos)
        {
            var path = ObtenerRutaCompleta(archivoCursos);

            // Lee los datos existentes del archivo JSON y los almacena en una lista.
            var lista = ReadCursosJSON();
            lista.AddRange(cursos);

            using (var writer = new StreamWriter(path))
            {
                var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                var json = JsonSerializer.Serialize(lista, options);
                writer.Write(json);
            }
        }

        // Escribe los datos de un Curso en un archivo de texto.
        public static void WriteCurso(Cursos curso)
        {
            using (var writer = new StreamWriter(ObtenerRutaCompleta(archivoCursos), true))
            {
                writer.WriteLine(curso.GetInstancias());
            }
        }

        // Escribe una lista de Cursos en un archivo de texto.
        public static void WriteCursos(List<Cursos> cursos)
        {
            using (var writer = new StreamWriter(ObtenerRutaCompleta(archivoCursos)))
            {
                foreach (var curso in cursos)
                {
                    writer.WriteLine(curso.GetInstancias());
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
