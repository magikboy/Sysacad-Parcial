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

            try
            {
                this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de los estudiantes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                int numeroEstudiante = int.Parse(label1.Text);
                Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

                if (estudiante != null)
                {
                    if (estudiante.CuatrimestreEstudiante == "Primer Cuatrimestre")
                    {
                        InscribirPrimerCuatri inscribirPrimerCuatri = new InscribirPrimerCuatri(numeroEstudianteIngresado);
                        inscribirPrimerCuatri.Show();
                        this.Hide();
                    }
                    else if (estudiante.CuatrimestreEstudiante == "Segundo Cuatrimestre")
                    {
                        InscribirSegundoCuatri inscribirSegundoCuatri = new InscribirSegundoCuatri(numeroEstudianteIngresado);
                        inscribirSegundoCuatri.Show();
                        this.Hide();
                    }
                    else if (estudiante.CuatrimestreEstudiante == "Tercer Cuatrimestre")
                    {
                        InscribirTercerCuatri inscribirTercerCuatri = new InscribirTercerCuatri(numeroEstudianteIngresado);
                        inscribirTercerCuatri.Show();
                        this.Hide();
                    }
                    else if (estudiante.CuatrimestreEstudiante == "Cuarto Cuatrimestre")
                    {
                        InscribirCuartoCuatri inscribirCuartoCuatri = new InscribirCuartoCuatri(numeroEstudianteIngresado);
                        inscribirCuartoCuatri.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("El estudiante no pertenece a ningún cuatrimestre válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Número de estudiante no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese un número de estudiante válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            Horarios consultaHorario = new Horarios(numeroEstudianteIngresado);
            consultaHorario.Show();
            this.Hide();
        }
    }
}
