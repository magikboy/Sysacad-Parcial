using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Menu
    {
        private List<Materia> materias = new List<Materia>();
        private List<Estudiante> estudiantes = new List<Estudiante>();

        public Menu()
        {
            // Agrega las materias predefinidas aquí
            materias.Add(new Materia("Matemáticas", 5));
            materias.Add(new Materia("Programación", 5));
            materias.Add(new Materia("Laboratorio", 5));
            materias.Add(new Materia("Inglés", 5));

            // Carga los estudiantes desde el archivo JSON
            CargarEstudiantesDesdeJSON();
        }

        // Cargar la lista de estudiantes desde el archivo JSON si existe

        public void CargarEstudiantesDesdeJSON()
        {
            // Cargar la lista de estudiantes desde el archivo JSON si existe
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");
        }

        public void RegistrarEstudiante(Estudiante nuevoEstudiante, Sistema sistema)
        {
            // Agrega el nuevo estudiante a la lista de estudiantes
            Console.Clear();
            Console.WriteLine("Registrar Estudiante:");
            Console.Write("Nombre completo: ");
            string nombreCompleto = Console.ReadLine();
            //guardo dato
            nuevoEstudiante.NombreCompleto = nombreCompleto;
            Console.Write("Apellido: ");
            string apellidoCompleto = Console.ReadLine();
            //guardo dato
            nuevoEstudiante.ApellidoCompleto = apellidoCompleto;
            Console.Write("Direccion: ");
            string direccion = Console.ReadLine();
            //guardo dato
            nuevoEstudiante.Direccion = direccion;
            //validar que el numero de telefono sea valido
            bool numeroTelefonoValido = false;
            while (!numeroTelefonoValido)
            {
                Console.Write("Número de teléfono: ");
                string numeroTelefono2 = Console.ReadLine();
                numeroTelefonoValido = Validacion.ValidarNumeroTelefono(numeroTelefono2);
                if (!numeroTelefonoValido)
                {
                    Console.WriteLine("Número de teléfono no válido. Intente de nuevo.");
                }
                else
                {
                    //guardo dato
                    nuevoEstudiante.NumeroTelefono = numeroTelefono2;
                }
            }
            //validar que el correo sea valido
            bool correoValido = false;
            while (!correoValido)
            {
                Console.Write("Correo electrónico: ");
                string correoElectronico = Console.ReadLine();
                correoValido = Validacion.ValidarCorreo(correoElectronico);
                if (!correoValido)
                {
                    Console.WriteLine("Correo electrónico no válido. Intente de nuevo.");
                }
                else
                {
                    //guardo dato
                    nuevoEstudiante.CorreoElectronico = correoElectronico;
                }
            }
            //guardo dato del estudiante
            nuevoEstudiante.CorreoElectronico = nuevoEstudiante.CorreoElectronico;
            //El administrador puede elegir si el estudiante debe cambiar su contraseña provisional en su primer inicio de sesión.
            Console.Write("¿El estudiante debe cambiar su contraseña provisional en su primer inicio de sesión? (S/N): ");
            string opcion = Console.ReadLine();
            if (opcion == "S" || opcion == "s")
            {
                Console.Write("Contraseña provisional: ");
                string contraseñaProvisional = Console.ReadLine();
                //guardo dato
                nuevoEstudiante.Contrasenia = contraseñaProvisional;
                // En este ejemplo, simplemente actualizamos la propiedad ContraseñaProvisional con la nueva contraseña.
                Console.WriteLine("Contraseña cambiada con éxito.");
                Console.WriteLine("Estudiante registrado con éxito.");
                //guardo dato
                estudiantes.Add(nuevoEstudiante);
            }
            else
            {
                Console.WriteLine("Estudiante registrado con éxito.");
                //guardo dato
                estudiantes.Add(nuevoEstudiante);
            }


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

            GuardarDatos.WriteStreamJSON("estudiantes.json", estudiantes);
        }

        public void InscribirEstudianteEnMateria()
        {
            Console.Clear();
            Console.WriteLine("Materias Disponibles:");

            // Mostrar el nombre de las materias disponibles para inscribirse
            for (int i = 0; i < materias.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {materias[i].Nombre}");
            }

            Console.Write("Seleccione una materia (1 - 4): ");
            if (int.TryParse(Console.ReadLine(), out int materiaSeleccionada) && materiaSeleccionada >= 1 && materiaSeleccionada <= materias.Count)
            {
                Materia materia = materias[materiaSeleccionada - 1];

                Console.Write("Nombre del estudiante: ");
                string nombreEstudiante = Console.ReadLine();
                Console.Write("Apellido del estudiante: ");
                string apellidoEstudiante = Console.ReadLine();

                Estudiante estudiante = estudiantes.Find(e => e.NombreCompleto == nombreEstudiante && e.ApellidoCompleto == apellidoEstudiante);

                if (estudiante != null)
                {
                    materia.InscribirEstudiante(estudiante);
                }
                else
                {
                    Console.WriteLine("Estudiante no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Selección no válida. Intente de nuevo.");
            }
        }

        public void MostrarRegistroFinal()
        {
            Console.Clear();
            Console.WriteLine("Registro Final:");

            foreach (var materia in materias)
            {
                Console.WriteLine($"Materia: {materia.Nombre}");
                Console.WriteLine("Estudiantes Inscritos:");

                foreach (var estudiante in materia.EstudiantesInscritos)
                {
                    Console.WriteLine($"{estudiante.NombreCompleto} {estudiante.ApellidoCompleto}");
                }

                Console.WriteLine();
            }
        }

        public void AgregarMateria(Materia materia)
        {
            materias.Add(materia);
        }

        public static void MostrarMenuAdministrador()
        {
            Menu menu = new Menu(); // Crea una instancia de Menu
            Estudiante estudiantes = new Estudiante(); // Crea una instancia de Estudiante
            Sistema sistema = new Sistema(); // Crea una instancia de Sistema

            Console.WriteLine("Menú de administrador:");
            Console.WriteLine("1. Registrar Estudiante");
            Console.WriteLine("2. Inscribir Estudiante En una Materia");
            Console.WriteLine("3. Mostrar Registro");
            Console.WriteLine("4. Cerrar sesión");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            // Agrega lógica para cada opción del menú del administrador
            switch (opcion)
            {
                case "1":
                    menu.RegistrarEstudiante(estudiantes, sistema); // Llama al método de instancia
                    break;

                case "2":
                    menu.InscribirEstudianteEnMateria(); // Llama al método de instancia
                    break;

                case "3":
                    menu.MostrarRegistroFinal(); // Llama al método de instancia
                    break;
                case "4":
                    Console.WriteLine("Saliendo del sistema...");
                    Environment.Exit(0);
                    break;
                    
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }

        public static void MostrarMenuEstudiante(Estudiante estudiante)
        {
            // Implementa aquí el menú para el estudiante
            Console.WriteLine($"Menú de estudiante ({estudiante.NombreCompleto}):");
            Console.WriteLine("1. Ver información del estudiante");
            Console.WriteLine("2. Cambiar contraseña");
            Console.WriteLine("3. Otra opción del estudiante");
            Console.WriteLine("4. Cerrar sesión");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();
            // Agrega lógica para cada opción del menú del estudiante

            switch (opcion)
            {
                case "1":
                    Console.WriteLine($"Nombre: {estudiante.NombreCompleto}");
                    Console.WriteLine($"Número de identificación: {estudiante.NumeroEstudiante}");
                    Console.WriteLine($"Correo electrónico: {estudiante.CorreoElectronico}");
                    break;

                case "2":
                    InicioSesion.CambiarContraseñaEstudiante(estudiante);
                    break;
                case "3":
                    Console.WriteLine("Otra opción del estudiante");
                    break;

                case "4":
                    Console.WriteLine("Saliendo del sistema...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
