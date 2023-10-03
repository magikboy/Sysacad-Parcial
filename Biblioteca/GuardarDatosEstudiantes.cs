using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO; // Se requiere la importación de System.IO para trabajar con archivos.

namespace Biblioteca
{
    public class GuardarDatosEstudiantes : GuardarDatosBase
    {
        public static List<Estudiante> ReadStreamJSON()
        {
            return ReadStreamJSON<Estudiante>("estudiantes.json");
        }

        public static void WriteStreamJSON(List<Estudiante> estudiantes)
        {
            WriteStreamJSON("estudiantes.json", estudiantes);
        }


        // Actualiza la contraseña de un Estudiante en el archivo JSON.
        public static void ActualizarContraseñaEstudiante(Estudiante estudiante)
        {
            var path = Combine("estudiantes.json");

            // Lee los datos existentes del archivo JSON y los almacena en una lista.
            var lista = GuardarDatosBase.ReadStreamJSON<Estudiante>("estudiantes.json");


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

        //actualizar historial academico estudiante

        public static void ActualizarHistorialAcademicoEstudiante(Estudiante estudiante)
        {
            var path = Combine("estudiantes.json");

            // Lee los datos existentes del archivo JSON y los almacena en una lista.
            var lista = GuardarDatosBase.ReadStreamJSON<Estudiante>("estudiantes.json");


            // Encuentra el estudiante en la lista y actualiza su historial academico
            Estudiante estudianteExistente = lista.FirstOrDefault(e => e.NumeroEstudiante == estudiante.NumeroEstudiante);

            if (estudianteExistente != null)
            {
                estudianteExistente.HistorialAcademico = estudiante.HistorialAcademico;

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
            var lista = GuardarDatosBase.ReadStreamJSON<Estudiante>("estudiantes.json");


            // Encuentra el estudiante en la lista y actualiza sus materias
            Estudiante estudianteExistente = lista.FirstOrDefault(e => e.NumeroEstudiante == estudiante.NumeroEstudiante);

            if (estudianteExistente != null)
            {
                estudianteExistente.MateriaUno = estudiante.MateriaUno;
                estudianteExistente.MateriaDos = estudiante.MateriaDos;
                estudianteExistente.MateriaTres = estudiante.MateriaTres;
                estudianteExistente.MateriaCuatro = estudiante.MateriaCuatro;
                estudianteExistente.MateriaCinco = estudiante.MateriaCinco;
                estudianteExistente.MateriaSeis = estudiante.MateriaSeis;

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

        //actualizar pago estudiante

        public static void ActualizarPagoEstudiante(Estudiante estudiante)
        {
            var path = Combine("estudiantes.json");

            // Lee los datos existentes del archivo JSON y los almacena en una lista.
            var lista = GuardarDatosBase.ReadStreamJSON<Estudiante>("estudiantes.json");


            // Encuentra el estudiante en la lista y actualiza sus materias
            Estudiante estudianteExistente = lista.FirstOrDefault(e => e.NumeroEstudiante == estudiante.NumeroEstudiante);

            if (estudianteExistente != null)
            {
                estudianteExistente.PagoMatricula = estudiante.PagoMatricula;
                estudianteExistente.PagoCargosAdministrativos = estudiante.PagoCargosAdministrativos;
                estudianteExistente.PagoUtilidades = estudiante.PagoUtilidades;

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
    }
}
