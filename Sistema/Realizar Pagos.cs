using Biblioteca;
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sistema
{
    public partial class Realizar_Pagos : Form
    {
        private int numeroEstudianteIngresado;
        private int acumulado = 0; // Variable para mantener el valor en label16

        public Realizar_Pagos(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
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

            // Verificar los pagos desde la base de datos
            VerificarPagosDesdeBD();

            // Cargar los datos del estudiante desde la base de datos
            CargarDatosEstudianteDesdeBD();
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
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

        private void CargarDatosEstudianteDesdeBD()
        {
            try
            {
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener los datos del estudiante
                    string selectQuery = "SELECT * FROM estudiantes WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", numeroEstudianteIngresado);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Verificar PagoMatricula y PagoCargosAdministrativos
                                if (reader["PagoMatricula"].ToString() == "pagado")
                                {
                                    checkBox1.Enabled = false;
                                    label17.Visible = false;
                                    label9.Text = "Pagado";
                                }

                                if (reader["PagoCargosAdministrativos"].ToString() == "pagado")
                                {
                                    checkBox2.Enabled = false;
                                    label18.Visible = false;
                                    label10.Text = "Pagado";
                                }

                                if (reader["PagoUtilidades"].ToString() == "pagado")
                                {
                                    checkBox3.Enabled = false;
                                    label19.Visible = false;
                                    label11.Text = "Pagado";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del estudiante desde la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerificarPagosDesdeBD()
        {
            try
            {
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para verificar los pagos desde la base de datos
                    string selectQuery = "SELECT PagoMatricula, PagoCargosAdministrativos, PagoUtilidades FROM estudiantes WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", numeroEstudianteIngresado);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Verificar PagoMatricula y PagoCargosAdministrativos
                                if (reader["PagoMatricula"].ToString() == "pagado")
                                {
                                    checkBox1.Enabled = false;
                                    label17.Visible = false;
                                    label9.Text = "Pagado";
                                }

                                if (reader["PagoCargosAdministrativos"].ToString() == "pagado")
                                {
                                    checkBox2.Enabled = false;
                                    label18.Visible = false;
                                    label10.Text = "Pagado";
                                }

                                if (reader["PagoUtilidades"].ToString() == "pagado")
                                {
                                    checkBox3.Enabled = false;
                                    label19.Visible = false;
                                    label11.Text = "Pagado";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar los pagos desde la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Volver al menú del estudiante
            MenuEstudiante menuEstudiante = new MenuEstudiante(numeroEstudianteIngresado);
            menuEstudiante.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Salir de la aplicación
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Ir a la ventana de pago con tarjeta si se marcó el checkBox4 o ir a la ventana de transferencia bancaria si se marcó el checkBox5
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
                MessageBox.Show("Debe seleccionar una opción");
            }
        }
    }
}
