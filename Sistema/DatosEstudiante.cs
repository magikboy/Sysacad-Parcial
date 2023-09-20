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
        List<Estudiante> estudiantes = new List<Estudiante>();
        public DatosEstudiante()
        {
            InitializeComponent();
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");

            // Verificar si hay estudiantes en la lista
            if (estudiantes.Count > 0)
            {
                // Mostrar el nombre del primer estudiante en textBox1
                textBox1.Text = estudiantes[0].NombreCompleto;
                textBox2.Text = estudiantes[0].ApellidoCompleto;
                textBox3.Text = estudiantes[0].Direccion;
                textBox4.Text = estudiantes[0].CorreoElectronico;
                textBox5.Text = estudiantes[0].NumeroTelefono;
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
            MenuEstudiante menuEstudiante = new MenuEstudiante();
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

    }
}
