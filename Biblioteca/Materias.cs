using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Materia
    {
        public string Nombre { get; }
        public int CuposDisponibles { get; private set; }
        public List<Estudiante> EstudiantesInscritos { get; }

        // Constructor de la clase Materia
        public Materia(string nombre, int cuposDisponibles)
        {
            Nombre = nombre;
            CuposDisponibles = cuposDisponibles;
            EstudiantesInscritos = new List<Estudiante>();
        }

        // Método para inscribir a un estudiante en la materia
        public void InscribirEstudiante(Estudiante estudiante)
        {
            if (CuposDisponibles > 0)
            {
                if (!EstudiantesInscritos.Contains(estudiante))
                {
                    EstudiantesInscritos.Add(estudiante);
                    CuposDisponibles--;
                }
        }
    }
    }
}



