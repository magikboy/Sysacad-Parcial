using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    // Clase Estudiante
    public class Estudiante
    {
        // Propiedades públicas de la clase Estudiante
        public string NombreCompleto { get; set; }
        public string ApellidoCompleto { get; set; }
        public string Contrasenia { get; set; }
        public string Direccion { get; set; }
        public string NumeroTelefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int NumeroEstudiante { get; set; }

        // Constructores de la clase Estudiante
        public Estudiante()
        {
            // Valores predeterminados para las propiedades
            this.NombreCompleto = "";
            this.ApellidoCompleto = "";
            this.Contrasenia = "";
            this.Direccion = "";
            this.NumeroTelefono = "";
            this.CorreoElectronico = "";
            this.NumeroEstudiante = 0;
        }

        public Estudiante(string nombreCompleto, string apellidoCompleto, string contraseña, string direccion, string numeroTelefono, string correoElectronico, int numeroEstudiante)
        {
            // Constructor que permite inicializar todas las propiedades de Estudiante
            NombreCompleto = nombreCompleto;
            ApellidoCompleto = apellidoCompleto;
            Contrasenia = contraseña;
            Direccion = direccion;
            NumeroTelefono = numeroTelefono;
            CorreoElectronico = correoElectronico;
            NumeroEstudiante = numeroEstudiante;
        }

        // Método para obtener una representación en cadena de las instancias de Estudiante
        public string GetInstancias()
        {
            return
                $"Nombre: {NombreCompleto}\n" +
                $"Apellido: {ApellidoCompleto}\n" +
                $"Contrasenia: {Contrasenia}\n" +
                $"Dirección: {Direccion}\n" +
                $"Número de teléfono: {NumeroTelefono}\n" +
                $"Correo electrónico: {CorreoElectronico}\n" +
                $"Número de estudiante: {NumeroEstudiante}\n";
        }

        // Operador de conversión implícita para crear un Estudiante a partir de una cadena
        public static implicit operator Estudiante(string estudiante)
        {
            // Método para convertir una cadena en un objeto Estudiante
            var datos = estudiante.Split('-');
            return new Estudiante(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], int.Parse(datos[6]));
        }

        // Método para iniciar sesión del estudiante
        public bool IniciarSesion(string contraseña)
        {
            return Contrasenia == contraseña;
        }

        // Método para que el estudiante cambie su contraseña
        public void CambiarContraseña(string nuevaContraseña)
        {
            Contrasenia = nuevaContraseña;
        }
    }
}
