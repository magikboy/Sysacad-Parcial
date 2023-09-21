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
