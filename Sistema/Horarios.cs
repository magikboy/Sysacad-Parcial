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
    public partial class Horarios : Form
    {
        private int numeroEstudianteIngresado;
        List<Biblioteca.Cursos> cursos = new List<Biblioteca.Cursos>();
        List<Estudiante> estudiantes = new List<Estudiante>();

        public Horarios(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();
            this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
            this.cursos = GuardarDatosCursos.ReadStreamJSON();


            // Busco al estudiante por su número y obtener su cuatrimestre
            var estudiante = estudiantes.FirstOrDefault(e => e.NumeroEstudiante == numeroEstudiante);

            // Verifica si el estudiante tiene cursos asociados
            if (estudiante != null)
            {
                // Obtengo las materias inscritas del estudiante
                List<string> materiasInscritas = ObtenerMateriasInscritas(estudiante);

                // Filtra las materias que no estén vacías en el JSON
                materiasInscritas = materiasInscritas.Where(materia => !string.IsNullOrWhiteSpace(materia)).ToList();

                // Verifica si el estudiante tiene al menos una materia inscrita
                if (materiasInscritas.Count > 0)
                {
                    string cuatrimestreEstudiante = estudiante.CuatrimestreEstudiante;

                    // Filtra cursos por el cuatrimestre del estudiante
                    cursos = cursos
                        .Where(curso => curso.Cuatrimestre == cuatrimestreEstudiante)
                        .OrderBy(curso => curso.Fecha) // Ordenar por fecha
                        .ToList();

                    MostrarCursosEnFormulario();
                }
                else
                {
                    MessageBox.Show("El estudiante no está inscrito en ninguna materia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarCursosVacios();
                }
            }
        }

        private void MostrarCursosVacios()
        {
            for (int i = 9; i <= 112; i++)
            {
                var label = Controls.Find("label" + i, true).FirstOrDefault() as Label;
                if (label != null)
                {
                    label.Text = string.Empty;
                }
            }
        }


        private List<string> ObtenerMateriasInscritas(Estudiante estudiante)
        {
            List<string> materiasInscritas = new List<string>();

            // Agrega las materias inscritas a la lista
            materiasInscritas.Add(estudiante.MateriaUno);
            materiasInscritas.Add(estudiante.MateriaDos);
            materiasInscritas.Add(estudiante.MateriaTres);
            materiasInscritas.Add(estudiante.MateriaCuatro);
            materiasInscritas.Add(estudiante.MateriaCinco);
            materiasInscritas.Add(estudiante.MateriaSeis);

            // Filtra las materias que no estén vacías
            materiasInscritas = materiasInscritas.Where(materia => !string.IsNullOrWhiteSpace(materia)).ToList();

            return materiasInscritas;
        }

        private void MostrarCursosEnFormulario()
        {
            // Obtengo las materias inscritas del estudiante
            List<string> materiasInscritas = ObtenerMateriasInscritas(estudiantes.FirstOrDefault(e => e.NumeroEstudiante == numeroEstudianteIngresado));

            foreach (var diaSemana in new[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes" })
            {
                for (int horario = 9; horario <= 22; horario++)
                {
                    // Filtra cursos por día de la semana y horario
                    var curso = cursos.FirstOrDefault(c => c.Fecha == diaSemana && c.HorarioMin <= horario && c.HorarioMax >= horario);

                    if (curso != null && materiasInscritas.Contains(curso.Nombre))
                    {
                        // Muestra la información en los labels correspondientes
                        MostrarCursoEnLabel(diaSemana, horario, curso);
                    }
                    else
                    {
                        // Si no se encuentra un curso con ese horario o no está inscrito en la materia, muestra un mensaje en los labels
                        MostrarCursoEnLabel(diaSemana, horario, null);
                    }
                }
            }
        }

        private void MostrarCursoEnLabel(string diaSemana, int horario, Biblioteca.Cursos curso)
        {
            Label labelNombre = null;
            Label labelAula = null;
            Label labelHoraInicio = null;
            Label labelHoraFin = null;
            Label labelProfesor = null;

            // Asigno los labels correspondientes según el día de la semana
            switch (diaSemana)
            {
                case "Lunes":
                    // Asigno los labels del lunes según el horario
                    if (horario >= 9 && horario <= 13)
                    {
                        labelNombre = label9;
                        labelAula = label10;
                        labelHoraInicio = label11;
                        labelHoraFin = label12;
                        labelProfesor = label13;
                    }
                    else if (horario >= 14 && horario <= 18)
                    {
                        labelNombre = label18;
                        labelAula = label17;
                        labelHoraInicio = label16;
                        labelHoraFin = label15;
                        labelProfesor = label14;
                    }
                    else if (horario >= 19 && horario <= 22)
                    {
                        labelNombre = label32;
                        labelAula = label31;
                        labelHoraInicio = label30;
                        labelHoraFin = label29;
                        labelProfesor = label28;
                    }
                    break;
                case "Martes":
                    // Asigno los labels del martes según el horario
                    if (horario >= 9 && horario <= 13)
                    {
                        labelNombre = label37;
                        labelAula = label36;
                        labelHoraInicio = label35;
                        labelHoraFin = label34;
                        labelProfesor = label33;
                    }
                    else if (horario >= 14 && horario <= 18)
                    {
                        labelNombre = label42;
                        labelAula = label41;
                        labelHoraInicio = label40;
                        labelHoraFin = label39;
                        labelProfesor = label38;
                    }
                    else if (horario >= 19 && horario <= 22)
                    {
                        labelNombre = label52;
                        labelAula = label51;
                        labelHoraInicio = label50;
                        labelHoraFin = label49;
                        labelProfesor = label48;
                    }
                    break;
                case "Miercoles":
                    // Asigno los labels del miércoles según el horario
                    if (horario >= 9 && horario <= 13)
                    {
                        labelNombre = label57;
                        labelAula = label56;
                        labelHoraInicio = label55;
                        labelHoraFin = label54;
                        labelProfesor = label53;
                    }
                    else if (horario >= 14 && horario <= 18)
                    {
                        labelNombre = label62;
                        labelAula = label61;
                        labelHoraInicio = label60;
                        labelHoraFin = label59;
                        labelProfesor = label58;
                    }
                    else if (horario >= 19 && horario <= 22)
                    {
                        labelNombre = label72;
                        labelAula = label71;
                        labelHoraInicio = label70;
                        labelHoraFin = label69;
                        labelProfesor = label68;
                    }
                    break;
                case "Jueves":
                    // Asigno los labels del jueves según el horario
                    if (horario >= 9 && horario <= 13)
                    {
                        labelNombre = label77;
                        labelAula = label76;
                        labelHoraInicio = label75;
                        labelHoraFin = label74;
                        labelProfesor = label73;
                    }
                    else if (horario >= 14 && horario <= 18)
                    {
                        labelNombre = label82;
                        labelAula = label81;
                        labelHoraInicio = label80;
                        labelHoraFin = label79;
                        labelProfesor = label78;
                    }
                    else if (horario >= 19 && horario <= 22)
                    {
                        labelNombre = label92;
                        labelAula = label91;
                        labelHoraInicio = label90;
                        labelHoraFin = label89;
                        labelProfesor = label88;
                    }
                    break;
                case "Viernes":
                    // Asigno los labels del viernes según el horario
                    if (horario >= 9 && horario <= 13)
                    {
                        labelNombre = label97;
                        labelAula = label96;
                        labelHoraInicio = label95;
                        labelHoraFin = label94;
                        labelProfesor = label93;
                    }
                    else if (horario >= 14 && horario <= 18)
                    {
                        labelNombre = label102;
                        labelAula = label101;
                        labelHoraInicio = label100;
                        labelHoraFin = label99;
                        labelProfesor = label98;
                    }
                    else if (horario >= 19 && horario <= 22)
                    {
                        labelNombre = label112;
                        labelAula = label111;
                        labelHoraInicio = label110;
                        labelHoraFin = label109;
                        labelProfesor = label108;
                    }
                    break;
            }

            if (curso != null)
            {
                // Muestra la información en los labels correspondientes
                labelNombre.Text = curso.Nombre;
                labelAula.Text = "Aula: " + curso.Aula.ToString();
                labelHoraInicio.Text = "De: " + curso.HorarioMin.ToString();
                labelHoraFin.Text = "a " + curso.HorarioMax.ToString() + " Hrs";
                labelProfesor.Text = "Profesor: " + curso.Profesor;
            }
            else
            {
                // Si no se encuentra un curso con ese horario o no está inscrito en la materia, mostrar un mensaje en los labels
                labelNombre.Text = string.Empty;
                labelAula.Text = string.Empty;
                labelHoraInicio.Text = string.Empty;
                labelHoraFin.Text = string.Empty;
                labelProfesor.Text = string.Empty;
            }
        }


        private void MostrarNumeroEstudiante()
        {
            label4.Text = numeroEstudianteIngresado.ToString();
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
    }
}
