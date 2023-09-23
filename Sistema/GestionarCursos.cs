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

        private void Cursos_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir del programa
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //volver al menu principal
            this.Hide();
            EliminarCurso ingresar = new EliminarCurso();
            ingresar.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu de administrador
            this.Hide();
            MenuAdministrador menu = new MenuAdministrador();
            menu.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //ingresar un nuevo curso
            this.Hide();
            AgregarCurso ingresar = new AgregarCurso();
            ingresar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //elegir un curso para editar
            this.Hide();
            ElegirCurso elegir = new ElegirCurso();
            elegir.Show();
        }
    }
}
