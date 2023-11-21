using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;
using System;

[TestClass]
public class HashTests
{
    [TestMethod]
    public void ObtenerHash_ContraseniaValida_RetornaCadenaNoVacia()
    {
        try
        {
            // Arrange
            string contrasenia = "miContraseniaSegura";

            // Act
            string hash = Hash.GetHash(contrasenia);

            // Assert
            Console.WriteLine($"Resultado para ObtenerHash_ContraseniaValida: {hash}");
            Assert.IsNotNull(hash);
            Assert.AreNotEqual(string.Empty, hash);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ObtenerHash_ContraseniaValida: {ex.Message}");
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ValidarContrasenia_ContraseniaCorrectaYHash_RetornaTrue()
    {
        try
        {
            // Arrange
            string contrasenia = "miContraseniaSegura";
            string hash = Hash.GetHash(contrasenia);

            // Act
            bool esValida = Hash.ValidatePassword(contrasenia, hash);

            // Assert
            Console.WriteLine($"Resultado para ValidarContrasenia_ContraseniaCorrectaYHash: {esValida}");
            Assert.IsTrue(esValida);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ValidarContrasenia_ContraseniaCorrectaYHash: {ex.Message}");
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ValidarContrasenia_ContraseniaIncorrectaYHash_RetornaFalse()
    {
        try
        {
            // Arrange
            string contraseniaCorrecta = "miContraseniaSegura";
            string contraseniaIncorrecta = "contraseniaIncorrecta";
            string hash = Hash.GetHash(contraseniaCorrecta);

            // Act
            bool esValida = Hash.ValidatePassword(contraseniaIncorrecta, hash);

            // Assert
            Console.WriteLine($"Resultado para ValidarContrasenia_ContraseniaIncorrectaYHash: {esValida}");
            Assert.IsFalse(esValida);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ValidarContrasenia_ContraseniaIncorrectaYHash: {ex.Message}");
            Assert.Fail();
        }
    }
}
