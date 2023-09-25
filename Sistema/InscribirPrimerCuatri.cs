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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema
{
    public partial class InscribirPrimerCuatri : Form
    {
        private int numeroEstudianteIngresado;
        List<Biblioteca.Cursos> cursos = new List<Biblioteca.Cursos>();
        List<Estudiante> estudiantes = new List<Estudiante>();
        public InscribirPrimerCuatri(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();
            MostrarDatosDelPrimerAlSextoCurso();
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");
        }

        private void MostrarNumeroEstudiante()
        {
            label44.Text = numeroEstudianteIngresado.ToString();
        }

        private void MostrarDatosCurso(int indice, Label nombreLabel, Label codigoLabel, Label descripcionLabel, Label cupoLabel)
        {
            cursos = GuardarDatosCursos.ReadStreamJSON(GuardarDatosCursos.archivoCursos);

            // Verificar si hay cursos disponibles en la lista y que sean del primer cuatrimestre
            List<Cursos> cursosPrimerCuatrimestre = cursos.Where(curso => curso.Cuatrimestre == "Primer Cuatrimestre").ToList();

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
            MostrarDatosCurso(2, label25, label23, label21, label19);
            MostrarDatosCurso(3, label33, label31, label29, label27);
            MostrarDatosCurso(4, label41, label39, label37, label35);
            MostrarDatosCurso(5, label51, label48, label50, label43);
        }

        private void button1_Click(object sender, EventArgs e)
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

            // Obtener el nombre del curso desde Label4
            string cursoSeleccionado = label4.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
            if (!string.IsNullOrEmpty(estudiante.materiaUno))
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en la materia {estudiante.materiaUno}.");
                return;
            }

            // Buscar el curso en la lista de cursos
            Cursos curso = cursos.FirstOrDefault(c => c.Nombre == cursoSeleccionado);

            if (estudiante.CuatrimestreEstudiante != "Primer Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el primer cuatrimestre.");
                return;
            }

            if (curso == null)
            {
                MessageBox.Show("El curso seleccionado no existe.");
                return;
            }

            // Verificar si hay cupo disponible en el curso
            if (curso.NumeroInscriptos >= curso.CupoDisponibles)
            {
                MessageBox.Show("El curso está completo, no hay cupo disponible.");
                return;
            }

            // Preguntar al usuario si realmente desea inscribirse
            DialogResult result = MessageBox.Show($"¿Desea inscribir al estudiante {estudiante.NombreCompleto} en el curso {curso.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario ha confirmado la inscripción

                curso.CupoDisponibles--;
                curso.NumeroInscriptos++;

                // Actualizar el JSON de cursos con los cambios (guardar los cambios en el archivo JSON)
                GuardarDatosCursos.ActualizarCursos(cursos);

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaUno
                estudiante.materiaUno = cursoSeleccionado;
                GuardarDatos.ActualizarMateriasEstudiante(estudiante);

                // Mostrar un mensaje de éxito
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ha sido inscrito en el curso {curso.Nombre}.");
            }
            else
            {
                // El usuario ha cancelado la inscripción
                MessageBox.Show("La inscripción ha sido cancelada.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu de cursos y horarios
            MenuCursosYHorariosEstudiantes menuCursosYHorariosEstudiantes = new MenuCursosYHorariosEstudiantes(numeroEstudianteIngresado);
            menuCursosYHorariosEstudiantes.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir del programa
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Primer Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el primer cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label4
            string cursoSeleccionado = label6.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
            if (!string.IsNullOrEmpty(estudiante.materiaDos))
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en la materia {estudiante.materiaDos}.");
                return;
            }

            // Buscar el curso en la lista de cursos
            Cursos curso = cursos.FirstOrDefault(c => c.Nombre == cursoSeleccionado);

            if (curso == null)
            {
                MessageBox.Show("El curso seleccionado no existe.");
                return;
            }

            // Verificar si hay cupo disponible en el curso
            if (curso.NumeroInscriptos >= curso.CupoDisponibles)
            {
                MessageBox.Show("El curso está completo, no hay cupo disponible.");
                return;
            }

            // Preguntar al usuario si realmente desea inscribirse
            DialogResult result = MessageBox.Show($"¿Desea inscribir al estudiante {estudiante.NombreCompleto} en el curso {curso.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario ha confirmado la inscripción

                curso.CupoDisponibles--;
                curso.NumeroInscriptos++;

                // Actualizar el JSON de cursos con los cambios (guardar los cambios en el archivo JSON)
                GuardarDatosCursos.ActualizarCursos(cursos);

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaUno
                estudiante.materiaDos = cursoSeleccionado;
                GuardarDatos.ActualizarMateriasEstudiante(estudiante);

                // Mostrar un mensaje de éxito
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ha sido inscrito en el curso {curso.Nombre}.");
            }
            else
            {
                // El usuario ha cancelado la inscripción
                MessageBox.Show("La inscripción ha sido cancelada.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Primer Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el primer cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label3 (botón 3)
            string cursoSeleccionado = label1.Text;

            // Verificar si el estudiante ya está inscrito en la materiaTres
            if (!string.IsNullOrEmpty(estudiante.materiaTres))
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en la materia {estudiante.materiaTres}.");
                return;
            }

            // Buscar el curso en la lista de cursos
            Cursos curso = cursos.FirstOrDefault(c => c.Nombre == cursoSeleccionado);

            if (curso == null)
            {
                MessageBox.Show("El curso seleccionado no existe.");
                return;
            }

            // Verificar si hay cupo disponible en el curso
            if (curso.NumeroInscriptos >= curso.CupoDisponibles)
            {
                MessageBox.Show("El curso está completo, no hay cupo disponible.");
                return;
            }

            // Preguntar al usuario si realmente desea inscribirse
            DialogResult result = MessageBox.Show($"¿Desea inscribir al estudiante {estudiante.NombreCompleto} en el curso {curso.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario ha confirmado la inscripción

                curso.CupoDisponibles--;
                curso.NumeroInscriptos++;

                // Actualizar el JSON de cursos con los cambios (guardar los cambios en el archivo JSON)
                GuardarDatosCursos.ActualizarCursos(cursos);

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaTres
                estudiante.materiaTres = cursoSeleccionado; // Cambio a materiaTres
                GuardarDatos.ActualizarMateriasEstudiante(estudiante);

                // Mostrar un mensaje de éxito
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ha sido inscrito en el curso {curso.Nombre}.");
            }
            else
            {
                // El usuario ha cancelado la inscripción
                MessageBox.Show("La inscripción ha sido cancelada.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Primer Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el primer cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label3 (botón 3)
            string cursoSeleccionado = label10.Text;

            // Verificar si el estudiante ya está inscrito en la materiaTres
            if (!string.IsNullOrEmpty(estudiante.materiaCuatro))
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en la materia {estudiante.materiaCuatro}.");
                return;
            }

            // Buscar el curso en la lista de cursos
            Cursos curso = cursos.FirstOrDefault(c => c.Nombre == cursoSeleccionado);

            if (curso == null)
            {
                MessageBox.Show("El curso seleccionado no existe.");
                return;
            }

            // Verificar si hay cupo disponible en el curso
            if (curso.NumeroInscriptos >= curso.CupoDisponibles)
            {
                MessageBox.Show("El curso está completo, no hay cupo disponible.");
                return;
            }

            // Preguntar al usuario si realmente desea inscribirse
            DialogResult result = MessageBox.Show($"¿Desea inscribir al estudiante {estudiante.NombreCompleto} en el curso {curso.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario ha confirmado la inscripción

                curso.CupoDisponibles--;
                curso.NumeroInscriptos++;

                // Actualizar el JSON de cursos con los cambios (guardar los cambios en el archivo JSON)
                GuardarDatosCursos.ActualizarCursos(cursos);

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaTres
                estudiante.materiaCuatro = cursoSeleccionado; // Cambio a materiaTres
                GuardarDatos.ActualizarMateriasEstudiante(estudiante);

                // Mostrar un mensaje de éxito
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ha sido inscrito en el curso {curso.Nombre}.");
            }
            else
            {
                // El usuario ha cancelado la inscripción
                MessageBox.Show("La inscripción ha sido cancelada.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Primer Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el primer cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label3 (botón 3)
            string cursoSeleccionado = label12.Text;

            // Verificar si el estudiante ya está inscrito en la materiaTres
            if (!string.IsNullOrEmpty(estudiante.materiaCinco))
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en la materia {estudiante.materiaCinco}.");
                return;
            }

            // Buscar el curso en la lista de cursos
            Cursos curso = cursos.FirstOrDefault(c => c.Nombre == cursoSeleccionado);

            if (curso == null)
            {
                MessageBox.Show("El curso seleccionado no existe.");
                return;
            }

            // Verificar si hay cupo disponible en el curso
            if (curso.NumeroInscriptos >= curso.CupoDisponibles)
            {
                MessageBox.Show("El curso está completo, no hay cupo disponible.");
                return;
            }

            // Preguntar al usuario si realmente desea inscribirse
            DialogResult result = MessageBox.Show($"¿Desea inscribir al estudiante {estudiante.NombreCompleto} en el curso {curso.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // El usuario ha confirmado la inscripción

                curso.CupoDisponibles--;
                curso.NumeroInscriptos++;

                // Actualizar el JSON de cursos con los cambios (guardar los cambios en el archivo JSON)
                GuardarDatosCursos.ActualizarCursos(cursos);

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaTres
                estudiante.materiaCinco = cursoSeleccionado; // Cambio a materiaTres
                GuardarDatos.ActualizarMateriasEstudiante(estudiante);

                // Mostrar un mensaje de éxito
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ha sido inscrito en el curso {curso.Nombre}.");
            }
            else
            {
                // El usuario ha cancelado la inscripción
                MessageBox.Show("La inscripción ha sido cancelada.");
            }
        }
    }
}
