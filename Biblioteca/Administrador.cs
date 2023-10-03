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
        public string Contrasenia { get; set; }


        // Constructor de la clase Administrador
        public Administrador(string usuario, string contrasenia)
        {
            Usuario = usuario;
            Contrasenia = contrasenia;
        }

        // Método para iniciar sesión con un usuario y contraseña proporcionados
        public bool IniciarSesion(string usuario, string contrasenia)
        {
            return Usuario == usuario && Contrasenia == contrasenia;
        }
    }
}
