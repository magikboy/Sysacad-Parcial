using Biblioteca;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sistema
{
    public partial class EditarProfesor : Form
    {
        private MySqlConnection connection;
        private int idProfesor; // Variable para almacenar el ID del profesor

        public EditarProfesor(int idProfesor, string nombreProfesor)
        {
            InitializeComponent();
            this.idProfesor = idProfesor;
            MostrarNombreProfesor(nombreProfesor);
            CargarDatosProfesor();
        }

        private void MostrarNombreProfesor(string nombreProfesor)
        {
            label1.Text = "Profesor a Editar: " + nombreProfesor;
        }

        private void CargarDatosProfesor()
        {
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // Obtén los datos del profesor desde la base de datos
                string selectQuery = "SELECT * FROM Profesores WHERE id = @id";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@id", idProfesor);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Muestra los datos del profesor en los controles del formulario
                    textBox1.Text = reader["nombre"].ToString();
                    textBox2.Text = reader["apellido"].ToString();
                    textBox4.Text = reader["direccion"].ToString();
                    textBox3.Text = reader["CorreoElectronico"].ToString();
                    textBox5.Text = reader["telefono"].ToString();
                    textBox6.Text = reader["Area"].ToString();
                }
                else
                {
                    MessageBox.Show("El profesor seleccionado no se encuentra en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del profesor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén los nuevos valores del profesor desde los controles en el formulario
                string nuevoNombre = textBox1.Text;
                string nuevoApellido = textBox2.Text;
                string nuevaDireccion = textBox4.Text;
                string nuevoCorreo = textBox3.Text;
                string nuevoTelefono = textBox5.Text;
                string nuevoArea = textBox6.Text;

                connection.Open();

                // Actualiza los datos del profesor en la base de datos
                string updateQuery = "UPDATE Profesores SET nombre = @nombre, apellido = @apellido, direccion = @direccion, CorreoElectronico = @correo, telefono = @telefono, Area = @area " +
                    "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@nombre", nuevoNombre);
                command.Parameters.AddWithValue("@apellido", nuevoApellido);
                command.Parameters.AddWithValue("@direccion", nuevaDireccion);
                command.Parameters.AddWithValue("@correo", nuevoCorreo);
                command.Parameters.AddWithValue("@telefono", nuevoTelefono);
                command.Parameters.AddWithValue("@area", nuevoArea);
                command.Parameters.AddWithValue("@id", idProfesor);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Los datos del profesor se actualizaron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el profesor en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del profesor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Volver al menú de administrador
            this.Hide();
            MenuAdministrador admin = new MenuAdministrador();
            admin.Show();
        }
    }
}
