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
            List<Administrador> administradores = GuardarDatosAdministrador.ReadStreamJSON<Administrador>("administrador.json");
            Administrador administradorEncontrado = administradores.FirstOrDefault(admin => admin.Usuario == usuario && admin.Contrasenia == contrasenia);
            return administradorEncontrado != null;
        }

        public static Estudiante AutenticarComoEstudiante(string usuario, string contrasenia)
        {
            List<Estudiante> estudiantes = GuardarDatosEstudiantes.ReadStreamJSON<Estudiante>("estudiantes.json");
            if (int.TryParse(usuario, out int numeroEstudiante))
            {
                Estudiante estudianteEncontrado = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante && est.Contrasenia == contrasenia);
                return estudianteEncontrado;
            }
            return null;
        }

    }
}
