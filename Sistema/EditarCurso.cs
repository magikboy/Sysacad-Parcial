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
    public partial class EditarCurso : Form
    {
        public EditarCurso()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //mensaje ok
            MessageBox.Show("Curso editado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //volver al menu de administrador
            this.Hide();
            MenuAdministrador admin = new MenuAdministrador();
            admin.Show();

        }
    }
}
