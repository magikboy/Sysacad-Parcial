using Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema
{
    public class AutenticarCredenciales
    {
        public static bool AutenticarComoAdministrador(string usuario, string contrasenia)
        {
            List<Administrador> admin = GuardarDatosAdministrador.ReadStreamJSON("administrador.json");
            return admin.Any(adm => adm.IniciarSesion(usuario, contrasenia));
        }

        public static Estudiante AutenticarComoEstudiante(string usuario, string contrasenia)
        {
            List<Estudiante> estudiantes = GuardarDatosEstudiantes.ReadStreamJSON("estudiantes.json");
            if (int.TryParse(usuario, out int numeroEstudiante))
            {
                Estudiante estudianteEncontrado = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante && est.Contrasenia == contrasenia);
                return estudianteEncontrado;
            }
            return null;
        }
    }
}
