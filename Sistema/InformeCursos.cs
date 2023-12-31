﻿using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Threading.Tasks;
using Biblioteca;

namespace Sistema
{
    public partial class InformeCursos : Form, IInformeGenerator
    {
        // Delegado para el evento personalizado
        public delegate void InformeGeneradoEventHandler(string informePath);

        // Evento personalizado que se dispara cuando se genera un informe exitosamente
        public event InformeGeneradoEventHandler InformeGenerado;

        public InformeCursos()
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

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            // Usar una tarea para ejecutar el proceso en segundo plano
            await GenerateInformeAsync();
        }

        public async Task<string> GenerateInformeAsync(int cursoId, string titulo)
        {
            // Deshabilitar los TextBox durante la generación del informe
            SetTextBoxesEnabled(false);

            // Mostrar mensaje de generación en curso
            ShowGeneratingMessage();

            // Tu lógica existente para generar el informe
            await GenerateInformeAsync();

            // Devolver la ruta del archivo generado
            string pdfFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "InformeCurso.pdf");

            // Mostrar mensaje de éxito
            ShowSuccessMessage();

            // Disparar el evento InformeGenerado cuando se genera un informe exitosamente
            InformeGenerado?.Invoke(pdfFilePath);

            // Habilitar los TextBox después de completar la generación del informe
            SetTextBoxesEnabled(true);

            // Devolver la ruta del archivo generado
            return pdfFilePath;
        }

        private async Task GenerateInformeAsync()
        {
            // Deshabilitar los TextBox durante la generación del informe
            SetTextBoxesEnabled(false);

            // Mostrar mensaje de generación en curso
            ShowGeneratingMessage();

            // Obtén el ID del curso y el título de los TextBox
            int cursoId;
            if (int.TryParse(textBox2.Text, out cursoId))
            {
                string titulo = textBox1.Text;

                // Consulta la base de datos para obtener información del curso
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM cursos WHERE id = @cursoId";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@cursoId", cursoId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nombre = reader["nombre"].ToString();
                                string descripcion = reader["Descripcion"].ToString();
                                int cuposDisponibles = Convert.ToInt32(reader["CuposDisponibles"]);
                                string profesor = reader["Profesor"].ToString();

                                // Calcular la cantidad de estudiantes registrados en el curso
                                int estudiantesRegistrados = 30 - cuposDisponibles;

                                // Obtener la ruta del escritorio
                                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                                // Generar el PDF en el escritorio
                                string pdfFilePath = Path.Combine(desktopPath, "InformeCurso.pdf");

                                Document doc = new Document();
                                PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));
                                doc.Open();
                                doc.Add(new Paragraph("Informe del Curso"));
                                doc.Add(new Paragraph("Título del Informe: " + titulo));
                                doc.Add(new Paragraph("Nombre del Curso: " + nombre));
                                doc.Add(new Paragraph("Descripción del Curso: " + descripcion));
                                doc.Add(new Paragraph("Profesor: " + profesor));
                                doc.Add(new Paragraph("Estudiantes Registrados: " + estudiantesRegistrados));
                                doc.Close();

                                // Esperar 3 segundos antes de mostrar el segundo mensaje
                                await Task.Delay(3000);

                                // Mostrar mensaje de éxito
                                ShowSuccessMessage();

                                // Disparar el evento InformeGenerado cuando se genera un informe exitosamente
                                InformeGenerado?.Invoke(pdfFilePath);
                            }
                            else
                            {
                                MessageBox.Show("Curso no encontrado.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de curso válido.");
            }

            // Habilitar los TextBox después de completar la generación del informe
            SetTextBoxesEnabled(true);
        }

        private void ShowGeneratingMessage()
        {
            MessageBox.Show("Generando informe. Por favor, espere...", "Generando", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowSuccessMessage()
        {
            MessageBox.Show("Informe generado con éxito en el escritorio.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetTextBoxesEnabled(bool enabled)
        {
            // Habilitar o deshabilitar los TextBox según el valor de 'enabled'
            textBox1.Enabled = enabled;
            textBox2.Enabled = enabled;
        }
    }
}
