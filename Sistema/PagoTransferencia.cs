using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sistema
{
    public partial class PagoTransferencia : Form
    {
        private int numeroEstudianteIngresado;

        public PagoTransferencia(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();
        }

        private void MostrarNumeroEstudiante()
        {
            label4.Text = numeroEstudianteIngresado.ToString();
        }

        public void ValorTotalTransferencia(string value)
        {
            label11.Text = value;
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
                MessageBox.Show($"Error al regresar al menú del estudiante: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                            // Mostrar mensaje de confirmación
                            string cuentaBancaria = label7.Text; // Obtén la información de la cuenta bancaria desde label7
                            MessageBox.Show($"Pago realizado con éxito. Tiene 3 días para hacer el pago a la siguiente cuenta bancaria:\n\n{cuentaBancaria}");
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
    }
}
