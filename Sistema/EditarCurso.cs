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
            this.numeroCurso = numeroCurso; // Guardo el número de curso recibido como parámetro
            MostrarNombreCurso(nombreCurso); // Muestro el nombre del curso en otro label
            CargarDatosCursos(); // Cargo los datos de los cursos desde el archivo JSON
            MostrarDatosCurso(); // Muestro los datos del curso en los controles del formulario
        }

        private void CargarDatosCursos()
        {
            try
            {
                // Carga los datos de los cursos desde el archivo JSON
                cursos = GuardarDatosCursos.ReadStreamJSON();
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
                textBox5.Text = cursoAEditar.Cuatrimestre;
                textBox3.Text = cursoAEditar.Profesor;
                textBox6.Text = cursoAEditar.Fecha;
                textBox7.Text = cursoAEditar.Aula.ToString();
                textBox8.Text = cursoAEditar.Division;
                textBox9.Text = cursoAEditar.Turno;
                numericUpDown1.Value = cursoAEditar.CupoDisponibles;
                numericUpDown2.Value = cursoAEditar.HorarioMin;
                numericUpDown3.Value = cursoAEditar.HorarioMax;
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
            string nuevoCuatrimestre = textBox5.Text;
            string nuevaFecha = textBox6.Text;
            string nuevoAula = textBox7.Text;
            string nuevaDivision = textBox8.Text;
            string nuevoTurno = textBox9.Text;
            int nuevoCupo = (int)numericUpDown1.Value;
            int nuevoHorarioMin = (int)numericUpDown2.Value;
            int nuevoHorarioMax = (int)numericUpDown3.Value;


            // Busco el curso en la lista que coincida con el número de curso seleccionado
            Cursos cursoAEditar = cursos.Find(curso => curso.Codigo == numeroCurso);

            if (cursoAEditar != null)
            {
                // Actualiza los datos del curso en la lista
                cursoAEditar.Nombre = nuevoNombre;
                cursoAEditar.Codigo = int.Parse(nuevoCodigo);
                cursoAEditar.Profesor = nuevoProfesor;
                cursoAEditar.DescripcionCurso = nuevaDescripcion;
                cursoAEditar.Cuatrimestre = nuevoCuatrimestre;
                cursoAEditar.Fecha = nuevaFecha;
                cursoAEditar.Aula = int.Parse(nuevoAula);
                cursoAEditar.Division = nuevaDivision;
                cursoAEditar.Turno = nuevoTurno;
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
                    cursoAEditar.CambiarCuatrimestre(nuevoCuatrimestre);
                    cursoAEditar.CambiarFecha1(nuevaFecha);
                    cursoAEditar.CambiarAula(int.Parse(nuevoAula));
                    cursoAEditar.CambiarDivision(nuevaDivision);
                    cursoAEditar.CambiarTurno(nuevoTurno);
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
