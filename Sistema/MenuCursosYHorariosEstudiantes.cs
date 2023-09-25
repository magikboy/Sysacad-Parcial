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
    public partial class MenuCursosYHorariosEstudiantes : Form
    {
        private int numeroEstudianteIngresado;
        List<Estudiante> estudiantes = new List<Estudiante>();
        public MenuCursosYHorariosEstudiantes(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int numeroEstudiante = int.Parse(label1.Text);
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            // ingresar a inscribir primer cuatri if pertenece a primer cuatri
            if (estudiante.CuatrimestreEstudiante == "Primer Cuatrimestre")
            {
                InscribirPrimerCuatri inscribirPrimerCuatri = new InscribirPrimerCuatri(numeroEstudianteIngresado);
                inscribirPrimerCuatri.Show();
                this.Hide();
            }
            // ingresar a inscribir segundo cuatri if pertenece a segundo cuatri
            else if (estudiante.CuatrimestreEstudiante == "Segundo Cuatrimestre")
            {
                InscribirSegundoCuatri inscribirSegundoCuatri = new InscribirSegundoCuatri(numeroEstudianteIngresado);
                inscribirSegundoCuatri.Show();
                this.Hide();
            }
            // ingresar a inscribir tercer cuatri if pertenece a tercer cuatri
            else if (estudiante.CuatrimestreEstudiante == "Tercer Cuatrimestre")
            {
                InscribirTercerCuatri inscribirTercerCuatri = new InscribirTercerCuatri(numeroEstudianteIngresado);
                inscribirTercerCuatri.Show();
                this.Hide();
            }
            // ingresar a inscribir cuarto cuatri if pertenece a cuarto cuatri
            else if (estudiante.CuatrimestreEstudiante == "Cuarto Cuatrimestre")
            {
                InscribirCuartoCuatri inscribirCuartoCuatri = new InscribirCuartoCuatri(numeroEstudianteIngresado);
                inscribirCuartoCuatri.Show();
                this.Hide();
            }
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
