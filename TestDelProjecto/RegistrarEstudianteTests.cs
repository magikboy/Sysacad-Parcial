namespace TestDelProjecto
{
    [TestClass]
    public class RegistrarEstudianteTests
    {
        [TestMethod]

        public void GenerarNumeroEstudiante_ValidInput_ReturnsNonZero()
        {
            // Arrange
            RegistrarEstudiante registrarEstudiante = new RegistrarEstudiante();
            Estudiante estudiante = new Estudiante("John", "Doe", "password", "123 Main St", "555-555-5555", "john@example.com", 0, "Cuatro", "", "", "", "", "", "", "", "", "");

            // Act
            registrarEstudiante.GenerarNumeroEstudiante(estudiante);

            // Assert
            Assert.IsTrue(estudiante.NumeroEstudiante != 0);
        }

        [TestMethod]
        public void GenerarConstaseniaProvisoria_GeneratePassword_PasswordIsNotEmpty()
        {
            // Arrange
            RegistrarEstudiante registrarEstudiante = new RegistrarEstudiante();
            Estudiante estudiante = new Estudiante("John", "Doe", "password", "123 Main St", "555-555-5555", "john@example.com", 0, "Cuatro", "", "", "", "", "", "", "", "", "");

            // Act
            registrarEstudiante.GenerarConstaseniaProvisoria(estudiante);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(estudiante.Contrasenia));
        }

        [TestMethod]

        public void btnIngresar_Click_ValidInput_StudentIsRegistered()
        {
            // Arrange
            RegistrarEstudiante registrarEstudiante = new RegistrarEstudiante();
            Estudiante estudiante = new Estudiante("John", "Doe", "password", "123 Main St", "555-555-5555", "john@example.com", 0, "Cuatro", "", "", "", "", "", "", "", "", "");
            registrarEstudiante.textBox1.Text = "John";
            registrarEstudiante.textBox2.Text = "Doe";
            registrarEstudiante.textBox3.Text = "john@example.com";
            registrarEstudiante.textBox4.Text = "123 Main St";
            registrarEstudiante.textBox5.Text = "555-555-5555";
            registrarEstudiante.textBox6.Text = "Cuatro";
            registrarEstudiante.checkBox1.Checked = true;

            // Act
            registrarEstudiante.btnIngresar_Click(null, null);

            // Assert
            Assert.IsTrue(registrarEstudiante.estudiantes.Any(e => e.NumeroEstudiante == estudiante.NumeroEstudiante));
        }
    }
}