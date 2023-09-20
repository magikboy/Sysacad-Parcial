using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    // Clase Sistema
    public class Sistema
    {

        public Sistema()
        {
            // Constructor vacío
        }

        // Métodos para interactuar con el sistema
        public void SeleccionarRegistrarEstudiante()
        {
            // Implementación para seleccionar "Registrar Estudiante"
            Console.WriteLine("Seleccionando 'Registrar Estudiante'...");
        }

        public void GenerarNumeroEstudiante(Estudiante estudiante)
        {
            // crear numero aleatorio para el estudiante
            Random random = new Random();
            int numeroEstudiante = random.Next(1, 9999);
            estudiante.NumeroEstudiante = numeroEstudiante;
            //valida que el numero no este repetido y lo crea
            while (existeNumeroIdentificacionEnLaBaseDeDatos(numeroEstudiante.ToString()))
            {
                numeroEstudiante = random.Next(1, 9999);
                estudiante.NumeroEstudiante = numeroEstudiante;
            }
        }

        public void GenerarConstaseniaProvisoria(Estudiante estudiante)
        {
            //generar contraseña provisoria para el estudiante una vez registrado
            string contraseña = "1234";
            estudiante.Contrasenia = contraseña;
        }

        public void ConfirmarRegistro(Estudiante estudiante)
        {
            // Implementación para confirmar el registro del estudiante en el sistema
            Console.WriteLine($"Estudiante {estudiante.NombreCompleto} registrado con éxito.");
        }

        public bool existeNumeroIdentificacionEnLaBaseDeDatos(string numeroIdentificacion)
        {
            // fijarse en el json si existe el numero de identificacion
            List<Estudiante> estudiantes = new List<Estudiante>();
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");
            foreach (Estudiante estudiante in estudiantes)
            {
                if (estudiante.NumeroEstudiante.ToString() == numeroIdentificacion)
                {
                    return true;
                }
            }

            return false;
        }

        public bool existeCorreoElectronicoEnLaBaseDeDatos(string correoElectronico)
        {
            // Implementar la lógica real para verificar si el correo electrónico existe en la base de datos
            return false;
        }

        public void EnviarNotificacionEstudiante(Estudiante estudiante, string mensaje)
        {

            // Implementación para enviar una notificación por correo electrónico al estudiante
            Console.WriteLine($"Enviando notificación al estudiante {estudiante.NombreCompleto} al correo {estudiante.CorreoElectronico}...");
            Console.WriteLine($"Mensaje: {mensaje}");
        }

        public void GuardarEstudianteEnLaBaseDeDatos(Estudiante estudiante)
        {
            // Implementación para guardar el estudiante en la base de datos
            Console.WriteLine($"Guardando estudiante {estudiante.NombreCompleto} en la base de datos...");
        }

        public bool ExisteEstudianteEnLaBaseDeDatos(Estudiante estudiante)
        {
            // Implementación para verificar si el estudiante existe en la base de datos
            Console.WriteLine($"Verificando si el estudiante {estudiante.NombreCompleto} existe en la base de datos...");
            return false;
        }
    }

}
