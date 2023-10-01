using System;

namespace Biblioteca
{
    public class Usuarios
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public Usuarios(string usuario, string contraseña)
        {
            Usuario = usuario;
            Contraseña = contraseña;
        }

        public bool IniciarSesion(string usuario, string contraseña)
        {
            return Usuario == usuario && Contraseña == contraseña;
        }
    }
}
