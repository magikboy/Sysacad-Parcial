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
    public partial class DatosEstudiante : Form
    {
        private Estudiante estudianteSeleccionado;
        private List<Estudiante> estudiantes;
        public DatosEstudiante(int numeroEstudiante)
        {
            InitializeComponent();
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");

            // Buscar el estudiante por NumeroEstudiante
            estudianteSeleccionado = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante);

            if (estudianteSeleccionado != null)
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //mostrar el solo el nombre del estudiante

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu del estudiante
            this.Hide();
            MenuEstudiante menuEstudiante = new MenuEstudiante(estudianteSeleccionado.NumeroEstudiante);
            menuEstudiante.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string actualContraseña = textBox6.Text;
            string nuevaContraseña = textBox7.Text;

            // Buscar el estudiante actual en la lista de estudiantes
            Estudiante estudianteActual = estudiantes.FirstOrDefault();

            if (estudianteActual != null)
            {
                // Verificar que la contraseña actual sea correcta
                if (estudianteActual.Contrasenia == actualContraseña)
                {
                    // Cambiar la contraseña del estudiante
                    estudianteActual.CambiarContraseña(nuevaContraseña);

                    // Actualizar la contraseña en el archivo JSON
                    GuardarDatos.ActualizarContraseñaEstudiante(estudianteActual);

                    MessageBox.Show("Contraseña cambiada exitosamente");
                }
                else
                {
                    MessageBox.Show("La contraseña actual es incorrecta");
                }
            }
            else
            {
                MessageBox.Show("No se encontró un estudiante para cambiar la contraseña");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
