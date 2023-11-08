using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Threading.Tasks;

namespace Sistema
{
    public partial class InformePagos : Form
    {
        public delegate void InformeGeneradoEventHandler(string informePath);
        public event InformeGeneradoEventHandler InformeGenerado;

        public InformePagos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
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

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            string titulo = textBox1.Text;
            string tipoPago = textBox2.Text;

            switch (tipoPago)
            {
                case "PagoMatricula":
                case "PagoCargosAdministrativos":
                case "PagoUtilidades":
                    break;
                default:
                    MessageBox.Show("Por favor, ingrese un tipo de pago válido (PagoMatricula, PagoCargosAdministrativos o PagoUtilidades).");
                    return;
            }

            // Usar una tarea para ejecutar el proceso en segundo plano
            await Task.Run(() => GenerateInforme(titulo, tipoPago));
        }

        private void GenerateInforme(string titulo, string tipoPago)
        {
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT COUNT(*) FROM estudiantes WHERE {tipoPago} = 'Pagado'";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    int estudiantesConTipoPago = Convert.ToInt32(cmd.ExecuteScalar());

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

                    InformeGenerado?.Invoke(pdfFilePath);
                }
            }
        }
    }
}
