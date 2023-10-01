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
        public string materiaUno { get; set; }
        public string materiaDos { get; set; }
        public string materiaTres { get; set; }
        public string materiaCuatro { get; set; }
        public string materiaCinco { get; set; }
        public string materiaSeis { get; set; }
        public string CuatrimestreEstudiante { get; set; }
        public string PagoMatricula { get; set; }
        public string PagoCargosAdministrativos { get; set; }
        public string PagoUtilidades { get; set; }


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
            this.CuatrimestreEstudiante = "";
            this.materiaUno = "";
            this.materiaDos = "";
            this.materiaTres = "";
            this.materiaCuatro = "";
            this.materiaCinco = "";
            this.materiaSeis = "";
            this.PagoMatricula = "";
            this.PagoCargosAdministrativos = "";
            this.PagoUtilidades = "";
        }

        public Estudiante(string nombreCompleto, string apellidoCompleto, string contraseña, string direccion, string numeroTelefono, string correoElectronico, int numeroEstudiante, string cuatrimestreEstudiante,string materiauno, string materiados , string materiatres , string materiacuatro , string materiacinco , string materiaseis , string pagomatricula ,string pagocargos ,string pagoutilidades)
        {
            // Constructor que permite inicializar todas las propiedades de Estudiante
            NombreCompleto = nombreCompleto;
            ApellidoCompleto = apellidoCompleto;
            Contrasenia = contraseña;
            Direccion = direccion;
            NumeroTelefono = numeroTelefono;
            CorreoElectronico = correoElectronico;
            NumeroEstudiante = numeroEstudiante;
            CuatrimestreEstudiante = cuatrimestreEstudiante;
            materiaUno = materiauno;
            materiaDos = materiados;
            materiaTres = materiatres;
            materiaCuatro = materiacuatro;
            materiaCinco = materiacinco;
            materiaSeis = materiaseis;
            PagoMatricula = pagomatricula;
            PagoCargosAdministrativos = pagocargos;
            PagoUtilidades = pagoutilidades;
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
                $"Número de estudiante: {NumeroEstudiante}\n" +
                $"Cuatrimestre: {CuatrimestreEstudiante}\n" +
                $"Materia 1: {materiaUno}\n" +
                $"Materia 2: {materiaDos}\n" +
                $"Materia 3: {materiaTres}\n" +
                $"Materia 4: {materiaCuatro}\n" +
                $"Materia 5: {materiaCinco}\n" +
                $"Materia 6: {materiaSeis}\n" +
                $"Pago de matrícula: {PagoMatricula}\n" +
                $"Pago de cargos administrativos: {PagoCargosAdministrativos}\n" +
                $"Pago de utilidades: {PagoUtilidades}\n";
        }

        // Operador de conversión implícita para crear un Estudiante a partir de una cadena
        public static implicit operator Estudiante(string estudiante)
        {
            // Método para convertir una cadena en un objeto Estudiante
            var datos = estudiante.Split('-');
            return new Estudiante(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], int.Parse(datos[6]), datos[7], datos[8], datos[9], datos[10], datos[11], datos[12], datos[13], datos[14], datos[15], datos[16]);
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
