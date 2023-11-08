using System;

namespace Biblioteca
{
    public class Profesor : Usuarios
    {
        public string NombreCompleto { get; set; }
        public string ApellidoCompleto { get; set; }
        public string Direccion { get; set; }
        public string NumeroTelefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Area { get; set; }
        public string CursosAsignados { get; set; }

        public Profesor(string nombreCompleto, string apellidoCompleto, string direccion, string numeroTelefono, string correoElectronico, string area, string cursosAsignados)
            : base(nombreCompleto, "")
        {
            NombreCompleto = nombreCompleto;
            ApellidoCompleto = apellidoCompleto;
            Direccion = direccion;
            NumeroTelefono = numeroTelefono;
            CorreoElectronico = correoElectronico;
            Area = area;
            CursosAsignados = cursosAsignados;
        }

        public override string GetInstancias()
        {
            return $"Nombre: {NombreCompleto}\n" +
                   $"Apellido: {ApellidoCompleto}\n" +
                   $"Dirección: {Direccion}\n" +
                   $"Número de teléfono: {NumeroTelefono}\n" +
                   $"Correo electrónico: {CorreoElectronico}\n" +
                   $"Área: {Area}\n" +
                   $"Cursos Asignados: {CursosAsignados}\n";
        }
    }
}
