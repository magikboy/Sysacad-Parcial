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


        //validar que se ingresaron 4 numeros para la tarjeta de credito
        public static bool ValidarTarjetaCredito4numeros(string tarjetaCredito)
        {
            if (tarjetaCredito.Length == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //validar que se ingresaron 3 numeros para la tarjeta de credito
        public static bool ValidarTarjetaCredito3numeros(string tarjetaCredito)
        {
            if (tarjetaCredito.Length == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
