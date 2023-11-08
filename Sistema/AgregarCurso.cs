using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

namespace Sistema
{
    public partial class AgregarCurso : Form
    {

        List<Biblioteca.Cursos> cursos = new List<Biblioteca.Cursos>();
        public AgregarCurso()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Codigo del curso
            string Codigo = textBox1.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //tiene un límite de 40 cupos/números
            numericUpDown1.Maximum = 40;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén completos
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text) ||
                    string.IsNullOrWhiteSpace(textBox7.Text) ||
                    string.IsNullOrWhiteSpace(textBox8.Text) ||
                    string.IsNullOrWhiteSpace(textBox9.Text) ||
                    numericUpDown1.Value == 0 ||
                    numericUpDown2.Value == 0 ||
                    numericUpDown3.Value == 0)
                {
                    throw new Exception("Faltan completar campos. Por favor, llene todos los campos.");
                }

                // Verificar que los campos de código y aula sean valores numéricos
                if (!int.TryParse(textBox1.Text, out int codigoCurso) || !int.TryParse(textBox7.Text, out int aulaCurso))
                {
                    throw new Exception("El campo 'Código del curso' y 'Aula' deben ser valores numéricos.");
                }

                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO cursos (id, nombre, Descripcion, CuposDisponibles, HorarioMin, HorarioMax, Profesor, Cuatrimestre, Fecha, Aula, Division, Turno) " +
                    "VALUES (@codigo, @nombre, @descripcion, @cuota, @horarioMin, @horarioMax, @profesor, @cuatrimestre, @fecha, @aula, @division, @turno)";

                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@codigo", codigoCurso);
                    command.Parameters.AddWithValue("@nombre", textBox2.Text);
                    command.Parameters.AddWithValue("@descripcion", textBox4.Text);
                    command.Parameters.AddWithValue("@cuota", (int)numericUpDown1.Value);
                    command.Parameters.AddWithValue("@horarioMin", (int)numericUpDown2.Value);
                    command.Parameters.AddWithValue("@horarioMax", (int)numericUpDown3.Value);
                    command.Parameters.AddWithValue("@profesor", textBox3.Text);
                    command.Parameters.AddWithValue("@cuatrimestre", textBox5.Text);
                    command.Parameters.AddWithValue("@fecha", textBox6.Text);
                    command.Parameters.AddWithValue("@aula", aulaCurso);
                    command.Parameters.AddWithValue("@division", textBox8.Text);
                    command.Parameters.AddWithValue("@turno", textBox9.Text);


                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Curso Registrado en la base de datos.");
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el curso en la base de datos.");
                    }
                }

                // Limpia los campos después de agregar el curso
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 7;
                numericUpDown3.Value = 9;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //nombre del curso
            string Nombre = textBox2.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //descripcion del curso
            string DescripcionCurso = textBox4.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menú de cursos
            this.Hide();
            GestionarCursos cursos = new GestionarCursos();
            cursos.Show();
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
            numericUpDown3.Maximum = 22;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string cuatrimeste = textBox5.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Generar datos aleatorios para llenar los campos
            Random random = new Random();
            string[] cursos = { "Matemática", "Programación", "Laboratorio" };
            string[] profesores = { "Araya", "Gomez", "Juarez" };
            string[] cuatrimestres = { "Primer Cuatrimestre", "Segundo Cuatrimestre", "Tercer Cuatrimestre", "Cuarto Cuatrimestre" };
            string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };
            string[] divisiones = { "Primero A", "Segundo B", "Tercero C", "Cuarto D" };
            string[] turnos = { "Mañana", "Tarde", "Noche" };

            // Generar datos aleatorios
            int cuatrimestreIndex = random.Next(cuatrimestres.Length);
            textBox1.Text = ((cuatrimestreIndex + 1) * 100).ToString(); // Código del curso aleatorio
            textBox2.Text = cursos[random.Next(cursos.Length)]; // Nombre del curso aleatorio
            textBox3.Text = profesores[random.Next(profesores.Length)]; // Nombre del profesor aleatorio
            textBox4.Text = textBox2.Text + " Inicial"; // Descripción aleatoria
            textBox5.Text = cuatrimestres[cuatrimestreIndex]; // Cuatrimestre aleatorio
            textBox6.Text = dias[random.Next(dias.Length)]; // Día de la semana aleatorio
            textBox7.Text = random.Next(1, 30).ToString(); // Aula aleatoria
            textBox8.Text = divisiones[cuatrimestreIndex]; // División aleatoria
            textBox9.Text = turnos[random.Next(turnos.Length)]; // Turno aleatorio

            int horarioIndex = random.Next(7, 19); // Horario mínimo aleatorio entre 7 y 19
            numericUpDown1.Value = random.Next(1, 40); // Cupo aleatorio
            numericUpDown2.Value = horarioIndex; // Horario mínimo aleatorio
            numericUpDown3.Value = horarioIndex + 2; // Horario máximo aleatorio
        }

    }
}
