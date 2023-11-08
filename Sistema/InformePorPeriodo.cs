using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace Sistema
{
    public partial class InformePorPeriodo : Form
    {
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

            MessageBox.Show("Informe generado exitosamente. Se ha guardado en el escritorio.");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;
            string tituloInforme = textBox1.Text; // Obtener el título desde el TextBox

            int cantidadAlumnos = ObtenerAlumnosEnCuatrimestres(fechaInicio, fechaFin);

            // Crear el informe en PDF con el título dinámico
            GenerarInformePDF(tituloInforme, fechaInicio, fechaFin, cantidadAlumnos);
        }
    }
}
