using System;

namespace Biblioteca
{
    public class Cursos
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string DescripcionCurso { get; set; }
        public int CupoDisponibles { get; set; }
        public int NumeroInscriptos { get; set; }

        public Cursos()
        {
            // Valores predeterminados para las propiedades
            this.Codigo = 0;
            this.Nombre = "";
            this.DescripcionCurso = "";
            this.CupoDisponibles = 0;
            this.NumeroInscriptos = 0;
        }

        public Cursos(int codigo, string nombre, string descripcionCurso, int cupoDisponibles, int numeroInscriptos)
        {
            Codigo = codigo;
            Nombre = nombre;
            DescripcionCurso = descripcionCurso;
            CupoDisponibles = cupoDisponibles;
            NumeroInscriptos = numeroInscriptos;
        }

        // Constructor que acepta una cadena para inicializar las propiedades
        public Cursos(string linea)
        {
            // Divide la línea en sus componentes
            var partes = linea.Split(';');

            // Asegúrate de que haya suficientes componentes para inicializar las propiedades
            if (partes.Length >= 5)
            {
                if (int.TryParse(partes[0], out int codigo))
                {
                    Codigo = codigo;
                }
                Nombre = partes[1];
                DescripcionCurso = partes[2];
                if (int.TryParse(partes[3], out int cupoDisponibles))
                {
                    CupoDisponibles = cupoDisponibles;
                }
                if (int.TryParse(partes[4], out int numeroInscriptos))
                {
                    NumeroInscriptos = numeroInscriptos;
                }
            }
            else
            {
                throw new ArgumentException("La línea de datos no tiene suficientes componentes.");
            }
        }

        // Método para obtener una representación en cadena de las instancias de Cursos
        public string GetInstancias()
        {
            return
                $"Código: {Codigo}\n" +
                $"Nombre: {Nombre}\n" +
                $"Descripción: {DescripcionCurso}\n" +
                $"Cupo Disponibles: {CupoDisponibles}\n" +
                $"Número de Inscriptos: {NumeroInscriptos}\n";
        }

        // Operador de conversión implícita para crear un Cursos a partir de una cadena
        public static implicit operator Cursos(string curso)
        {
            // Método para convertir una cadena en un objeto Cursos
            var datos = curso.Split(';');
            return new Cursos(
                int.Parse(datos[0]),
                datos[1],
                datos[2],
                int.Parse(datos[3]),
                int.Parse(datos[4])
            );
        }

        public void CambiarCodigo(string nuevaCodigo)
        {
            Codigo = int.Parse(nuevaCodigo);
        }

        public void CambiarNombre(string nuevoNombre)
        {
            Nombre = nuevoNombre;
        }

        public void CambiarDescripcion(string nuevaDescripcion)
        {
            DescripcionCurso = nuevaDescripcion;
        }

        public void CambiarCupo(string nuevoCupo)
        {
            CupoDisponibles = int.Parse(nuevoCupo);
        }
    }
}
