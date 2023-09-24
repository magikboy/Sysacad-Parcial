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
    public partial class MenuCursosYHorariosEstudiantes : Form
    {
        private int numeroEstudianteIngresado;

        public MenuCursosYHorariosEstudiantes(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //ingresar a inscripcionCursos
            InscripcionCursos inscripcionCursos = new InscripcionCursos(numeroEstudianteIngresado);
            inscripcionCursos.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu de estudiante
            MenuEstudiante menuEstudiante = new MenuEstudiante(numeroEstudianteIngresado);
            menuEstudiante.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir del programa
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ingresar a ConsultarHorario
            ConsultarHorario consultaHorario = new ConsultarHorario(numeroEstudianteIngresado);
            consultaHorario.Show();
            this.Hide();
        }
    }
}
