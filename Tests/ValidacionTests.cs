using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;
using System;

[TestClass]
public class ValidacionTests
{
    [TestMethod]
    public void ValidarCorreo_CorreoValido_RetornaTrue()
    {
        try
        {
            // Arrange
            string correoValido = "test@example.com";

            // Act
            bool esValido = Validacion.ValidarCorreo(correoValido);

            // Assert
            Console.WriteLine($"Resultado para ValidarCorreo_CorreoValido: {esValido}");
            Assert.IsTrue(esValido);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ValidarCorreo_CorreoValido: {ex.Message}");
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ValidarCorreo_CorreoInvalido_RetornaFalse()
    {
        try
        {
            // Arrange
            string correoInvalido = "invalidemail";

            // Act
            bool esValido = Validacion.ValidarCorreo(correoInvalido);

            // Assert
            Console.WriteLine($"Resultado para ValidarCorreo_CorreoInvalido: {esValido}");
            Assert.IsFalse(esValido);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ValidarCorreo_CorreoInvalido: {ex.Message}");
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ValidarNumeroTelefono_NumeroTelefonoValido_RetornaTrue()
    {
        try
        {
            // Arrange
            string numeroTelefonoValido = "12345678";

            // Act
            bool esValido = Validacion.ValidarNumeroTelefono(numeroTelefonoValido);

            // Assert
            Console.WriteLine($"Resultado para ValidarNumeroTelefono_NumeroTelefonoValido: {esValido}");
            Assert.IsTrue(esValido);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ValidarNumeroTelefono_NumeroTelefonoValido: {ex.Message}");
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ValidarNumeroTelefono_NumeroTelefonoInvalido_RetornaFalse()
    {
        try
        {
            // Arrange
            string numeroTelefonoInvalido = "1234";

            // Act
            bool esValido = Validacion.ValidarNumeroTelefono(numeroTelefonoInvalido);

            // Assert
            Console.WriteLine($"Resultado para ValidarNumeroTelefono_NumeroTelefonoInvalido: {esValido}");
            Assert.IsFalse(esValido);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ValidarNumeroTelefono_NumeroTelefonoInvalido: {ex.Message}");
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ValidarTarjetaCredito4numeros_NumeroValido_RetornaTrue()
    {
        try
        {
            // Arrange
            string numeroValido = "1234";

            // Act
            bool esValido = Validacion.ValidarTarjetaCredito4numeros(numeroValido);

            // Assert
            Console.WriteLine($"Resultado para ValidarTarjetaCredito4numeros_NumeroValido: {esValido}");
            Assert.IsTrue(esValido);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ValidarTarjetaCredito4numeros_NumeroValido: {ex.Message}");
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ValidarTarjetaCredito4numeros_NumeroInvalido_RetornaFalse()
    {
        try
        {
            // Arrange
            string numeroInvalido = "12";

            // Act
            bool esValido = Validacion.ValidarTarjetaCredito4numeros(numeroInvalido);

            // Assert
            Console.WriteLine($"Resultado para ValidarTarjetaCredito4numeros_NumeroInvalido: {esValido}");
            Assert.IsFalse(esValido);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ValidarTarjetaCredito4numeros_NumeroInvalido: {ex.Message}");
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ValidarTarjetaCredito3numeros_NumeroValido_RetornaTrue()
    {
        try
        {
            // Arrange
            string numeroValido = "123";

            // Act
            bool esValido = Validacion.ValidarTarjetaCredito3numeros(numeroValido);

            // Assert
            Console.WriteLine($"Resultado para ValidarTarjetaCredito3numeros_NumeroValido: {esValido}");
            Assert.IsTrue(esValido);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ValidarTarjetaCredito3numeros_NumeroValido: {ex.Message}");
            Assert.Fail();
        }
    }

    [TestMethod]
    public void ValidarTarjetaCredito3numeros_NumeroInvalido_RetornaFalse()
    {
        try
        {
            // Arrange
            string numeroInvalido = "12";

            // Act
            bool esValido = Validacion.ValidarTarjetaCredito3numeros(numeroInvalido);

            // Assert
            Console.WriteLine($"Resultado para ValidarTarjetaCredito3numeros_NumeroInvalido: {esValido}");
            Assert.IsFalse(esValido);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción en ValidarTarjetaCredito3numeros_NumeroInvalido: {ex.Message}");
            Assert.Fail();
        }
    }
}
