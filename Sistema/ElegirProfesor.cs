using Biblioteca;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class ElegirProfesor : Form
    {
        Label[] labels;

        public ElegirProfesor()
        {
            InitializeComponent();
            labels = new Label[]
            {
                label3, label4, label5, label6, label7, label8, label9,
                label10, label11, label12, label13, label14, label15, label16
            };

            // Llamo a un método para cargar y mostrar los datos desde la base de datos
            CargarYMostrarDatosDesdeBaseDeDatos();
        }

        // Método para cargar y mostrar los datos desde la base de datos en los labels
        private void CargarYMostrarDatosDesdeBaseDeDatos()
        {
            try
            {
                // Debes configurar la cadena de conexión según tu entorno
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT id, nombre FROM Profesores";

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int labelIndex = 0;

                        while (reader.Read() && labelIndex < 7)
                        {
                            string nombreProfesor = reader["nombre"].ToString();
                            int ProfesorId = reader.GetInt32("id");

                            // Actualiza los labels con los datos de la base de datos
                            labels[labelIndex].Text = nombreProfesor;
                            labels[labelIndex + 7].Text = ProfesorId.ToString();

                            labelIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar y mostrar datos desde la base de datos: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Volver al menú administrador
                this.Hide();
                MenuAdministrador menu = new MenuAdministrador();
                menu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al volver al menú administrador: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string codigoIngresado = textBox1.Text;

            if (int.TryParse(codigoIngresado, out int ProfesorId))
            {
                // Debes configurar la cadena de conexión según tu entorno
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Profesores WHERE id = @ProfesorId";
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    command.Parameters.AddWithValue("@ProfesorId", ProfesorId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombreProfesor = reader["nombre"].ToString();
                            this.Hide();
                            EditarProfesor editarProfesor = new EditarProfesor(ProfesorId, nombreProfesor);
                            editarProfesor.Show();
                        }
                        else
                        {
                            MessageBox.Show("El profesor con el ID ingresado no existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de profesor válido (número entero).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Volver al menú administrador con exepciones
            try
            {
                this.Hide();
                MenuAdministrador menu = new MenuAdministrador();
                menu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al volver al menú administrador: {ex.Message}");
            }
        }
    }
}
