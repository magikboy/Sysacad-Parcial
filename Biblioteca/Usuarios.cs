using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    // Clase abstracta Usuarios que servirá como clase base
    public abstract class Usuarios
    {
        // Propiedades comunes a todas las clases derivadas
        public string NombreCompleto { get; set; }
        public string Contrasenia { get; set; }

        // Constructor de la clase base Usuarios
        public Usuarios(string nombreCompleto, string contrasenia)
        {
            NombreCompleto = nombreCompleto;
            Contrasenia = contrasenia;
        }

        // Método para iniciar sesión con un usuario y contraseña proporcionados
        public bool IniciarSesion(string contrasenia)
        {
            return Contrasenia == contrasenia;
        }

        // Método abstracto para obtener una representación en cadena de las instancias
        public abstract string GetInstancias();
    }
}
