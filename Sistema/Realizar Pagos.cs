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
    public partial class Realizar_Pagos : Form
    {
        private int numeroEstudianteIngresado;
        private List<Estudiante> estudiantes;
        public Realizar_Pagos(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");
            MostrarNumeroEstudiante();
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menu del estudiante
            MenuEstudiante menuEstudiante = new MenuEstudiante(numeroEstudianteIngresado);
            menuEstudiante.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir de la aplicacion
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //ir a la ventana de pago con tarjeta si marco el checkBox4 o ir a la ventana de trasferenciabacaria si marco el checkBox5
            if (checkBox4.Checked)
            {
                PagoTarjeta pagoTarjeta = new PagoTarjeta(numeroEstudianteIngresado);
                pagoTarjeta.Show();
                this.Close();
            }
            else if (checkBox5.Checked)
            {
                PagoTransferencia transferenciaBancaria = new PagoTransferencia(numeroEstudianteIngresado);
                transferenciaBancaria.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opcion");
            }
        }
    }
}
