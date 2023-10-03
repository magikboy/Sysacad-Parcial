using System;

namespace Biblioteca
{
    // Clase Estudiante que hereda de Usuarios
    public class Estudiante : Usuarios
    {
        // Propiedades específicas de la clase Estudiante
        public string ApellidoCompleto { get; set; }
        public string Direccion { get; set; }
        public string NumeroTelefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int NumeroEstudiante { get; set; }
        public string CuatrimestreEstudiante { get; set; }
        public string MateriaUno { get; set; }
        public string MateriaDos { get; set; }
        public string MateriaTres { get; set; }
        public string MateriaCuatro { get; set; }
        public string MateriaCinco { get; set; }
        public string MateriaSeis { get; set; }
        public string PagoMatricula { get; set; }
        public string PagoCargosAdministrativos { get; set; }
        public string PagoUtilidades { get; set; }
        public string HistorialAcademico { get; set; }

        // Constructor sin parámetros requerido para deserialización JSON
        public Estudiante()
            : base("", "") 
        {
            // si es que tengo que inicializar las propiedades segun el caso
        }

        // Constructor de la clase Estudiante
        public Estudiante(string nombreCompleto, string apellidoCompleto, string contrasenia, string direccion, string numeroTelefono, string correoElectronico, int numeroEstudiante, string cuatrimestreEstudiante, string materiaUno, string materiaDos, string materiaTres, string materiaCuatro, string materiaCinco, string materiaSeis, string pagoMatricula, string pagoCargos, string pagoUtilidades, string historialAcademico)
            : base(nombreCompleto, contrasenia)
        {
            ApellidoCompleto = apellidoCompleto;
            Direccion = direccion;
            NumeroTelefono = numeroTelefono;
            CorreoElectronico = correoElectronico;
            NumeroEstudiante = numeroEstudiante;
            CuatrimestreEstudiante = cuatrimestreEstudiante;
            MateriaUno = materiaUno;
            MateriaDos = materiaDos;
            MateriaTres = materiaTres;
            MateriaCuatro = materiaCuatro;
            MateriaCinco = materiaCinco;
            MateriaSeis = materiaSeis;
            PagoMatricula = pagoMatricula;
            PagoCargosAdministrativos = pagoCargos;
            PagoUtilidades = pagoUtilidades;
            HistorialAcademico = historialAcademico;
        }

        // Implementa el método abstracto de la clase base
        public override string GetInstancias()
        {
            return $"Nombre: {NombreCompleto}\n" +
                   $"Apellido: {ApellidoCompleto}\n" +
                   $"Contrasenia: {Contrasenia}\n" +
                   $"Dirección: {Direccion}\n" +
                   $"Número de teléfono: {NumeroTelefono}\n" +
                   $"Correo electrónico: {CorreoElectronico}\n" +
                   $"Número de estudiante: {NumeroEstudiante}\n" +
                   $"Cuatrimestre: {CuatrimestreEstudiante}\n" +
                   $"Materia 1: {MateriaUno}\n" +
                   $"Materia 2: {MateriaDos}\n" +
                   $"Materia 3: {MateriaTres}\n" +
                   $"Materia 4: {MateriaCuatro}\n" +
                   $"Materia 5: {MateriaCinco}\n" +
                   $"Materia 6: {MateriaSeis}\n" +
                   $"Pago de matrícula: {PagoMatricula}\n" +
                   $"Pago de cargos administrativos: {PagoCargosAdministrativos}\n" +
                   $"Pago de utilidades: {PagoUtilidades}\n" +
                   $"Historial académico: {HistorialAcademico}\n";
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

        // Método para que el estudiante cambie su historial académico
        public void CambiarHistorialAcademico(string nuevoHistorialAcademico)
        {
            HistorialAcademico = nuevoHistorialAcademico;
        }
    }
}
