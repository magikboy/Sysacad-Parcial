﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class InformePorPeriodo : Form
    {
        // Delegado para el evento personalizado
        public delegate void InformeGeneradoEventHandler(string informePath);

        // Evento personalizado que se dispara cuando se genera un informe exitosamente
        public event InformeGeneradoEventHandler InformeGenerado;

        // Variable para controlar si se está generando un informe
        private bool generandoInforme = false;

        public InformePorPeriodo()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Volver al listainformes con excepciones
            try
            {
                ListaInformes listaInformes = new ListaInformes();
                listaInformes.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int ObtenerAlumnosEnCuatrimestres(DateTime fechaInicio, DateTime fechaFin)
        {
            int cantidadAlumnos = 0;
            string queryString = "SELECT COUNT(*) FROM estudiantes WHERE Cuatrimestre BETWEEN @FechaInicio AND @FechaFin";
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);

                    connection.Open();

                    cantidadAlumnos = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return cantidadAlumnos;
        }

        public void GenerarInformePDF(string tituloInforme, DateTime fechaInicio, DateTime fechaFin, int cantidadAlumnos)
        {
            Document doc = new Document();

            // Obtener la ruta del escritorio
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Combinar la ruta del escritorio con el nombre del archivo PDF
            string pdfFilePath = Path.Combine(desktopPath, "InformePeriodo.pdf");

            using (FileStream fs = new FileStream(pdfFilePath, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Agregar el título dinámico al PDF
                doc.Add(new Paragraph(tituloInforme));

                // Agregar contenido al PDF
                doc.Add(new Paragraph($"Rango de fechas: {fechaInicio.ToShortDateString()} - {fechaFin.ToShortDateString()}"));
                doc.Add(new Paragraph($"Cantidad de alumnos en Inscriptos: {cantidadAlumnos} en este periodo"));

                doc.Close();
            }

            // Disparar el evento InformeGenerado cuando se genera un informe exitosamente
            InformeGenerado?.Invoke(pdfFilePath);
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            // Si se está generando un informe, no hacer nada
            if (generandoInforme)
            {
                return;
            }

            // Deshabilitar los controles mientras se genera el informe
            SetControlsEnabled(false);

            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;
            string tituloInforme = textBox1.Text; // Obtener el título desde el TextBox

            // Mostrar un mensaje al usuario para indicar que el informe se está generando.
            MessageBox.Show("Generando informe, por favor espere...");

            // Utilizar Task.Run para ejecutar el proceso de generación de informe en un hilo separado.
            await GenerateInformeAsync(tituloInforme, fechaInicio, fechaFin);

            // Habilitar los controles después de completar la tarea
            SetControlsEnabled(true);
        }

        private async Task GenerateInformeAsync(string tituloInforme, DateTime fechaInicio, DateTime fechaFin)
        {
            // Marcar que se está generando un informe
            generandoInforme = true;

            // Usar await para permitir que el formulario siga siendo interactivo mientras se genera el informe en segundo plano
            await Task.Run(() =>
            {
                int cantidadAlumnos = ObtenerAlumnosEnCuatrimestres(fechaInicio, fechaFin);

                // Crear el informe en PDF con el título dinámico en el hilo secundario.
                GenerarInformePDF(tituloInforme, fechaInicio, fechaFin, cantidadAlumnos);

                // Esperar 3 segundos antes de mostrar el mensaje de éxito
                Task.Delay(3000).Wait();
            });

            // Mostrar un mensaje al usuario una vez que el informe se ha generado.
            MessageBox.Show("Informe generado exitosamente. Se ha guardado en el escritorio.");

            // Marcar que se ha completado la generación del informe
            generandoInforme = false;
        }

        private void SetControlsEnabled(bool enabled)
        {
            // Habilitar o deshabilitar los controles según el valor de 'enabled'
            textBox1.Enabled = enabled;
            dateTimePicker1.Enabled = enabled;
            dateTimePicker2.Enabled = enabled;
            btnIngresar.Enabled = enabled;
            btnSalir.Enabled = enabled;
        }
    }
}
