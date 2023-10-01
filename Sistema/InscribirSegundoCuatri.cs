using Biblioteca;
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
    public partial class InscribirSegundoCuatri : Form
    {
        private int numeroEstudianteIngresado;
        List<Biblioteca.Cursos> cursos = new List<Biblioteca.Cursos>();
        List<Estudiante> estudiantes = new List<Estudiante>();

        public InscribirSegundoCuatri(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();
            MostrarDatosDelPrimerAlSextoCurso();
            estudiantes = GuardarDatosEstudiantes.ReadStreamJSON("estudiantes.json");
        }

        private void MostrarNumeroEstudiante()
        {
            label44.Text = numeroEstudianteIngresado.ToString();
        }

        private void MostrarDatosCurso(int indice, Label nombreLabel, Label codigoLabel, Label descripcionLabel, Label cupoLabel)
        {
            cursos = GuardarDatosCursos.ReadStreamJSON(GuardarDatosCursos.archivoCursos);

            // Verificar si hay cursos disponibles en la lista y que sean del Segundo cuatrimestre
            List<Cursos> cursosPrimerCuatrimestre = cursos.Where(curso => curso.Cuatrimestre == "Segundo Cuatrimestre").ToList();

            if (cursosPrimerCuatrimestre.Count > indice)
            {
                Cursos curso = cursosPrimerCuatrimestre[indice];

                nombreLabel.Text = curso.Nombre;
                codigoLabel.Text = curso.Codigo.ToString();
                descripcionLabel.Text = curso.DescripcionCurso;
                cupoLabel.Text = curso.CupoDisponibles.ToString();
            }
            else
            {
                // Si no hay un curso disponible en ese índice, establecer los labels en blanco
                nombreLabel.Text = "";
                codigoLabel.Text = "";
                descripcionLabel.Text = "";
                cupoLabel.Text = "";
            }
        }

        private void MostrarDatosDelPrimerAlSextoCurso()
        {
            // Mostrar los datos de los cursos del primer cuatrimestre del uno al cinco
            MostrarDatosCurso(0, label4, label1, label7, label9);
            MostrarDatosCurso(1, label17, label15, label13, label11);
            MostrarDatosCurso(2, label24, label25, label23, label19);
            MostrarDatosCurso(3, label34, label31, label33, label27);
            MostrarDatosCurso(4, label42, label39, label41, label35);
            MostrarDatosCurso(5, label51, label48, label50, label43);
        }

        private void InscribirEstudianteEnCurso(string materiaLabel, string cuatrimestre)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde el Label correspondiente a la materia
            string cursoSeleccionado = materiaLabel;

            // Verificar si el estudiante ya está inscrito en la materia
            if (!string.IsNullOrEmpty(estudiante.materiaUno) &&
                estudiante.materiaUno == cursoSeleccionado)
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en este curso.");
                return;
            }

            if (!string.IsNullOrEmpty(estudiante.materiaDos) &&
                estudiante.materiaDos == cursoSeleccionado)
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en este curso.");
                return;
            }

            if (!string.IsNullOrEmpty(estudiante.materiaTres) &&
                estudiante.materiaTres == cursoSeleccionado)
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en este curso.");
                return;
            }

            if (!string.IsNullOrEmpty(estudiante.materiaCuatro) &&
                estudiante.materiaCuatro == cursoSeleccionado)
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en este curso.");
                return;
            }

            if (!string.IsNullOrEmpty(estudiante.materiaCinco) &&
                estudiante.materiaCinco == cursoSeleccionado)
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en este curso.");
                return;
            }

            if (!string.IsNullOrEmpty(estudiante.materiaSeis) &&
                estudiante.materiaSeis == cursoSeleccionado)
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en este curso.");
                return;
            }

            // Buscar el curso en la lista de cursos
            Cursos curso = cursos.FirstOrDefault(cur => cur.Nombre == cursoSeleccionado);

            if (curso == null)
            {
                MessageBox.Show("El curso no existe."); 
                return;
            }

            // Verificar si hay cupos disponibles
            if (curso.CupoDisponibles == 0)
            {
                MessageBox.Show("No hay cupos disponibles para este curso.");
                return;
            }

            // Preguntar al usuario si realmente desea inscribirse
            DialogResult result = MessageBox.Show($"¿Desea inscribir al estudiante {estudiante.NombreCompleto} en el curso {cursoSeleccionado}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario ha confirmado la inscripción

                curso.CupoDisponibles--;
                curso.NumeroInscriptos++;

                // Actualizar el JSON de cursos con los cambios (guardar los cambios en el archivo JSON)
                GuardarDatosCursos.ActualizarCursos(cursos);

                // Actualizar la materia correspondiente en el JSON del estudiante
                if (string.IsNullOrEmpty(estudiante.materiaUno))
                {
                    estudiante.materiaUno = cursoSeleccionado;
                }
                else if (string.IsNullOrEmpty(estudiante.materiaDos))
                {
                    estudiante.materiaDos = cursoSeleccionado;
                }
                else if (string.IsNullOrEmpty(estudiante.materiaTres))
                {
                    estudiante.materiaTres = cursoSeleccionado;
                }
                else if (string.IsNullOrEmpty(estudiante.materiaCuatro))
                {
                    estudiante.materiaCuatro = cursoSeleccionado;
                }
                else if (string.IsNullOrEmpty(estudiante.materiaCinco))
                {
                    estudiante.materiaCinco = cursoSeleccionado;
                }
                else if (string.IsNullOrEmpty(estudiante.materiaSeis))
                {
                    estudiante.materiaSeis = cursoSeleccionado;
                }

                // Actualizar el JSON del estudiante para reflejar la inscripción en la materia correspondiente
                GuardarDatosEstudiantes.ActualizarMateriasEstudiante(estudiante);

                // Mostrar un mensaje de éxito
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ha sido inscrito en el curso {cursoSeleccionado}.");
            }
            else
            {
                // El usuario ha cancelado la inscripción
                MessageBox.Show("La inscripción ha sido cancelada.");
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            // Llamar al método para inscribir al estudiante en la materia 1
            InscribirEstudianteEnCurso(label4.Text, "Segundo Cuatrimestre");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Llamar al método para inscribir al estudiante en la materia 2
            InscribirEstudianteEnCurso(label17.Text, "Segundo Cuatrimestre");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            // Llamar al método para inscribir al estudiante en la materia 3
            InscribirEstudianteEnCurso(label24.Text, "Segundo Cuatrimestre");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            // Llamar al método para inscribir al estudiante en la materia 4
            InscribirEstudianteEnCurso(label34.Text, "Segundo Cuatrimestre");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            // Llamar al método para inscribir al estudiante en la materia 5
            InscribirEstudianteEnCurso(label42.Text, "Segundo Cuatrimestre");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Llamar al método para inscribir al estudiante en la materia 6
            InscribirEstudianteEnCurso(label51.Text, "Segundo Cuatrimestre");
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
