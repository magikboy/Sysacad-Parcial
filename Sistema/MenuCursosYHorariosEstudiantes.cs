using Biblioteca;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class MenuCursosYHorariosEstudiantes : Form
    {
        private int numeroEstudianteIngresado;
        List<Estudiante> estudiantes = new List<Estudiante>();
        public MenuCursosYHorariosEstudiantes(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();

            try
            {
                this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de los estudiantes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el número de legajo ingresado por el usuario
                string legajoIngresado = label1.Text;

                string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

                // Crear una conexión a la base de datos
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Definir la consulta SQL para buscar al estudiante por legajo
                    string sqlQuery = "SELECT * FROM estudiantes WHERE Legajo = @Legajo";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@Legajo", legajoIngresado);

                    // Ejecutar la consulta y obtener el resultado
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Se encontró al estudiante en la base de datos
                            int numeroEstudiante = reader.GetInt32("Legajo"); // Obtener el número de estudiante desde la base de datos
                            string cuatrimestreEstudiante = reader.GetString("Cuatrimestre");

                            if (cuatrimestreEstudiante == "Primer Cuatrimestre")
                            {
                                InscribirPrimerCuatri inscribirPrimerCuatri = new InscribirPrimerCuatri(numeroEstudiante);
                                inscribirPrimerCuatri.Show();
                                this.Hide();
                            }
                            else if (cuatrimestreEstudiante == "Segundo Cuatrimestre")
                            {
                                InscribirSegundoCuatri inscribirSegundoCuatri = new InscribirSegundoCuatri(numeroEstudiante);
                                inscribirSegundoCuatri.Show();
                                this.Hide();
                            }
                            else if (cuatrimestreEstudiante == "Tercer Cuatrimestre")
                            {
                                InscribirTercerCuatri inscribirTercerCuatri = new InscribirTercerCuatri(numeroEstudiante);
                                inscribirTercerCuatri.Show();
                                this.Hide();
                            }
                            else if (cuatrimestreEstudiante == "Cuarto Cuatrimestre")
                            {
                                InscribirCuartoCuatri inscribirCuartoCuatri = new InscribirCuartoCuatri(numeroEstudiante);
                                inscribirCuartoCuatri.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("El estudiante no pertenece a ningún cuatrimestre válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Número de legajo no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese un número de legajo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu de estudiante
            MenuEstudiante menuEstudiante = new MenuEstudiante(numeroEstudianteIngresado);
            menuEstudiante.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir del programa
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ingresar a ConsultarHorario
            Horarios consultaHorario = new Horarios(numeroEstudianteIngresado);
            consultaHorario.Show();
            this.Hide();
        }
    }
}
