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
        public InscripcionCursos(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

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
    }
}
