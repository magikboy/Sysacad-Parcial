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
    public partial class EliminarCurso : Form
    {
        public EliminarCurso()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu administrador
            this.Hide();
            MenuAdministrador menu = new MenuAdministrador();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mensaje de confirmacion
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el curso?", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //eliminar curso
                MessageBox.Show("Curso eliminado");
                this.Hide();
                MenuAdministrador menu = new MenuAdministrador();
                menu.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                //no hacer nada
            }
        }
    }
}
