using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Validacion
    {
        //validar que el correo sea valido
        public static bool ValidarCorreo(string correo)
        {
            if (correo.Contains("@") && correo.Contains("."))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //validar si el administrador quiere cambiar su contraseña provisional

        public static bool ValidarContraseña(string contraseña)
        {
            if (contraseña.Length >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //valiar que el numero de identificacion sea valido

        public static bool ValidarNumeroIdentificacion(string numeroIdentificacion)
        {
            if (numeroIdentificacion.Length == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // validar que el numero de identificacion no este repetido

        public static bool ValidarNumeroIdentificacionRepetido(string numeroEstudiante, List<Estudiante> estudiantes)
        {
            foreach (Estudiante estudiante in estudiantes)
            {
                if (estudiante.NumeroEstudiante.ToString() == numeroEstudiante)
                {
                    return false;
                }
            }
            return true;
        }

        //validar que el numero de telefono sea valido
        public static bool ValidarNumeroTelefono(string numeroTelefono)
        {
            if (numeroTelefono.Length == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //validar que el numero del estudiante no este repetido
        public static bool ValidarNumeroEstudianteRepetido(string numeroEstudiante, List<Estudiante> estudiantes)
        {
            foreach (Estudiante estudiante in estudiantes)
            {
                if (estudiante.NumeroEstudiante.ToString() == numeroEstudiante)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
