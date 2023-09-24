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
        //List<Biblioteca.Cursos> cursos = new List<Biblioteca.Cursos>();
        //List<Estudiante> estudiantes = new List<Estudiante>();

        public InscripcionCursos(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();
            //CargarYMostrarDatos();
            //cursos = GuardarDatosCursos.ReadStreamJSON(GuardarDatosCursos.archivoCursos);
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
        }

        // Método para cargar y mostrar los datos en los labels

        //private void CargarYMostrarDatos()
        //{
        //    // Leer la lista de cursos desde el archivo JSON
        //    var lista = GuardarDatosCursos.ReadStreamJSON(GuardarDatosCursos.archivoCursos);

        //    //mostrar solo los nombres de los cursos
        //    if (lista.Count > 0)
        //    {
        //        label4.Text = lista[0].Nombre.ToString();
        //    }

        //    if (lista.Count > 1)
        //    {
        //        label6.Text = lista[1].Nombre.ToString();
        //    }

        //    if (lista.Count > 2)
        //    {
        //        label8.Text = lista[2].Nombre.ToString();
        //    }

        //    if (lista.Count > 3)
        //    {
        //        label10.Text = lista[3].Nombre.ToString();
        //    }

        //    if (lista.Count > 4)
        //    {
        //        label12.Text = lista[4].Nombre.ToString();
        //    }

        //    if (lista.Count > 5)
        //    {
        //        label14.Text = lista[5].Nombre.ToString();
        //    }

        //    if (lista.Count > 6)
        //    {
        //        label16.Text = lista[6].Nombre.ToString();
        //    }

        //    if (lista.Count > 7)
        //    {
        //        label18.Text = lista[7].Nombre.ToString(); ;
        //    }

        //    if (lista.Count > 8)
        //    {
        //        label20.Text = lista[8].Nombre.ToString();
        //    }

        //    if (lista.Count > 9)
        //    {
        //        label22.Text = lista[9].Nombre.ToString();
        //    }

        //    if (lista.Count > 10)
        //    {
        //        label24.Text = lista[10].Nombre.ToString();
        //    }

        //    if (lista.Count > 11)
        //    {
        //        label26.Text = lista[11].Nombre.ToString();
        //    }

        //    if (lista.Count > 12)
        //    {
        //        label28.Text = lista[12].Nombre.ToString();
        //    }

        //    if (lista.Count > 13)
        //    {
        //        label30.Text = lista[13].Nombre.ToString();
        //    }

        //    if (lista.Count > 14)
        //    {
        //        label32.Text = lista[14].Nombre.ToString();
        //    }

        //    if (lista.Count > 15)
        //    {
        //        label34.Text = lista[15].Nombre.ToString();
        //    }

        //    if (lista.Count > 16)
        //    {
        //        label36.Text = lista[16].Nombre.ToString();
        //    }

        //    if (lista.Count > 17)
        //    {
        //        label38.Text = lista[17].Nombre.ToString();
        //    }

        //    if (lista.Count > 18)
        //    {
        //        label40.Text = lista[18].Nombre.ToString();
        //    }

        //    if (lista.Count > 19)
        //    {
        //        label42.Text = lista[19].Nombre.ToString();
        //    }
        //}


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

        private void button1_Click(object sender, EventArgs e)
        {
        }

    }
}
