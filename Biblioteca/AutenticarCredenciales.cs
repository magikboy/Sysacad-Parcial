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
            Administrador administradorEncontrado = administradores.FirstOrDefault(admin => admin.Usuario == usuario);

            if (administradorEncontrado != null)
            {
                // Encriptar la contraseña ingresada y compararla con la almacenada
                if (Hash.ValidatePassword(contrasenia, administradorEncontrado.Contrasenia))
                {
                    return true; // Contraseña válida, usuario autenticado
                }
            }

            return false; // Usuario o contraseña incorrectos
        }


        public static Estudiante AutenticarComoEstudiante(string usuario, string contrasenia)
        {
            List<Estudiante> estudiantes = GuardarDatosEstudiantes.ReadStreamJSON<Estudiante>("estudiantes.json");
            if (int.TryParse(usuario, out int numeroEstudiante))
            {
                Estudiante estudianteEncontrado = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

                // Verificar si se encontró un estudiante con el número de estudiante especificado
                if (estudianteEncontrado != null)
                {
                    // Comparar la contraseña ingresada con el hash almacenado
                    if (Hash.ValidatePassword(contrasenia, estudianteEncontrado.Contrasenia))
                    {
                        return estudianteEncontrado; // Contraseña válida, retorna el estudiante encontrado
                    }
                }
            }

            return null; // Usuario o contraseña incorrectos
        }
    }
}
