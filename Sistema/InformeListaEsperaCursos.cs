using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;


namespace Sistema
{
    public partial class InformeListaEsperaCursos : Form
    {
        string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

        // Delegado para el evento personalizado
        public delegate void InformeGeneradoEventHandler(string informePath);

        // Evento personalizado que se dispara cuando se genera un informe exitosamente
        public event InformeGeneradoEventHandler InformeGenerado;

        public InformeListaEsperaCursos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                MenuAdministrador menuAdministrador = new MenuAdministrador();
                menuAdministrador.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        {
            // Obtener el nombre de la materia y el título del PDF desde los TextBox
            string materia = textBox2.Text;
            string tituloPDF = textBox1.Text;

            // Usar una tarea para ejecutar el proceso en segundo plano
            await Task.Run(() => GenerateInforme(materia, tituloPDF));
        }

        private void GenerateInforme(string materia, string tituloPDF)
        {
            // Obtener la ruta del escritorio
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Crear el documento PDF en el escritorio
            string nombreArchivoPDF = Path.Combine(desktopPath, "Informe_" + materia + ".pdf");
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(nombreArchivoPDF, FileMode.Create));

            doc.Open();
            doc.Add(new Paragraph(tituloPDF));

            // Conectar a la base de datos y obtener los datos
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT `NombreEstudiante`, `Fecha` FROM `listadeespera` WHERE `NombreMateria` = @materia", connection);
                cmd.Parameters.AddWithValue("@materia", materia);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombreEstudiante = reader.GetString(0);
                        DateTime fecha = reader.GetDateTime(1);
                        doc.Add(new Paragraph($"Nombre: {nombreEstudiante}, Fecha: {fecha.ToShortDateString()}"));
                    }
                }
            }

            doc.Close();
            writer.Close();

            MessageBox.Show("PDF generado con éxito en el escritorio.");

            // Disparar el evento InformeGenerado cuando se genera un informe exitosamente
            InformeGenerado?.Invoke(nombreArchivoPDF);
        }


    }
}
