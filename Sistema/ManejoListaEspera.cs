using System;
using System.Data;
using System.Windows.Forms;
using Biblioteca;
using MySql.Data.MySqlClient;

namespace Sistema
{
    public partial class ManejoListaEspera : Form
    {
        private string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";
        private MySqlConnection connection;
        private int cursoId;
        Label[] labels;

        public ManejoListaEspera(int idCurso, string nombreCurso)
        {
            this.cursoId = idCurso;
            InitializeComponent();
            textBox1.Text = nombreCurso; // Muestra el nombre del curso en el TextBox
            labels = new Label[]
            {
                label5, label6, label7, label8, label9,
                label10, label11, label12, label13, label14,
            };
            CargarYMostrarNombresYFechasDesdeBaseDeDatos(); // Llama al método para cargar los datos.
        }

        private void CargarYMostrarNombresYFechasDesdeBaseDeDatos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT NombreEstudiante, Fecha FROM listadeespera WHERE NombreMateria = @NombreMateria ORDER BY Fecha LIMIT 5";

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NombreMateria", textBox1.Text); // Utiliza el nombre del curso como filtro

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            int labelIndex = 0;
                            bool estudiantesEncontrados = false;

                            while (reader.Read() && labelIndex < 5)
                            {
                                string nombreEstudiante = reader["NombreEstudiante"].ToString();
                                DateTime fecha = reader.GetDateTime("Fecha");

                                // Actualiza los labels con los datos de la base de datos
                                labels[labelIndex].Text = nombreEstudiante;
                                labels[labelIndex + 5].Text = fecha.ToString("MM-dd-yyyy");

                                labelIndex++;
                                estudiantesEncontrados = true;
                            }

                            if (!estudiantesEncontrados)
                            {
                                label4.Text = "No se encuentran estudiantes en la lista de espera.";
                            }
                            else
                            {
                                label4.Text = "Estudiantes En La lista de espera:";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar y mostrar datos desde la base de datos: {ex.Message}");
            }
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                MenuAdministrador menu = new MenuAdministrador();
                menu.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreEstudianteAEliminar = textBox2.Text;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM listadeespera WHERE NombreMateria = @NombreMateria AND NombreEstudiante = @NombreEstudiante";
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NombreMateria", textBox1.Text); // Utiliza el nombre del curso como filtro
                        command.Parameters.AddWithValue("@NombreEstudiante", nombreEstudianteAEliminar);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Estudiante eliminado exitosamente.");
                            CargarYMostrarNombresYFechasDesdeBaseDeDatos(); // Vuelve a cargar y mostrar los datos después de la eliminación.
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún estudiante con ese nombre en la lista de espera.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el estudiante: {ex.Message}");
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreEstudianteAIngresar = textBox2.Text;
                DateTime horaActual = DateTime.Now;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO listadeespera (NombreMateria, NombreEstudiante, Fecha) VALUES (@NombreMateria, @NombreEstudiante, @Fecha)";
                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NombreMateria", textBox1.Text); // Utiliza el nombre del curso como filtro
                        command.Parameters.AddWithValue("@NombreEstudiante", nombreEstudianteAIngresar);
                        command.Parameters.AddWithValue("@Fecha", horaActual);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Estudiante ingresado exitosamente.");
                            CargarYMostrarNombresYFechasDesdeBaseDeDatos(); // Vuelve a cargar y mostrar los datos después de la inserción.
                        }
                        else
                        {
                            MessageBox.Show("No se pudo ingresar al estudiante en la lista de espera.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ingresar el estudiante: {ex.Message}");
            }
        }

    }
}
