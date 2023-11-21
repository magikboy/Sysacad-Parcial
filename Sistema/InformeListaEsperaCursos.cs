using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        // Variable para controlar si se está generando un informe
        private bool generandoInforme = false;

        public InformeListaEsperaCursos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Volvemos al menú administrador con excepciones
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

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            // Si se está generando un informe, no hacer nada
            if (generandoInforme)
            {
                return;
            }

            // Deshabilitar el botón y los TextBox mientras se genera el informe
            SetControlsEnabled(false);

            // Usar una tarea para ejecutar el proceso en segundo plano
            await GenerateInformeAsync(textBox1.Text);

            // Habilitar el botón y los TextBox después de completar la tarea
            SetControlsEnabled(true);
        }

        private void SetControlsEnabled(bool enabled)
        {
            // Habilitar o deshabilitar el botón y los TextBox según el valor de 'enabled'
            btnIngresar.Enabled = enabled;
            textBox1.Enabled = enabled;
        }

        private async Task GenerateInformeAsync(string nombreArchivo)
        {
            // Marcar que se está generando un informe
            generandoInforme = true;

            // Mostrar un mensaje al usuario para indicar que el informe se está generando.
            MessageBox.Show("Generando informe, por favor espere...", "Generando Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Utilizar Task.Run para ejecutar el proceso de generación de informe en un hilo separado.
            await Task.Run(() => GenerateInforme(nombreArchivo));

            // Esperar 3 segundos antes de mostrar el mensaje de éxito
            await Task.Delay(3000);

            // Mostrar un mensaje al usuario una vez que el informe se ha generado.
            MessageBox.Show($"PDF generado con éxito en el escritorio con el nombre: {nombreArchivo}", "Informe Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Disparar el evento InformeGenerado cuando se genera un informe exitosamente
            InformeGenerado?.Invoke($"{nombreArchivo}.pdf");

            // Marcar que se ha completado la generación del informe
            generandoInforme = false;
        }

        private void GenerateInforme(string nombreArchivo)
        {
            // Obtener la ruta del escritorio
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Crear el documento PDF en el escritorio con el nombre proporcionado
            string nombreArchivoPDF = Path.Combine(desktopPath, $"{nombreArchivo}.pdf");
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(nombreArchivoPDF, FileMode.Create));

            // Abrir el documento PDF
            doc.Open();

            // Conectar a la base de datos y obtener los datos ordenados por FechaEpera
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT `Nombre`, `FechaEpera` FROM `estudiantes` WHERE `FechaEpera` IS NOT NULL ORDER BY `FechaEpera`", connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombreEstudiante = reader.GetString(0);

                        // Verifica si el campo FechaEspera es DBNull o está vacío antes de intentar analizar
                        DateTime fechaEspera;
                        if (!reader.IsDBNull(1) && DateTime.TryParse(reader.GetString(1), out fechaEspera))
                        {
                            // Agregar cada nombre y fecha al documento PDF
                            doc.Add(new Paragraph($"Nombre: {nombreEstudiante}, Fecha de Espera: {fechaEspera.ToShortDateString()}"));
                        }
                    }
                }
            }

            // Cerrar el documento PDF
            doc.Close();
            writer.Close();

            InformeGenerado?.Invoke(nombreArchivoPDF);
        }
    }
}
