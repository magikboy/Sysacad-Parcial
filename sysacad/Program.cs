using Biblioteca;
using System;
using System.Collections.Generic;

class Program
{
    static Administrador administrador = new Administrador("admin", "1234"); // Credenciales de administrador

    static void Main()
    {
        // Inicializo el sistema

        bool salir = false;
        while (!salir)

        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Bienvenido al sistema de registro. Seleccione una opción:");
            Console.WriteLine("1. Iniciar sesión como Administrador");
            Console.WriteLine("2. Iniciar sesión como Estudiante");
            Console.WriteLine("3. Salir");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    InicioSesion.IniciarSesionAdministrador();
                    break;
                case "2":
                    InicioSesion inicioSesion = new InicioSesion();
                    Estudiante estudianteAutenticado = inicioSesion.IniciarSesionEstudiante();
                    if (estudianteAutenticado != null)
                    {
                        Menu.MostrarMenuEstudiante(estudianteAutenticado);
                    }
                    break;
                case "3":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}