using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Cursos
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string DescripcionCurso { get; set; }
        public int CupoDisponibles { get; set; }
        public int NumeroInscriptos { get; set; }

        public Cursos(int codigo, string nombre, string descripcionCurso, int cupoDisponibles, int numeroInscriptos)
        {
            Codigo = codigo;
            Nombre = nombre;
            DescripcionCurso = descripcionCurso;
            CupoDisponibles = cupoDisponibles;
            NumeroInscriptos = numeroInscriptos;
        }

        public Cursos(string curso)
        {
            var datos = curso.Split('-');
            if (datos.Length == 5)
            {
                Codigo = int.Parse(datos[0]);
                Nombre = datos[1];
                DescripcionCurso = datos[2];
                CupoDisponibles = int.Parse(datos[3]);
                NumeroInscriptos = int.Parse(datos[4]);
            }
            else
            {
                throw new ArgumentException("La cadena proporcionada no contiene los datos requeridos para inicializar un curso.");
            }
        }

        public string GetInstancias()
        {
            return $"Código: {Codigo}\n" +
                $"Nombre: {Nombre}\n" +
                $"Descripción del Curso: {DescripcionCurso}\n" +
                $"Cupo Disponibles: {CupoDisponibles}\n" +
                $"Número de Inscriptos: {NumeroInscriptos}\n";
        }

        public static implicit operator Cursos(string curso)
        {
            return new Cursos(curso);
        }

        //creao un metodo para limitar el numero de inscriptos a el curso
        public bool HayCupo()
        {
            return CupoDisponibles >= NumeroInscriptos;
        }

        public bool NoHayCupo()
        {
            return NumeroInscriptos >= 30;
        }

        public void Inscribir()
        {
            NumeroInscriptos++;
        }

        public void Desinscribir()
        {
            NumeroInscriptos--;
        }

        public bool EsIgual(Cursos curso)
        {
            return Codigo == curso.Codigo;
        }

    }
}
