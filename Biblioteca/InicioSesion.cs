using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class InicioSesion
    {
        // Constructor de la clase InicioSesion
        public InicioSesion()
        {
            // Cargo la lista de estudiantes desde el archivo JSON al crear una instancia de InicioSesion
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");
        }

        // Lista para almacenar los estudiantes cargados desde el archivo JSON
        private List<Estudiante> estudiantes = new List<Estudiante>();

        // Método estático para iniciar sesión como administrador
        public static void IniciarSesionAdministrador()
        {
            Console.Write("Ingrese el nombre de usuario: ");
            string usuario = Console.ReadLine();
            Console.Write("Ingrese la contraseña: ");
            string contraseña = Console.ReadLine();

            Administrador administrador = new Administrador(usuario, contraseña);
            if (administrador.IniciarSesion())
            {
                Console.WriteLine($"Inicio de sesión como administrador {administrador.Usuario} exitoso.");
                Menu.MostrarMenuAdministrador();
            }
            else
            {
                Console.WriteLine("Error: Inicio de sesión fallido.");
            }
        }

        // Método para que un estudiante inicie sesión
        public Estudiante IniciarSesionEstudiante()
        {
            Console.Clear();
            Console.Write("Ingrese su número de identificación: ");
            string numeroIdentificacion = Console.ReadLine();
            Console.Write("Ingrese su contraseña: ");
            string contraseña = Console.ReadLine();

            // Buscar al estudiante en la lista de estudiantes cargados desde el JSON
            Estudiante estudiante = estudiantes.Find(e => e.NumeroEstudiante.ToString() == numeroIdentificacion);

            if (estudiante != null && estudiante.IniciarSesion(contraseña))
            {
                Console.WriteLine("Inicio de sesión exitoso como estudiante.");
                return estudiante; // El estudiante está autenticado correctamente
            }
            else
            {
                Console.WriteLine("Credenciales incorrectas. Intente de nuevo.");
                return null;
            }
        }

        // Método estático para cambiar la contraseña de un estudiante
        public static void CambiarContraseñaEstudiante(Estudiante estudiante)
        {
            Console.Write("Ingrese la nueva contraseña: ");
            string nuevaContraseña = Console.ReadLine();
            estudiante.CambiarContraseña(nuevaContraseña);

            // Actualiza la contraseña en el archivo JSON
            GuardarDatos.ActualizarContraseñaEstudiante(estudiante);
        }
    }
}
