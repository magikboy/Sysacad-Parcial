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
    public partial class PagoTransferencia : Form
    {
        private int numeroEstudianteIngresado;
        private List<Estudiante> estudiantes;
        public PagoTransferencia(int numeroEstudiante)
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
        public void ValorTotalTransferencia(string value)
        {
            label11.Text = value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //voler al menu del estudiante
            MenuEstudiante menuEstudiante = new MenuEstudiante(numeroEstudianteIngresado);
            menuEstudiante.Show();
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Obtener el valor actual en label11.Text
            string valorLabel = label11.Text;

            // Obtener el estudiante correspondiente en la lista
            Estudiante estudiante = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudianteIngresado);

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
                    case "1100$":
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
                GuardarDatos.ActualizarPagoEstudiante(estudiante);

                // Mostrar mensaje de confirmación
                string cuentaBancaria = label7.Text; // Obtengo la información de la cuenta bancaria desde label7
                MessageBox.Show($"Pago de {tituloPago} realizado con éxito. Tiene 3 días para hacer el pago a la siguiente cuenta bancaria:\n\n{cuentaBancaria}");

            }
            else
            {
                MessageBox.Show("Estudiante no encontrado");
            }
        }
    }
}
