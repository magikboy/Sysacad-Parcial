﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class InicioSesion
    {
        public void GenerarConstaseniaProvisoria(Estudiante estudiante)
        {
            //generar contraseña provisoria para el estudiante una vez registrado
            string contraseña = "1234";
            estudiante.Contrasenia = contraseña;
        }

        public void GenerarNumeroEstudiante(Estudiante estudiante)
        {
            // crear numero aleatorio para el estudiante
            Random random = new Random();
            int numeroEstudiante = random.Next(1, 9999);
            estudiante.NumeroEstudiante = numeroEstudiante;
            //valida que el numero no este repetido y lo crea
            while (existeNumeroIdentificacionEnLaBaseDeDatos(numeroEstudiante.ToString()))
            {
                numeroEstudiante = random.Next(1, 9999);
                estudiante.NumeroEstudiante = numeroEstudiante;
            }
        }
        public bool existeNumeroIdentificacionEnLaBaseDeDatos(string numeroIdentificacion)
        {
            // fijarse en el json si existe el numero de identificacion
            List<Estudiante> estudiantes = new List<Estudiante>();
            estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
            foreach (Estudiante estudiante in estudiantes)
            {
                if (estudiante.NumeroEstudiante.ToString() == numeroIdentificacion)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
