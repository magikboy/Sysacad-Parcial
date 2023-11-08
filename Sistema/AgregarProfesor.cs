using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Biblioteca;

namespace Sistema
{
    public partial class AgregarProfesor : Form
    {
        public AgregarProfesor()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si algún campo está vacío
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Faltan completar campos. Por favor, llene todos los campos.");
                }
                else
                {
                    // Crear un objeto de tipo Profesor
                    Profesor profesor = new Profesor(
                        textBox1.Text,
                        textBox2.Text,
                        textBox4.Text,
                        textBox5.Text,
                        textBox3.Text,
                        textBox6.Text,
                        ""
                    );

                    // Agregar el profesor a la base de datos MySQL
                    string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO profesores (nombre, apellido, direccion, telefono, CorreoElectronico, Area, CursosAsignado) " +
                            "VALUES (@nombre, @apellido, @direccion, @telefono, @correo, @area, @cursos)";

                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        command.Parameters.AddWithValue("@nombre", profesor.NombreCompleto);
                        command.Parameters.AddWithValue("@apellido", profesor.ApellidoCompleto);
                        command.Parameters.AddWithValue("@direccion", profesor.Direccion);
                        command.Parameters.AddWithValue("@telefono", profesor.NumeroTelefono);
                        command.Parameters.AddWithValue("@correo", profesor.CorreoElectronico);
                        command.Parameters.AddWithValue("@area", profesor.Area);
                        command.Parameters.AddWithValue("@cursos", profesor.CursosAsignados);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profesor registrado en la base de datos.");
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar al profesor en la base de datos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar al profesor: " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Volver al menú de administrador
            MenuAdministrador menuAdministrador = new MenuAdministrador();
            menuAdministrador.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Generar datos aleatorios para el profesor (puedes personalizar esto según tus necesidades)
            Random random = new Random();
            string[] nombres = { "Juan", "Maria", "Carlos", "Laura", "Ana" };
            string[] apellidos = { "Perez", "Gomez", "Rodriguez", "Martinez", "Lopez" };
            string[] direcciones = { "Calle 312", "Calle 211", "Calle 987", "Calle 11", "Calle 242", "Calle 23211", "Calle 23111" };
            string[] correos = { "juan@example.com", "maria@example.com", "carlos@example.com", "laura@example.com", "ana@example.com" };
            string[] telefonos = { "12345678", "98765432", "55555555", "99999999", "77777777" };
            string[] areas = { "Matemáticas", "Ciencias", "Historia", "Idiomas", "Arte" };

            // Generar datos aleatorios
            string nombreAleatorio = nombres[random.Next(nombres.Length)];
            string apellidoAleatorio = apellidos[random.Next(apellidos.Length)];
            string direccionAleatoria = direcciones[random.Next(direcciones.Length)];
            string correoAleatorio = correos[random.Next(correos.Length)];
            string telefonoAleatorio = telefonos[random.Next(telefonos.Length)];
            string areaAleatoria = areas[random.Next(areas.Length)];

            // Llenar los campos con datos aleatorios
            textBox1.Text = nombreAleatorio;
            textBox2.Text = apellidoAleatorio;
            textBox4.Text = direccionAleatoria;
            textBox3.Text = correoAleatorio;
            textBox5.Text = telefonoAleatorio;
            textBox6.Text = areaAleatoria;
        }
    }
}
