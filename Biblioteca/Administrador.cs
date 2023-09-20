using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Administrador
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        // Método para iniciar sesión como administrador
        public bool IniciarSesion()
        {
            Console.WriteLine("Iniciando sesión como administrador...");
            // Si la autenticación es exitosa, devuelve true
            return true;
        }

        // Método para registrar un nuevo estudiante en el sistema
        public void RegistrarEstudiante(Estudiante nuevoEstudiante, Sistema sistema)
        {
            Console.WriteLine($"Registrando al estudiante {nuevoEstudiante.NombreCompleto}...");

            // Verificar si el estudiante ya existe en la base de datos
            if (sistema.ExisteEstudianteEnLaBaseDeDatos(nuevoEstudiante))
            {
                Console.WriteLine("Error: El estudiante ya está registrado en el sistema.");
                return;
            }

            // Generar un número de estudiante único
            sistema.GenerarNumeroEstudiante(nuevoEstudiante);

            // Guardar el nuevo estudiante en la base de datos
            sistema.GuardarEstudianteEnLaBaseDeDatos(nuevoEstudiante);

            // Enviar notificación por correo electrónico al estudiante
            sistema.EnviarNotificacionEstudiante(nuevoEstudiante, "¡Registro exitoso! Utilice su contraseña provisional para iniciar sesión.");
        }

        // Constructor de la clase Administrador
        public Administrador(string usuario, string contraseña)
        {
            Usuario = usuario;
            Contraseña = contraseña;
        }

        // Método para iniciar sesión con un usuario y contraseña proporcionados
        public bool IniciarSesion(string usuario, string contraseña)
        {
            return Usuario == usuario && Contraseña == contraseña;
        }


    }
}
