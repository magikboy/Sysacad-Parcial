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
        public int HorarioMin { get; set; }
        public int HorarioMax { get; set; }
        public string Profesor { get; set; }
        public string Cuatrimestre { get; set; }

        public Cursos()
        {
            // Valores predeterminados para las propiedades
            this.Codigo = 0;
            this.Nombre = "";
            this.DescripcionCurso = "";
            this.CupoDisponibles = 0;
            this.NumeroInscriptos = 0;
            this.HorarioMin = 0;
            this.HorarioMax = 0;
            this.Profesor = "";
            this.Cuatrimestre = "";

        }

        public Cursos(int codigo, string nombre, string descripcionCurso, int cupoDisponibles, int numeroInscriptos , int horarioMin,int horarioMax ,string profesor,string cuatrimestre)
        {
            Codigo = codigo;
            Nombre = nombre;
            DescripcionCurso = descripcionCurso;
            CupoDisponibles = cupoDisponibles;
            NumeroInscriptos = numeroInscriptos;
            HorarioMin = horarioMin;
            HorarioMax = horarioMax;
            Profesor = profesor;
            Cuatrimestre = cuatrimestre;
        }

        // Constructor que acepta una cadena para inicializar las propiedades
        public Cursos(string linea)
        {
            // Divide la línea en sus componentes
            var partes = linea.Split(';');

            // Asegúrate de que haya suficientes componentes para inicializar las propiedades
            if (partes.Length >= 6)
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
                if (int.TryParse(partes[5], out int horario))
                {
                    HorarioMin = horario;
                }
                if (int.TryParse(partes[6], out int horarioMax))
                {
                    HorarioMax = horarioMax;
                }
                Profesor = partes[6];
                Cuatrimestre = partes[7];
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
                $"Número de Inscriptos: {NumeroInscriptos}\n"+
                $"Horario: {HorarioMin}\n"+
                $"Horario: {HorarioMax}\n"+
                $"Profesor: {Profesor}\n"+
                $"Cuatrimestre: {Cuatrimestre}\n";
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
                int.Parse(datos[4]),
                int.Parse(datos[5]),
                int.Parse(datos[6]),
                datos[7],
                datos[8]
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

        public void CambiarNumeroInscriptos(string nuevoNumeroInscriptos)
        {
            NumeroInscriptos = int.Parse(nuevoNumeroInscriptos);
        }

        public void CambiarHorarioMin(string nuevoHorario)
        {
            HorarioMin = int.Parse(nuevoHorario);
        }

        public void CambiarHorarioMax(string nuevoHorarioMax)
        {
            HorarioMax = int.Parse(nuevoHorarioMax);
        }

        public void CambiarProfesor(string nuevoProfesor)
        {
            Profesor = nuevoProfesor;
        }

        public void CambiarCuatrimestre(string nuevoCuatrimestre)
        {
            Cuatrimestre = nuevoCuatrimestre;
        }
    }
}
