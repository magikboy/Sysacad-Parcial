using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Biblioteca
{
    public class GuardarDatosCursos : GuardarDatosBase
    {
        public static string archivoCursos = "cursos.json";
        public static List<Cursos> ReadStreamJSON()
        {
            return ReadStreamJSON<Cursos>("cursos.json");
        }

        public static void WriteStreamJSON(List<Cursos> cursos)
        {
            WriteStreamJSON("cursos.json", cursos);
        }

        // Actualiza la informacion en el archivo JSON de los Cursos.
        public static void ActualizarCursos(List<Cursos> cursos)
        {
            var path = Combine("cursos.json");

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
            var lista = ReadStreamJSON();
            var curso = lista.Find(curso => curso.Codigo == codigo);
            lista.Remove(curso);
            ActualizarCursos(lista);
        }

    }
}
