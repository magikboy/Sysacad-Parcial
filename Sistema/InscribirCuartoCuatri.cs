using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Sistema
{
    public partial class InscribirCuartoCuatri : Form
    {
        private int numeroEstudianteIngresado;
        private MySqlConnection connection;
        private MySqlCommand cmd;
        private MySqlDataReader reader;

        public InscribirCuartoCuatri(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();
            InicializarBaseDeDatos();
            MostrarDatosDelPrimerAlSextoCurso();
        }

        private void InicializarBaseDeDatos()
        {
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;user=root;password=;"; // Corregir 'Uid' a 'user' y 'pwd' a 'password'
            connection = new MySqlConnection(connectionString);
            cmd = new MySqlCommand();
            cmd.Connection = connection;
        }

        private void MostrarNumeroEstudiante()
        {
            label44.Text = numeroEstudianteIngresado.ToString();
        }

        private void MostrarDatosDelPrimerAlSextoCurso()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM cursos WHERE Cuatrimestre = 'Cuarto Cuatrimestre'";
                cmd.CommandText = query;
                reader = cmd.ExecuteReader();

                int courseIndex = 0;
                while (reader.Read() && courseIndex < 6)
                {
                    Label nombreLabel = null;
                    Label codigoLabel = null;
                    Label descripcionLabel = null;
                    Label cupoLabel = null;

                    switch (courseIndex)
                    {
                        case 0:
                            nombreLabel = label4;
                            codigoLabel = label1;
                            descripcionLabel = label7;
                            cupoLabel = label9;
                            break;
                        case 1:
                            nombreLabel = label17;
                            codigoLabel = label15;
                            descripcionLabel = label13;
                            cupoLabel = label11;
                            break;
                        case 2:
                            nombreLabel = label24;
                            codigoLabel = label25;
                            descripcionLabel = label23;
                            cupoLabel = label19;
                            break;
                        case 3:
                            nombreLabel = label34;
                            codigoLabel = label31;
                            descripcionLabel = label33;
                            cupoLabel = label27;
                            break;
                        case 4:
                            nombreLabel = label42;
                            codigoLabel = label39;
                            descripcionLabel = label41;
                            cupoLabel = label35;
                            break;
                        case 5:
                            nombreLabel = label51;
                            codigoLabel = label48;
                            descripcionLabel = label50;
                            cupoLabel = label43;
                            break;
                    }

                    if (nombreLabel != null)
                    {
                        nombreLabel.Text = reader["nombre"].ToString();
                        codigoLabel.Text = reader["id"].ToString();
                        descripcionLabel.Text = reader["Descripcion"].ToString();
                        cupoLabel.Text = reader["CuposDisponibles"].ToString();
                    }

                    courseIndex++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de cursos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void InscribirEstudianteEnCurso(string cursoNombre, string materiaColumn)
        {
            try
            {
                connection.Open();

                // Consultar si el estudiante ya está inscrito en la materia
                string checkQuery = $"SELECT {materiaColumn} FROM estudiantes WHERE id = {numeroEstudianteIngresado}";
                cmd.CommandText = checkQuery;
                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value || string.IsNullOrEmpty(result.ToString()))
                {
                    // El estudiante no está inscrito, se puede proceder con la inscripción
                    // Reinicializar los parámetros antes de usarlos nuevamente
                    cmd.Parameters.Clear();

                    string updateQuery = $"UPDATE estudiantes SET {materiaColumn} = @CursoNombre WHERE id = {numeroEstudianteIngresado}";
                    cmd.CommandText = updateQuery;
                    cmd.Parameters.AddWithValue("@CursoNombre", cursoNombre);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Estudiante inscrito en {cursoNombre} con éxito.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo inscribir al estudiante en el curso.");
                    }
                }
                else
                {
                    MessageBox.Show($"El estudiante ya está inscrito en {cursoNombre}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inscribir al estudiante en el curso: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }



        private void InscribirEstudianteEnCurso(Label cursoLabel, string materiaColumn)
        {
            string cursoNombre = cursoLabel.Text;
            InscribirEstudianteEnCurso(cursoNombre, materiaColumn);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cursoNombre = label4.Text;
            InscribirEstudianteEnCurso(cursoNombre, "MateriaUno");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cursoNombre = label17.Text;
            InscribirEstudianteEnCurso(cursoNombre, "MateriaDos");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string cursoNombre = label24.Text;
            InscribirEstudianteEnCurso(cursoNombre, "MateriaTres");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cursoNombre = label34.Text;
            InscribirEstudianteEnCurso(cursoNombre, "MateriaCuatro");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string cursoNombre = label42.Text;
            InscribirEstudianteEnCurso(cursoNombre, "MateriaCinco");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cursoNombre = label51.Text;
            InscribirEstudianteEnCurso(cursoNombre, "MateriaSeis");
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            // Volver al menú de cursos y horarios
            MenuCursosYHorariosEstudiantes menuCursosYHorariosEstudiantes = new MenuCursosYHorariosEstudiantes(numeroEstudianteIngresado);
            menuCursosYHorariosEstudiantes.Show();
            this.Hide();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            // Salir del programa
            Application.Exit();
        }
    }
}
