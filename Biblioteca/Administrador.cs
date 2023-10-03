using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Administrador : Usuarios
    {
        public string Usuario { get; set; }

        public Administrador(string usuario, string contrasenia)
            : base("", contrasenia) // No es necesario pasar un nombre para el administrador
        {
            Usuario = usuario;
        }

        // Implementa el método abstracto de la clase base
        public override string GetInstancias()
        {
            return $"Nombre de usuario: {Usuario}\n" +
                   $"Contrasenia: {Contrasenia}\n";
        }

        // Método para iniciar sesión con un usuario y contraseña proporcionados
        public bool IniciarSesion(string usuario, string contrasenia)
        {
            return Usuario == usuario && Contrasenia == contrasenia;
        }
    }
}
