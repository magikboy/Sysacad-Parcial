using Biblioteca;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Sistema
{
    public partial class EliminarCurso : Form
    {
        Label[] labels;

        public EliminarCurso()
        {
            InitializeComponent();
            labels = new Label[]
            {
                label3, label4, label5, label6, label7, label8, label9,
                label10, label11, label12, label13, label14, label15, label16
            };

            // Llamar al método para cargar y mostrar los datos desde la base de datos
            CargarYMostrarDatosDesdeBaseDeDatos();
        }

        // Método para cargar y mostrar los datos desde la base de datos en los Labels
        private void CargarYMostrarDatosDesdeBaseDeDatos()
        {
            try
            {
                // Debes configurar la cadena de conexión según tu entorno
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT id, nombre FROM cursos";

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int labelIndex = 0;

                        while (reader.Read() && labelIndex < 7)
                        {
                            string nombreCurso = reader["nombre"].ToString();
                            int idCurso = reader.GetInt32("id");

                            // Actualiza los Labels con los datos de la base de datos
                            labels[labelIndex].Text = nombreCurso;
                            labels[labelIndex + 7].Text = idCurso.ToString();

                            labelIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar y mostrar datos desde la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Volver al menú del administrador
            this.Hide();
            MenuAdministrador menu = new MenuAdministrador();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string codigoIngresado = textBox1.Text;

            if (int.TryParse(codigoIngresado, out int cursoId))
            {
                // Pregunta al usuario si está seguro de querer eliminar el curso
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este curso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Debes configurar la cadena de conexión según tu entorno
                    string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM cursos WHERE id = @cursoId";
                        MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                        command.Parameters.AddWithValue("@cursoId", cursoId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Curso eliminado correctamente.");
                            CargarYMostrarDatosDesdeBaseDeDatos(); // Actualizar la lista de cursos mostrada
                        }
                        else
                        {
                            MessageBox.Show("El curso con el ID ingresado no existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de curso válido (número entero).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
