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
    public partial class MenuGestionarProfesor : Form
    {
        public MenuGestionarProfesor()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir del programa
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu de administrador con excepciones
            try
            {
                MenuAdministrador menuAdministrador = new MenuAdministrador();
                menuAdministrador.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //ingresar un profesor con excepciones
            try
            {
                AgregarProfesor ingresarProfesor = new AgregarProfesor();
                ingresarProfesor.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ELegir un profesor con excepciones
            try
            {
                ElegirProfesor elegirProfesor = new ElegirProfesor();
                elegirProfesor.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //asignar a un curso un profesor con excepciones
            try
            {
                AsignarCursoProfesor asignarProfesor = new AsignarCursoProfesor();
                asignarProfesor.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //eliminar un profesor con excepciones
            try
            {
                EliminarProfesor eliminarProfesor = new EliminarProfesor();
                eliminarProfesor.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
