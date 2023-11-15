using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;
using System;

[TestClass]
public class InicioSesionTests
{
    [TestMethod]
    public void GenerarContraseniaProvisional_GeneraContraseniaValida()
    {
        try
        {
            // Arrange
            Estudiante estudiante = new Estudiante();
            InicioSesion inicioSesion = new InicioSesion();

            // Act
            inicioSesion.GenerarConstaseniaProvisoria(estudiante);

            // Assert
            Console.WriteLine($"Resultado para GenerarContraseniaProvisional_GeneraContraseniaValida: {estudiante.Contrasenia}");
            Assert.IsNotNull(estudiante.Contrasenia);
            Assert.AreNotEqual(string.Empty, estudiante.Contrasenia);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en GenerarContraseniaProvisional_GeneraContraseniaValida: {ex.Message}");
            Assert.Fail();
        }
    }

    [TestMethod]
    public void GenerarNumeroEstudiante_GeneraNumeroEstudianteValido()
    {
        try
        {
            // Arrange
            Estudiante estudiante = new Estudiante();
            InicioSesion inicioSesion = new InicioSesion();

            // Act
            inicioSesion.GenerarNumeroEstudiante(estudiante);

            // Assert
            Console.WriteLine($"Resultado para GenerarNumeroEstudiante_GeneraNumeroEstudianteValido: {estudiante.NumeroEstudiante}");
            Assert.IsTrue(estudiante.NumeroEstudiante > 0 && estudiante.NumeroEstudiante < 10000);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en GenerarNumeroEstudiante_GeneraNumeroEstudianteValido: {ex.Message}");
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ExisteNumeroIdentificacionEnLaBaseDeDatos_NumeroNoExiste_RetornaFalso()
    {
        try
        {
            // Arrange
            InicioSesion inicioSesion = new InicioSesion();
            string numeroNoExistente = "9999";

            // Act
            bool existe = inicioSesion.existeNumeroIdentificacionEnLaBaseDeDatos(numeroNoExistente);

            // Assert
            Console.WriteLine($"Resultado para ExisteNumeroIdentificacionEnLaBaseDeDatos_NumeroNoExiste_RetornaFalso: {existe}");
            Assert.IsFalse(existe);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ExisteNumeroIdentificacionEnLaBaseDeDatos_NumeroNoExiste_RetornaFalso: {ex.Message}");
            Assert.Fail();
        }
    }
}
