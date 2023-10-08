using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Sistema
{
    public partial class PagoTransferencia : Form
    {
        private int numeroEstudianteIngresado;
        private List<Estudiante> estudiantes;

        public PagoTransferencia(int numeroEstudiante)
        {
            InitializeComponent();
            this.numeroEstudianteIngresado = numeroEstudiante;
            try
            {
                this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de estudiantes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.estudiantes = new List<Estudiante>();
            }
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
            // Obtener el valor actual en label11.Text
            string valorLabel = label11.Text;

            // Obtener el estudiante correspondiente en la lista
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudianteIngresado);

            try
            {
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

                    // Mostrar mensaje de confirmación
                    string cuentaBancaria = label7.Text; // Obtengo la información de la cuenta bancaria desde label7
                    MessageBox.Show($"Pago de {tituloPago} realizado con éxito. Tiene 3 días para hacer el pago a la siguiente cuenta bancaria:\n\n{cuentaBancaria} " + $"y se envió el comprobante al correo electrónico de {estudiante.CorreoElectronico}");
                }
                else
                {
                    MessageBox.Show("Estudiante no encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
