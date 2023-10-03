using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Biblioteca
{
    public class GuardarDatosAdministrador : GuardarDatosBase
    {
        public static List<Administrador> ReadStreamJSON()
        {
            return ReadStreamJSON<Administrador>("administradores.json");
        }

        public static void WriteStreamJSON(List<Administrador> administradores)
        {
            WriteStreamJSON("administrador.json", administradores);
        }

        // Actualiza la contraseña de un Administrador en el archivo JSON.
        public static void ActualizarContraseñaAdministrador(Administrador administrador)
        {
            var path = Combine("administrador.json");

            // Lee los datos existentes del archivo JSON y los almacena en una lista.
            var lista = GuardarDatosBase.ReadStreamJSON<Administrador>("administrador.json");
        }
        public static bool FileExists()
        {
            var path = Combine("administrador.json");
            return File.Exists(path);
        }

    }
}
