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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            estudiantes = GuardarDatosEstudiantes.ReadStreamJSON("estudiantes.json");
            MostrarNumeroEstudiante();
            textBox1.KeyPress += textBox1_KeyPress;
            textBox2.KeyPress += textBox2_KeyPress;
            textBox3.KeyPress += textBox3_KeyPress;
            textBox4.KeyPress += textBox4_KeyPress;
            textBox7.KeyPress += textBox7_KeyPress;
            textBox1.MaxLength = 4;
            textBox2.MaxLength = 4;
            textBox3.MaxLength = 4;
            textBox4.MaxLength = 4;
            textBox7.MaxLength = 3;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
        }

        private void MostrarNumeroEstudiante()
        {
            label4.Text = numeroEstudianteIngresado.ToString();
        }

        public void ValorTotalTarjeta(string value)
        {
            label11.Text = value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Obtener el número ingresado en textBox1
            string numeroTarjeta = textBox1.Text;

            // Comprobar si el número de tarjeta es Visa (comienza con "4")
            if (numeroTarjeta.StartsWith("4"))
            {
                pictureBox4.Visible = true;
                pictureBox3.Visible = false;
            }
            // Comprobar si el número de tarjeta es MasterCard (comienza con "3")
            else if (numeroTarjeta.StartsWith("3"))
            {
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
            }
            else
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
            }
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
            // Obtener el valor actual en label11.Text
            string valorLabel = label11.Text;

            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Obtener el estudiante correspondiente en la lista
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudianteIngresado);

            // Verificar si todos los campos del 1 al 7 y los numericUpDown no están vacíos
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                numericUpDown1.Value == 0 || // Verificar que numericUpDown1 no esté vacío
                numericUpDown2.Value == 0)   // Verificar que numericUpDown2 no esté vacío
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return; // Salir de la función si no están completos
            }

            // Obtener los valores de los TextBox del 1 al 7
            string valor1 = textBox1.Text;
            string valor2 = textBox2.Text;
            string valor3 = textBox3.Text;
            string valor4 = textBox4.Text;
            string valor5 = textBox5.Text;
            string valor7 = textBox7.Text;

            // Obtener los valores de los numericUpDown
            int mes = (int)numericUpDown2.Value;
            int año = (int)numericUpDown1.Value;

            if (estudiante != null)
            {
                string tituloPago = string.Empty; // Variable para el título del pago

                // Realizar las actualizaciones en función del valor en label11.Text y definir el título del pago
                switch (valorLabel)
                {
                    case "10000$":
                        estudiante.PagoMatricula = "pagado";
                        tituloPago = "Matrícula";
                        break;
                    case "5000$":
                        estudiante.PagoCargosAdministrativos = "pagado";
                        tituloPago = "Cargos Administrativos";
                        break;
                    case "1000$":
                        estudiante.PagoUtilidades = "pagado";
                        tituloPago = "Utilidades";
                        break;
                    case "15000$":
                        estudiante.PagoMatricula = "pagado";
                        estudiante.PagoCargosAdministrativos = "pagado";
                        tituloPago = "Matrícula y Cargos Administrativos";
                        break;
                    case "11000$":
                        estudiante.PagoMatricula = "pagado";
                        estudiante.PagoUtilidades = "pagado";
                        tituloPago = "Matrícula y Utilidades";
                        break;
                    case "6000$":
                        estudiante.PagoCargosAdministrativos = "pagado";
                        estudiante.PagoUtilidades = "pagado";
                        tituloPago = "Cargos Administrativos y Utilidades";
                        break;
                    default:
                        // Manejar otros casos si es necesario
                        break;
                }

                // Guardar la lista actualizada en el archivo JSON
                GuardarDatosEstudiantes.ActualizarPagoEstudiante(estudiante);

                // Mostrar mensaje de pago exitoso y comprobante, incluyendo los valores de los numericUpDown
                string mensaje = $"Pago de {tituloPago} realizado con éxito el {fechaActual.ToString("dd/MM/yyyy")}\n\n por un monto de {valorLabel}. " +
                                 $"\n\nDetalles de la transacción: " +
                                 $"\n\nNumero: {valor1}{valor2}{valor3}{valor4}, " +
                                 $"\n\nNombre: {valor5}" +
                                 $"\n\nCvv: {valor7} " +
                                 $"\n\nMes de expiración: {mes} " +
                                 $"\n\nAño de expiración: {año}"+
                                 $"\n\nse envio el comprobante al mail de {estudiante.CorreoElectronico}";
                MessageBox.Show(mensaje);
            }
            else
            {
                MessageBox.Show("Estudiante no encontrado");
            }
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (por ejemplo, retroceso)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //mes
            numericUpDown2.Minimum = 1;
            numericUpDown2.Maximum = 12;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //año
            numericUpDown1.Minimum = 23;
            numericUpDown1.Maximum = 30;
        }
    }
}
