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
    public partial class DatosEstudiante : Form
    {
        private List<Estudiante> estudiantes;
        private int numeroEstudianteIngresado;

        public DatosEstudiante(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            estudiantes = GuardarDatosEstudiantes.ReadStreamJSON("estudiantes.json");
            MostrarNumeroEstudiante();

            // Buscar el estudiante por NumeroEstudiante
            Estudiante estudianteSeleccionado = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudianteIngresado);

            if (estudianteSeleccionado != null) // Verifica si se encontró el estudiante
            {
                // Mostrar la información del estudiante en los Labels
                label11.Text = estudianteSeleccionado.NombreCompleto;
                label12.Text = estudianteSeleccionado.ApellidoCompleto;
                label13.Text = estudianteSeleccionado.Direccion;
                label14.Text = estudianteSeleccionado.CorreoElectronico;
                label15.Text = estudianteSeleccionado.NumeroTelefono;
                label16.Text = estudianteSeleccionado.CuatrimestreEstudiante;
            }
            else
            {
                MessageBox.Show("No se encontró un estudiante con ese número.");
                this.Close();
            }
        }

        private void MostrarNumeroEstudiante()
        {
            label17.Text = numeroEstudianteIngresado.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener la contraseña actual y la nueva contraseña ingresadas por el estudiante
            string actualContraseña = textBox6.Text;
            string nuevaContraseña = textBox7.Text;

            // Buscar el estudiante por su número de estudiante
            Estudiante estudianteSeleccionado = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudianteIngresado);

            if (estudianteSeleccionado != null)
            {
                // Verificar si la contraseña actual coincide con la contraseña del estudiante
                if (estudianteSeleccionado.IniciarSesion(actualContraseña))
                {
                    // Cambiar la contraseña del estudiante
                    estudianteSeleccionado.CambiarContraseña(nuevaContraseña);

                    // Actualizar la contraseña en el archivo JSON
                    GuardarDatosEstudiantes.ActualizarContraseñaEstudiante(estudianteSeleccionado);

                    MessageBox.Show("Contraseña cambiada exitosamente.");
                }
                else
                {
                    MessageBox.Show("La contraseña actual es incorrecta. Por favor, inténtelo de nuevo.");
                }
            }
            else
            {
                MessageBox.Show("No se encontró un estudiante con ese número.");
            }

            // Limpiar los TextBox después de cambiar la contraseña
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu del estudiante
            this.Hide();
            MenuEstudiante menuEstudiante = new MenuEstudiante(numeroEstudianteIngresado);
            menuEstudiante.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir
            Application.Exit();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Mostrar la contraseña sin enmascararla
                textBox6.UseSystemPasswordChar = true;
                textBox7.UseSystemPasswordChar = true;
            }
            else
            {
                // Mostrar la contraseña enmascarada con asteriscos
                textBox6.UseSystemPasswordChar = false;
                textBox7.UseSystemPasswordChar = false;
            }
        }
    }
}
