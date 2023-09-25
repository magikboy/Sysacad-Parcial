using Biblioteca;
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
    public partial class InscripcionCursos : Form
    {
        private int numeroEstudianteIngresado;
        List<Biblioteca.Cursos> cursos = new List<Biblioteca.Cursos>();
        List<Estudiante> estudiantes = new List<Estudiante>();

        public InscripcionCursos(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();
            CargarYMostrarDatos();
            cursos = GuardarDatosCursos.ReadStreamJSON(GuardarDatosCursos.archivoCursos);
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");
        }

        private void MostrarNumeroEstudiante()
        {
            label44.Text = numeroEstudianteIngresado.ToString();
        }

        //Método para cargar y mostrar los datos en los labels

        private void CargarYMostrarDatos()
        {
            // Leer la lista de cursos desde el archivo JSON
            var lista = GuardarDatosCursos.ReadStreamJSON(GuardarDatosCursos.archivoCursos);

            //mostrar solo los nombres de los cursos
            if (lista.Count > 0)
            {
                label4.Text = lista[0].Nombre.ToString();
            }

            if (lista.Count > 1)
            {
                label6.Text = lista[1].Nombre.ToString();
            }

            if (lista.Count > 2)
            {
                label1.Text = lista[2].Nombre.ToString();
            }

            if (lista.Count > 3)
            {
                label10.Text = lista[3].Nombre.ToString();
            }

            if (lista.Count > 4)
            {
                label12.Text = lista[4].Nombre.ToString();
            }

            if (lista.Count > 5)
            {
                label14.Text = lista[5].Nombre.ToString();
            }

            if (lista.Count > 6)
            {
                label16.Text = lista[6].Nombre.ToString();
            }

            if (lista.Count > 7)
            {
                label18.Text = lista[7].Nombre.ToString(); ;
            }

            if (lista.Count > 8)
            {
                label20.Text = lista[8].Nombre.ToString();
            }

            if (lista.Count > 9)
            {
                label22.Text = lista[9].Nombre.ToString();
            }

            if (lista.Count > 10)
            {
                label24.Text = lista[10].Nombre.ToString();
            }

            if (lista.Count > 11)
            {
                label26.Text = lista[11].Nombre.ToString();
            }

            if (lista.Count > 12)
            {
                label28.Text = lista[12].Nombre.ToString();
            }

            if (lista.Count > 13)
            {
                label30.Text = lista[13].Nombre.ToString();
            }

            if (lista.Count > 14)
            {
                label32.Text = lista[14].Nombre.ToString();
            }

            if (lista.Count > 15)
            {
                label34.Text = lista[15].Nombre.ToString();
            }

            if (lista.Count > 16)
            {
                label36.Text = lista[16].Nombre.ToString();
            }

            if (lista.Count > 17)
            {
                label38.Text = lista[17].Nombre.ToString();
            }

            if (lista.Count > 18)
            {
                label40.Text = lista[18].Nombre.ToString();
            }

            if (lista.Count > 19)
            {
                label42.Text = lista[19].Nombre.ToString();
            }
        }

        //primer cuatrimestre
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

        //segundo Cuatrimestre
        private void button8_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Segundo Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Segundo cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label4
            string cursoSeleccionado = label14.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
            if (!string.IsNullOrEmpty(estudiante.materiaUno))
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en la materia {estudiante.materiaUno}.");
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

        private void button9_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Segundo Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Segundo cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label4
            string cursoSeleccionado = label16.Text;

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

        private void button10_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Segundo Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Segundo cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label4
            string cursoSeleccionado = label18.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
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

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaUno
                estudiante.materiaTres = cursoSeleccionado;
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

        private void button11_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Segundo Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Segundo cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label
            string cursoSeleccionado = label20.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
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

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaUno
                estudiante.materiaCuatro = cursoSeleccionado;
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

        private void button12_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Segundo Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Segundo cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label4
            string cursoSeleccionado = label22.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
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

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaUno
                estudiante.materiaCinco = cursoSeleccionado;
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

        private void button7_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Segundo Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Segundo cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label
            string cursoSeleccionado = label24.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
            if (!string.IsNullOrEmpty(estudiante.materiaSeis))
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en la materia {estudiante.materiaSeis}.");
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
                estudiante.materiaSeis = cursoSeleccionado;
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


        //tercer cuatrimestre


        private void button13_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Tercer Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Tercer cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label
            string cursoSeleccionado = label26.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
            if (!string.IsNullOrEmpty(estudiante.materiaUno))
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en la materia {estudiante.materiaUno}.");
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

        private void button14_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Tercer Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Tercer cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label
            string cursoSeleccionado = label28.Text;

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

        private void button15_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Tercer Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Tercer cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label
            string cursoSeleccionado = label30.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
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

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaUno
                estudiante.materiaTres = cursoSeleccionado;
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

        private void button16_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Tercer Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Tercer cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label
            string cursoSeleccionado = label32.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
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

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaUno
                estudiante.materiaCuatro = cursoSeleccionado;
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

        private void button17_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Tercer Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Tercer cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label
            string cursoSeleccionado = label34.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
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

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaUno
                estudiante.materiaCinco = cursoSeleccionado;
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

        //cuarto cuatrimestre


        private void button18_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Cuarto Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Cuarto cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label
            string cursoSeleccionado = label36.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
            if (!string.IsNullOrEmpty(estudiante.materiaUno))
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} ya está inscrito en la materia {estudiante.materiaUno}.");
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

        private void button19_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Cuarto Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Cuarto cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label
            string cursoSeleccionado = label38.Text;

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

        private void button20_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Cuarto Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Cuarto cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label
            string cursoSeleccionado = label40.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
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

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaUno
                estudiante.materiaTres = cursoSeleccionado;
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

        private void button21_Click(object sender, EventArgs e)
        {
            // Obtener el número de estudiante desde el Label
            int numeroEstudiante = int.Parse(label44.Text);

            // Verificar si el estudiante existe en la lista de estudiantes
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudiante.CuatrimestreEstudiante != "Cuarto Cuatrimestre")
            {
                MessageBox.Show($"El estudiante {estudiante.NombreCompleto} no puede inscribirse en esta materia porque no está cursando el Cuarto cuatrimestre.");
                return;
            }

            if (estudiante == null)
            {
                MessageBox.Show("El estudiante no existe.");
                return;
            }

            // Obtener el nombre del curso desde Label
            string cursoSeleccionado = label42.Text;

            // Verificar si el estudiante ya está inscrito en la materiaUno
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

                // Actualizar el JSON del estudiante para reflejar la inscripción en materiaUno
                estudiante.materiaCuatro = cursoSeleccionado;
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

        //labels y botones que no se eliminar

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu de cursos y horarios
            this.Hide();
            MenuCursosYHorariosEstudiantes menuCursosYHorarios = new MenuCursosYHorariosEstudiantes(numeroEstudianteIngresado);
            menuCursosYHorarios.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir del programa
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }
    }
}
