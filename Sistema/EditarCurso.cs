using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema
{
    public partial class EditarCurso : Form
    {
        private List<Cursos> cursos = new List<Cursos>();
        private int numeroCurso; // Variable para almacenar el número de curso

        public EditarCurso(int numeroCurso, string nombreCurso)
        {
            InitializeComponent();
            this.numeroCurso = numeroCurso; // Guarda el número de curso recibido como parámetro
            MostrarNombreCurso(nombreCurso); // Muestra el nombre del curso en otro label
            CargarDatosCursos(); // Carga los datos de los cursos desde el archivo JSON
            MostrarDatosCurso(); // Muestra los datos del curso en los controles del formulario
        }

        private void CargarDatosCursos()
        {
            try
            {
                // Carga los datos de los cursos desde el archivo JSON
                cursos = GuardarDatosCursos.ReadStreamJSON(GuardarDatosCursos.archivoCursos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de cursos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosCurso()
        {
            // Busca el curso en la lista que coincida con el número de curso seleccionado
            Cursos cursoAEditar = cursos.Find(curso => curso.Codigo == numeroCurso);

            if (cursoAEditar != null)
            {
                // Muestra los datos del curso en los controles del formulario
                textBox1.Text = cursoAEditar.Nombre;
                textBox2.Text = cursoAEditar.Codigo.ToString();
                textBox4.Text = cursoAEditar.DescripcionCurso;
                numericUpDown1.Value = cursoAEditar.CupoDisponibles;
            }
            else
            {
                // Si no se encuentra el curso, muestra un mensaje de error
                MessageBox.Show("El curso seleccionado no se encuentra en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarNombreCurso(string nombreCurso)
        {
            label7.Text = nombreCurso;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Obtén los nuevos valores del curso desde los controles en el formulario
            string nuevoNombre = textBox1.Text;
            string nuevoCodigo = textBox2.Text;
            string nuevoProfesor = textBox3.Text;
            string nuevaDescripcion = textBox4.Text;
            int nuevoCupo = (int)numericUpDown1.Value;
            int nuevoHorarioMin = (int)numericUpDown2.Value;
            int nuevoHorarioMax = (int)numericUpDown3.Value;


            // Buscar el curso en la lista que coincida con el número de curso seleccionado
            Cursos cursoAEditar = cursos.Find(curso => curso.Codigo == numeroCurso);

            if (cursoAEditar != null)
            {
                // Actualiza los datos del curso en la lista
                cursoAEditar.Nombre = nuevoNombre;
                cursoAEditar.Codigo = int.Parse(nuevoCodigo);
                cursoAEditar.Profesor = nuevoProfesor;
                cursoAEditar.DescripcionCurso = nuevaDescripcion;
                cursoAEditar.CupoDisponibles = nuevoCupo;
                cursoAEditar.HorarioMin = nuevoHorarioMin;
                cursoAEditar.HorarioMax = nuevoHorarioMax;

                try
                {
                    // Actualiza los datos del curso en el archivo JSON
                    cursoAEditar.CambiarCodigo(nuevoCodigo);
                    cursoAEditar.CambiarNombre(nuevoNombre);
                    cursoAEditar.CambiarProfesor(nuevoProfesor);
                    cursoAEditar.CambiarDescripcion(nuevaDescripcion);
                    cursoAEditar.CambiarCupo(nuevoCupo.ToString());
                    cursoAEditar.CambiarHorarioMin(nuevoHorarioMin.ToString());
                    cursoAEditar.CambiarHorarioMax(nuevoHorarioMax.ToString());

                    // Actualiza la lista de cursos en el archivo JSON
                    GuardarDatosCursos.ActualizarCursos(cursos);

                    MessageBox.Show("Los datos del curso se actualizaron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos del curso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Si no se encuentra el curso, muestra un mensaje de error
                MessageBox.Show("El curso seleccionado ya se encuentra en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Volver al menú de administrador
            this.Hide();
            MenuAdministrador admin = new MenuAdministrador();
            admin.Show();
        }

        // Eventos de cambios en los campos de texto y el control NumericUpDown
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Aquí se edita el nombre
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Aquí se edita el código
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Aquí se edita la descripción
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Aquí se edita el cupo
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Este evento se activa cuando se hace clic en el nombre del curso
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
    }
}
