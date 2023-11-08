using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Sistema
{
    public partial class InformePagos : Form
    {
        public InformePagos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Volver al Listainformes con excepciones
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


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Obtén el título de informe
            string titulo = textBox1.Text;

            // Obtén el tipo de pago ingresado por el usuario en el TextBox2
            string tipoPago = textBox2.Text;

            // Validar que el tipo de pago ingresado sea válido (Por ejemplo: "PagoMatricula", "PagoCargosAdministrativos" o "PagoUtilidades")
            switch (tipoPago)
            {
                case "PagoMatricula":
                case "PagoCargosAdministrativos":
                case "PagoUtilidades":
                    break; // Tipo de pago válido
                default:
                    MessageBox.Show("Por favor, ingrese un tipo de pago válido (PagoMatricula, PagoCargosAdministrativos o PagoUtilidades).");
                    return;
            }

            // Consulta la base de datos para contar la cantidad de estudiantes con el tipo de pago especificado
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT COUNT(*) FROM estudiantes WHERE {tipoPago} = 'Pagado'";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    int estudiantesConTipoPago = Convert.ToInt32(cmd.ExecuteScalar());

                    // Generar el PDF en el escritorio
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string pdfFilePath = Path.Combine(desktopPath, $"{titulo}.pdf");

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));
                    doc.Open();
                    doc.Add(new Paragraph("Informe de Pagos"));
                    doc.Add(new Paragraph("Título del Informe: " + titulo));
                    doc.Add(new Paragraph("Tipo de Pago: " + tipoPago));
                    doc.Add(new Paragraph("Cantidad de Estudiantes con este Pago: " + estudiantesConTipoPago));
                    doc.Close();

                    MessageBox.Show("Informe generado con éxito en el escritorio.");
                }
            }
        }


    }
}
