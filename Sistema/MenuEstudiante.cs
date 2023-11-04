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
    public partial class MenuEstudiante : Form
    {
        private int numeroEstudianteIngresado;
        private List<Estudiante> estudiantes;

        public MenuEstudiante(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
            label1.ForeColor = Color.White;
            MostrarNumeroEstudiante();
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
            //poner label 1 en blanco
            label1.ForeColor = Color.White;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Volver al login
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Establece la cadena de conexión a la base de datos MySQL
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para buscar al estudiante por su número de legajo
                    string query = "SELECT * FROM estudiantes WHERE Legajo = @Legajo";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Legajo", numeroEstudianteIngresado);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Si se encuentra un estudiante, puedes obtener los datos aquí
                            // Puedes abrir el formulario de DatosEstudiante para mostrar los detalles si es necesario
                            DatosEstudiante datosEstudiante = new DatosEstudiante(numeroEstudianteIngresado);
                            datosEstudiante.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un estudiante con ese número.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar ingresar: " + ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            MostrarNumeroEstudiante();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Entra al formulario de cursos y horarios
                MenuCursosYHorariosEstudiantes menuCursosYHorariosEstudiantes = new MenuCursosYHorariosEstudiantes(numeroEstudianteIngresado);
                menuCursosYHorariosEstudiantes.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar acceder a los cursos y horarios: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Ir al menú de realizar pagos
                Realizar_Pagos realizar_Pagos = new Realizar_Pagos(numeroEstudianteIngresado);
                realizar_Pagos.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar realizar pagos: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //abrir menuNotificaciones con excepciones
            try
            {
                MenuNotificacion menuNotificaciones = new MenuNotificacion(numeroEstudianteIngresado);
                menuNotificaciones.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar acceder a las notificaciones: " + ex.Message);
            }
        }
    }
}
