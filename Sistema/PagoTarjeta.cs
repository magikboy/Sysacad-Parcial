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
    public partial class PagoTarjeta : Form
    {
        private int numeroEstudianteIngresado;
        private List<Estudiante> estudiantes;
        public PagoTarjeta(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");
            MostrarNumeroEstudiante();
        }

        private void MostrarNumeroEstudiante()
        {
            label4.Text = numeroEstudianteIngresado.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu del estudiante
            MenuEstudiante menuEstudiante = new MenuEstudiante(numeroEstudianteIngresado);
            menuEstudiante.Show();
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //mostara mensaje paga pibe
            MessageBox.Show("Pago realizado con exito");
        }
    }
}
