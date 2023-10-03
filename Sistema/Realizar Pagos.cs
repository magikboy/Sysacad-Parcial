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
        private int acumulado = 0; // Variable para mantener el valor en label16
        public Realizar_Pagos(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
            MostrarNumeroEstudiante();
            // Establecer los valores iniciales de los Label
            label9.Text = "10000$";
            label10.Text = "5000$";
            label11.Text = "1000$";
            // Inicializar label16 en 0
            label16.Text = "0";

            // Suscribirse a los eventos CheckedChanged de los CheckBox
            checkBox1.CheckedChanged += CheckBox_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox_CheckedChanged;
            checkBox3.CheckedChanged += CheckBox_CheckedChanged;

            // Cargar los datos del estudiante desde el JSON
            Estudiante estudiante = estudiantes.FirstOrDefault(e => e.NumeroEstudiante == numeroEstudiante);
            if (estudiante != null)
            {
                // Verificar PagoMatricula y PagoCargosAdministrativos
                if (estudiante.PagoMatricula == "pagado")
                {
                    checkBox1.Enabled = false;
                    label17.Visible = false;
                }

                if (estudiante.PagoCargosAdministrativos == "pagado")
                {
                    checkBox2.Enabled = false;
                    label18.Visible = false;
                }

                if (estudiante.PagoUtilidades == "pagado")
                {
                    checkBox3.Enabled = false;
                    label19.Visible = false;
                }
            }
        }
        // Manejador de eventos para los CheckBox
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            // Obtener el valor del CheckBox correspondiente
            int valor = 0;

            if (checkBox == checkBox1)
            {
                valor = 10000;
            }
            else if (checkBox == checkBox2)
            {
                valor = 5000;
            }
            else if (checkBox == checkBox3)
            {
                valor = 1000;
            }

            // Actualizar el acumulado dependiendo de si el CheckBox está marcado o no
            if (checkBox.Checked)
            {
                acumulado += valor;
            }
            else
            {
                acumulado -= valor;
            }

            // Actualizar label16 con el valor acumulado
            label16.Text = acumulado.ToString() + "$";
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
                pagoTarjeta.ValorTotalTarjeta(label16.Text); // Pasar el valor de label16 al segundo formulario
                pagoTarjeta.Show();
                this.Close();
            }
            else if (checkBox5.Checked)
            {
                PagoTransferencia transferenciaBancaria = new PagoTransferencia(numeroEstudianteIngresado);
                transferenciaBancaria.ValorTotalTransferencia(label16.Text); // Pasar el valor de label16 al segundo formulario
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
