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
    public partial class ListaInformes : Form
    {
        public ListaInformes()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu administrador con exepciones
            try
            {
                // Código que podría generar una excepción
                MenuAdministrador menuAdministrador = new MenuAdministrador();
                menuAdministrador.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir del programa
            try
            {
                // Código que podría generar una excepción
                Application.Exit();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ir al informeDeInscripciones
            try
            {
                // Código que podría generar una excepción
                InformeDeCuatrimeste informeDeInscripciones = new InformeDeCuatrimeste();
                informeDeInscripciones.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //ir al formulario de infromePorPeriodo
            try
            {
                // Código que podría generar una excepción
                InformePorPeriodo informePorPeriodo = new InformePorPeriodo();
                informePorPeriodo.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ir al formulario de informeCursos
            try
            {
                // Código que podría generar una excepción
                InformeCursos informeCursos = new InformeCursos();
                informeCursos.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ir al formulario de informePagos
            try
            {
                // Código que podría generar una excepción
                InformePagos informePagos = new InformePagos();
                informePagos.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ir al menu informeListaEsperaCursos
            try
            {
                // Código que podría generar una excepción
                InformeListaEsperaCursos informeListaEsperaCursos = new InformeListaEsperaCursos();
                informeListaEsperaCursos.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
