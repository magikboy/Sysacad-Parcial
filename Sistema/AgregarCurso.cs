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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //hacer que tenga un limite de 40 cupos
            numericUpDown1.Maximum = 40;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Verificar si algún campo está vacío
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                numericUpDown1.Value == 0) // Validar el cupo disponible
            {
                MessageBox.Show("Faltan completar campos. Por favor, llene todos los campos.");
            }
            else
            {
                // Verificar si textBox1 contiene un valor numérico
                if (int.TryParse(textBox1.Text, out int codigoCurso))
                {
                    // Todos los campos obligatorios están completos y textBox1 contiene un valor numérico.
                    // Puedes continuar con el proceso de registro.

                    // Verificar si el curso ya existe en la lista
                    if (cursos.Exists(c => c.Codigo == codigoCurso))
                    {
                        MessageBox.Show("El curso ya está registrado en la base de datos.");
                    }
                    else
                    {
                        // Crear un objeto de tipo Cursos
                        Cursos curso = new Cursos();

                        // Asignar los valores de los campos a las propiedades del objeto
                        curso.Codigo = codigoCurso; // Usar el valor numérico en lugar del texto
                        curso.Nombre = textBox2.Text;
                        curso.DescripcionCurso = textBox4.Text;
                        curso.CupoDisponibles = (int)numericUpDown1.Value;
                        curso.NumeroInscriptos = 0; // Inicialmente, no hay inscritos en el curso

                        // Agregar el curso a la lista
                        cursos.Add(curso);

                        // Guardar solo el nuevo curso en el archivo JSON
                        GuardarDatosCursos.WriteStreamJSON("cursos.json", new List<Cursos> { curso });

                        MessageBox.Show("Curso Registrado.");

                        // Limpiar los campos después de agregar el curso
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox4.Clear();
                        numericUpDown1.Value = 0;
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
    }
}
