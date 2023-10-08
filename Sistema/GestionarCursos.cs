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
    public partial class GestionarCursos : Form
    {
        public GestionarCursos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                // Salir del programa
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar salir del programa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Volver al menú principal
                this.Hide();
                EliminarCurso ingresar = new EliminarCurso();
                ingresar.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar ir al menú EliminarCurso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Volver al menú de administrador
                this.Hide();
                MenuAdministrador menu = new MenuAdministrador();
                menu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar ir al menú MenuAdministrador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Ingresar un nuevo curso
                this.Hide();
                AgregarCurso ingresar = new AgregarCurso();
                ingresar.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar ir al menú AgregarCurso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Elegir un curso para editar
                this.Hide();
                ElegirCurso elegir = new ElegirCurso();
                elegir.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar ir al menú ElegirCurso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
