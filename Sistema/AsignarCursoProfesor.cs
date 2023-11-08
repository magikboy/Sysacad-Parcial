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
    public partial class AsignarCursoProfesor : Form
    {
        Label[] labels;
        public AsignarCursoProfesor()
        {
            InitializeComponent();
            labels = new Label[]
            {
                label3, label4, label5, label6, label7, label8, label9,
                label10, label11, label12, label13, label14, label15, label16,
                label17, label18, label19, label20, label21, label22, label23,
                label24, label25, label26, label27, label28, label29, label30,
                label31, label32, label33, label34, label35, label36, label37

            };
            // Llamar al método para cargar y mostrar los datos desde la base de datos
            CargarYMostrarDatosDesdeBaseDeDatosCursos();
            CargarYMostrarDatosDesdeBaseDeDatosProfesores();
        }


        // Método para cargar y mostrar los datos desde la base de datos en los Labels
        private void CargarYMostrarDatosDesdeBaseDeDatosCursos()
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

        private void CargarYMostrarDatosDesdeBaseDeDatosProfesores()
        {
            try
            {
                // Debes configurar la cadena de conexión según tu entorno
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT id, nombre, area FROM profesores";

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int labelIndex = 0;

                        while (reader.Read() && labelIndex < 7)
                        {
                            string nombreProfesor = reader["nombre"].ToString();
                            string areaProfesor = reader["area"].ToString();
                            int idProfesor = reader.GetInt32("id");

                            // Actualiza los Labels con los datos de la base de datos
                            labels[labelIndex + 17].Text = nombreProfesor; // Nombres de los profesores
                            labels[labelIndex + 24].Text = idProfesor.ToString(); // Códigos de los profesores
                            labels[labelIndex + 31].Text = areaProfesor; // Área de los profesores

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
            // Volver al menú del administrador con exepciones
            try
            {
                this.Hide();
                MenuAdministrador menu = new MenuAdministrador();
                menu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al volver al menú del administrador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cursoId = textBox1.Text;
                string nombreProfesor = textBox2.Text;

                // Validar que los valores no estén vacíos
                if (string.IsNullOrWhiteSpace(cursoId) || string.IsNullOrWhiteSpace(nombreProfesor))
                {
                    MessageBox.Show("Por favor, ingrese el ID del curso y el nombre del profesor.");
                    return;
                }

                // Debes configurar la cadena de conexión según tu entorno
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Actualiza la tabla de cursos para asignar el profesor
                    string updateCursoQuery = "UPDATE cursos SET Profesor = @nombreProfesor WHERE id = @cursoId";
                    using (MySqlCommand updateCursoCommand = new MySqlCommand(updateCursoQuery, connection))
                    {
                        updateCursoCommand.Parameters.AddWithValue("@nombreProfesor", nombreProfesor);
                        updateCursoCommand.Parameters.AddWithValue("@cursoId", cursoId);
                        int rowsUpdated = updateCursoCommand.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            // Actualiza la tabla de profesores para agregar el nombre de la materia asignada
                            string updateProfesorQuery = "UPDATE profesores SET CursosAsignado = @nombreCurso WHERE nombre = @nombreProfesor";
                            using (MySqlCommand updateProfesorCommand = new MySqlCommand(updateProfesorQuery, connection))
                            {
                                updateProfesorCommand.Parameters.AddWithValue("@nombreCurso", cursoId);
                                updateProfesorCommand.Parameters.AddWithValue("@nombreProfesor", nombreProfesor);
                                int rowsUpdatedProfesor = updateProfesorCommand.ExecuteNonQuery();

                                if (rowsUpdatedProfesor > 0)
                                {
                                    MessageBox.Show("Asignación exitosa.");
                                }
                                else
                                {
                                    MessageBox.Show("Error al actualizar la tabla de profesores.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error al asignar el profesor al curso.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la asignación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
