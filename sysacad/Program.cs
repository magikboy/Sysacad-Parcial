using Biblioteca;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        EjecutarPruebas();
    }

    static void EjecutarPruebas()
    {
        Console.WriteLine("#--------------------------------------------------------------------------------------#");
        Console.WriteLine();
        // Prueba del conjunto de pruebas HashTests
        Console.WriteLine("Ejecutando HashTests:");
        HashTests hashTests = new HashTests();
        hashTests.ObtenerHash_ContraseniaValida_RetornaCadenaNoVacia();
        hashTests.ValidarContrasenia_ContraseniaCorrectaYHash_RetornaTrue();
        hashTests.ValidarContrasenia_ContraseniaIncorrectaYHash_RetornaFalse();
        Console.WriteLine();
        Console.WriteLine("#--------------------------------------------------------------------------------------#");
        Console.WriteLine();
        // Prueba del conjunto de pruebas ValidacionTests
        Console.WriteLine("Ejecutando ValidacionTests:");
        ValidacionTests validacionTests = new ValidacionTests();
        validacionTests.ValidarCorreo_CorreoValido_RetornaTrue();
        validacionTests.ValidarCorreo_CorreoInvalido_RetornaFalse();
        validacionTests.ValidarNumeroTelefono_NumeroTelefonoValido_RetornaTrue();
        validacionTests.ValidarNumeroTelefono_NumeroTelefonoInvalido_RetornaFalse();
        validacionTests.ValidarTarjetaCredito4numeros_NumeroValido_RetornaTrue();
        validacionTests.ValidarTarjetaCredito4numeros_NumeroInvalido_RetornaFalse();
        validacionTests.ValidarTarjetaCredito3numeros_NumeroValido_RetornaTrue();
        validacionTests.ValidarTarjetaCredito3numeros_NumeroInvalido_RetornaFalse();
        Console.WriteLine();
        Console.WriteLine("#--------------------------------------------------------------------------------------#");
        Console.WriteLine();
        // Prueba del conjunto de pruebas InicioSesionTests
        Console.WriteLine("Ejecutando InicioSesionTests:");
        InicioSesionTests inicioSesionTests = new InicioSesionTests();
        inicioSesionTests.GenerarContraseniaProvisional_GeneraContraseniaValida();
        inicioSesionTests.GenerarNumeroEstudiante_GeneraNumeroEstudianteValido();
        inicioSesionTests.ExisteNumeroIdentificacionEnLaBaseDeDatos_NumeroNoExiste_RetornaFalso();
        Console.WriteLine();
        Console.WriteLine("#--------------------------------------------------------------------------------------#");
        Console.WriteLine();
    }
}
