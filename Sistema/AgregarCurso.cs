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
            //tiene un limite de 40 cupos/numeros
            numericUpDown1.Maximum = 40;

        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Verifico si algún campo está vacío
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
                MessageBox.Show("Faltan completar campos. Por favor, llene todos los campos.");
            }
            else
            {
                // Verifico si textBox1 y textBox7 contiene un valor numérico
                if (int.TryParse(textBox1.Text, out int codigoCurso) && int.TryParse(textBox7.Text, out int aulaCurso))
                {
                    // Cargar la lista existente de cursos desde el archivo JSON
                    cursos = GuardarDatosCursos.ReadStreamJSON();

                    // Verifico si el curso ya existe en la lista
                    if (cursos.Exists(x => x.Codigo == codigoCurso))
                    {
                        MessageBox.Show("El curso ya está registrado en la base de datos.");
                    }
                    else
                    {
                        // Creo un objeto de tipo Cursos
                        Cursos curso = new Cursos();

                        // Asigno los valores de los campos a las propiedades del objeto
                        curso.Codigo = codigoCurso;
                        curso.Nombre = textBox2.Text;
                        curso.DescripcionCurso = textBox4.Text;
                        curso.CupoDisponibles = (int)numericUpDown1.Value;
                        curso.NumeroInscriptos = 0; // Inicialmente, no hay inscritos en el curso
                        curso.HorarioMin = (int)numericUpDown2.Value;
                        curso.HorarioMax = (int)numericUpDown3.Value;
                        curso.Profesor = textBox3.Text;
                        curso.Cuatrimestre = textBox5.Text;
                        curso.Fecha = textBox6.Text;
                        curso.Aula = aulaCurso;
                        curso.Division = textBox8.Text;
                        curso.Turno = textBox9.Text;

                        // Agrego el curso a la lista
                        cursos.Add(curso);

                        // Guardo todos los cursos en el archivo JSON (sobrescribir el archivo)
                        GuardarDatosCursos.WriteStreamJSON(cursos);

                        MessageBox.Show("Curso Registrado.");

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
                }
                else
                {
                    MessageBox.Show("El campo 'Código del curso' debe ser un valor numérico.");
                }
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
            //volver al menu de cursos
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
            numericUpDown3.Maximum = 21;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string cuatrimeste = textBox5.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            // Opciones para los datos
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
            textBox3.Text = "Profesor " + profesores[random.Next(profesores.Length)]; // Nombre del profesor aleatorio
            textBox4.Text = textBox2.Text + " Inicial"; // Descripción aleatoria
            textBox5.Text = cuatrimestres[cuatrimestreIndex]; // Cuatrimestre aleatorio
            textBox6.Text = dias[random.Next(dias.Length)]; // Día de la semana aleatorio
            textBox7.Text = random.Next(1, 30).ToString(); // Aula aleatoria
            textBox8.Text = divisiones[cuatrimestreIndex]; // División aleatoria
            textBox9.Text = turnos[random.Next(turnos.Length)]; // Turno aleatorio
            numericUpDown1.Value = random.Next(1, 40); // Cupo aleatorio
            numericUpDown2.Value = random.Next(7, 19); // HorarioMin aleatorio
            numericUpDown3.Value = random.Next(9, 21); // HorarioMax aleatorio
        }

    }
}
