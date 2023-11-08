using Biblioteca;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema
{
    public partial class EditarCurso : Form
    {
        private MySqlConnection connection;
        private int cursoId; // Variable para almacenar el ID del curso

        public EditarCurso(int idCurso, string nombreCurso)
        {
            InitializeComponent();
            this.cursoId = idCurso;
            MostrarNombreCurso(nombreCurso);
            CargarDatosCurso();
        }

        private void MostrarNombreCurso(string nombreCurso)
        {
            label1.Text = "Curso a Editar: " + nombreCurso;
        }

        private void CargarDatosCurso()
        {
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // Obtén los datos del curso desde la base de datos
                string selectQuery = "SELECT * FROM cursos WHERE id = @id";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@id", cursoId);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Muestra los datos del curso en los controles del formulario
                    textBox1.Text = reader["nombre"].ToString();
                    textBox2.Text = reader["id"].ToString();
                    textBox4.Text = reader["Descripcion"].ToString();
                    textBox5.Text = reader["Cuatrimestre"].ToString();
                    textBox3.Text = reader["Profesor"].ToString();
                    textBox6.Text = reader["Fecha"].ToString();
                    textBox7.Text = reader["Aula"].ToString();
                    textBox8.Text = reader["Division"].ToString();
                    textBox9.Text = reader["Turno"].ToString();
                    numericUpDown1.Value = Convert.ToInt32(reader["CuposDisponibles"]);
                    numericUpDown2.Value = Convert.ToInt32(reader["HorarioMin"]);
                    numericUpDown3.Value = Convert.ToInt32(reader["HorarioMax"]);
                }
                else
                {
                    MessageBox.Show("El curso seleccionado no se encuentra en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del curso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén los nuevos valores del curso desde los controles en el formulario
                string nuevoNombre = textBox1.Text;
                string nuevaDescripcion = textBox4.Text;
                string nuevoCuatrimestre = textBox5.Text;
                string nuevoProfesor = textBox3.Text;
                string nuevaFecha = textBox6.Text;
                string nuevoAula = textBox7.Text;
                string nuevaDivision = textBox8.Text;
                string nuevoTurno = textBox9.Text;
                int nuevoCupo = (int)numericUpDown1.Value;
                int nuevoHorarioMin = (int)numericUpDown2.Value;
                int nuevoHorarioMax = (int)numericUpDown3.Value;

                connection.Open();

                // Actualiza los datos del curso en la base de datos
                string updateQuery = "UPDATE cursos SET nombre = @nombre, Descripcion = @descripcion, Cuatrimestre = @cuatrimestre, Profesor = @profesor, " +
                    "Fecha = @fecha, Aula = @aula, Division = @division, Turno = @turno, CuposDisponibles = @cupo, HorarioMin = @horarioMin, HorarioMax = @horarioMax " +
                    "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@nombre", nuevoNombre);
                command.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                command.Parameters.AddWithValue("@cuatrimestre", nuevoCuatrimestre);
                command.Parameters.AddWithValue("@profesor", nuevoProfesor);
                command.Parameters.AddWithValue("@fecha", nuevaFecha);
                command.Parameters.AddWithValue("@aula", nuevoAula);
                command.Parameters.AddWithValue("@division", nuevaDivision);
                command.Parameters.AddWithValue("@turno", nuevoTurno);
                command.Parameters.AddWithValue("@cupo", nuevoCupo);
                command.Parameters.AddWithValue("@horarioMin", nuevoHorarioMin);
                command.Parameters.AddWithValue("@horarioMax", nuevoHorarioMax);
                command.Parameters.AddWithValue("@id", cursoId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Los datos del curso se actualizaron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el curso en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del curso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Obtén los nuevos valores del curso desde los controles en el formulario
                string nuevoNombre = textBox1.Text;
                string nuevaDescripcion = textBox4.Text;
                string nuevoCuatrimestre = textBox5.Text;
                string nuevoProfesor = textBox3.Text;
                string nuevaFecha = textBox6.Text;
                string nuevoAula = textBox7.Text;
                string nuevaDivision = textBox8.Text;
                string nuevoTurno = textBox9.Text;
                int nuevoCupo = (int)numericUpDown1.Value;
                int nuevoHorarioMin = (int)numericUpDown2.Value;
                int nuevoHorarioMax = (int)numericUpDown3.Value;

                connection.Open();

                // Actualiza los datos del curso en la base de datos
                string updateQuery = "UPDATE cursos SET nombre = @nombre, Descripcion = @descripcion, Cuatrimestre = @cuatrimestre, Profesor = @profesor, " +
                    "Fecha = @fecha, Aula = @aula, Division = @division, Turno = @turno, CuposDisponibles = @cupo, HorarioMin = @horarioMin, HorarioMax = @horarioMax " +
                    "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@nombre", nuevoNombre);
                command.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                command.Parameters.AddWithValue("@cuatrimestre", nuevoCuatrimestre);
                command.Parameters.AddWithValue("@profesor", nuevoProfesor);
                command.Parameters.AddWithValue("@fecha", nuevaFecha);
                command.Parameters.AddWithValue("@aula", nuevoAula);
                command.Parameters.AddWithValue("@division", nuevaDivision);
                command.Parameters.AddWithValue("@turno", nuevoTurno);
                command.Parameters.AddWithValue("@cupo", nuevoCupo);
                command.Parameters.AddWithValue("@horarioMin", nuevoHorarioMin);
                command.Parameters.AddWithValue("@horarioMax", nuevoHorarioMax);
                command.Parameters.AddWithValue("@id", cursoId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Los datos del curso se actualizaron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el curso en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del curso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //horario del curso min
            numericUpDown2.Minimum = 7;
            numericUpDown2.Maximum = 19;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            //horario del curso max
            numericUpDown3.Minimum = 9;
            numericUpDown3.Maximum = 21;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string cuatrimeste = textBox5.Text;
        }
    }
}
