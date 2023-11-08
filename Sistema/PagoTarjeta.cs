using Biblioteca;
using MySql.Data.MySqlClient;
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
            this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Volver al menú del estudiante
                MenuEstudiante menuEstudiante = new MenuEstudiante(numeroEstudianteIngresado);
                menuEstudiante.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string valorLabel = label11.Text; // Obtener el valor actual en label11.Text
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Definir la sentencia SQL para actualizar la base de datos
                    string updateQuery = "";

                    // Determinar la sentencia SQL y el título del pago en función del valor en label11.Text
                    switch (valorLabel)
                    {
                        case "10000$":
                            updateQuery = "UPDATE estudiantes SET PagoMatricula = 'pagado' WHERE id = @id";
                            break;
                        case "5000$":
                            updateQuery = "UPDATE estudiantes SET PagoCargosAdministrativos = 'pagado' WHERE id = @id";
                            break;
                        case "1000$":
                            updateQuery = "UPDATE estudiantes SET PagoUtilidades = 'pagado' WHERE id = @id";
                            break;
                        case "15000$":
                            updateQuery = "UPDATE estudiantes SET PagoMatricula = 'pagado', PagoCargosAdministrativos = 'pagado' WHERE id = @id";
                            break;
                        case "11000$":
                            updateQuery = "UPDATE estudiantes SET PagoMatricula = 'pagado', PagoUtilidades = 'pagado' WHERE id = @id";
                            break;
                        case "6000$":
                            updateQuery = "UPDATE estudiantes SET PagoCargosAdministrativos = 'pagado', PagoUtilidades = 'pagado' WHERE id = @id";
                            break;
                        default:
                            // Manejar otros casos si es necesario
                            break;
                    }

                    if (!string.IsNullOrEmpty(updateQuery))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", numeroEstudianteIngresado);
                            cmd.ExecuteNonQuery();

                            // Validar que los campos de tarjeta de crédito sean válidos
                            if (!Validacion.ValidarTarjetaCredito4numeros(textBox1.Text) || !Validacion.ValidarTarjetaCredito4numeros(textBox2.Text) || !Validacion.ValidarTarjetaCredito4numeros(textBox3.Text) || !Validacion.ValidarTarjetaCredito4numeros(textBox4.Text))
                            {
                                MessageBox.Show("Por favor, ingrese 4 dígitos válidos en los campos de la tarjeta de crédito.");
                                return;
                            }

                            // Validar que el campo CVV sea válido
                            if (!Validacion.ValidarTarjetaCredito3numeros(textBox7.Text))
                            {
                                MessageBox.Show("Por favor, ingrese 3 dígitos válidos en el campo de CVV.");
                                return;
                            }

                            // Realizar otras operaciones relacionadas con el pago
                            // ...

                            // Mostrar mensaje de confirmación
                            string mensaje = $"Pago con tarjeta de crédito realizado con éxito.\n\nEl estudiante con ID {numeroEstudianteIngresado} ha realizado el pago de {valorLabel}.";
                            MessageBox.Show(mensaje);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo procesar el pago debido a un valor no reconocido en label11.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    // Permitir solo números y teclas de control
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Permitir solo números y teclas de control
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Permitir solo números y teclas de control
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Permitir solo números y teclas de control
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Permitir solo números y teclas de control
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Mes
                numericUpDown2.Minimum = 1;
                numericUpDown2.Maximum = 12;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Año
                numericUpDown1.Minimum = 23;
                numericUpDown1.Maximum = 30;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
