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
    public partial class MenuEstudiante : Form
    {
        private int numeroEstudianteIngresado;
        private List<Estudiante> estudiantes;

        public MenuEstudiante(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
            MostrarNumeroEstudiante();
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Volver al login
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Buscar el estudiante por NumeroEstudiante
            Estudiante estudianteSeleccionado = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudianteIngresado);

            if (estudianteSeleccionado != null)
            {
                // Abrir el formulario de datos del estudiante
                DatosEstudiante datosEstudiante = new DatosEstudiante(numeroEstudianteIngresado);
                datosEstudiante.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se encontró un estudiante con ese número.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //entra al formulario de cursos y horarios
            MenuCursosYHorariosEstudiantes menuCursosYHorariosEstudiantes = new MenuCursosYHorariosEstudiantes(numeroEstudianteIngresado);
            menuCursosYHorariosEstudiantes.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ir al menu de realizar pagos
            Realizar_Pagos realizar_Pagos = new Realizar_Pagos(numeroEstudianteIngresado);
            realizar_Pagos.Show();
            this.Hide();
        }
    }
}
