using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;

namespace Sistema
{
    public partial class MenuNotificacion : Form
    {
        private int numeroEstudianteIngresado;
        public MenuNotificacion(int numeroEstudiante)
        {
            this.numeroEstudianteIngresado = numeroEstudiante;
            InitializeComponent();
            MostrarFechasDeNotificaciones();
            MostrarNumeroEstudiante();
            // Generar el PDF al cargar el formulario
            GenerarPDF();
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
        }

        private void MostrarFechasDeNotificaciones()
        {
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM notificaciones WHERE id = 1"; // Cambia 1 por el ID de la notificación que desees mostrar.

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime fechaActual = DateTime.Now;

                            ActualizarSiFechaEstaVencida(reader, "FechaLimiteInscripcion", label4, 5);
                            ActualizarSiFechaEstaVencida(reader, "InicioPeriodoAcademico", label5, 5);
                            ActualizarSiFechaEstaVencida(reader, "CambiosDeHorario", label6, 5);
                            ActualizarSiFechaEstaVencida(reader, "FechaPago", label7, 5);

                            // Verificar pagos del estudiante
                            VerificarPagosEstudiante();
                            VerificarCuatrimestreEstudiante();
                        }
                    }
                }
            }
        }

        private void VerificarCuatrimestreEstudiante()
        {
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Consulta para obtener el cuatrimestre del estudiante por su número de legajo
                string cuatrimestreQuery = "SELECT Cuatrimestre FROM estudiantes WHERE Legajo = @legajo";

                using (MySqlCommand cuatrimestreCommand = new MySqlCommand(cuatrimestreQuery, connection))
                {
                    cuatrimestreCommand.Parameters.AddWithValue("@legajo", numeroEstudianteIngresado);

                    using (MySqlDataReader cuatrimestreReader = cuatrimestreCommand.ExecuteReader())
                    {
                        if (cuatrimestreReader.Read())
                        {
                            string cuatrimestreActual = cuatrimestreReader["Cuatrimestre"].ToString();

                            // Mapear nombres de cuatrimestres a números
                            int cuatrimestreActualNumerico = MapearCuatrimestreANumero(cuatrimestreActual);

                            if (cuatrimestreActualNumerico > 0)
                            {
                                // Definir el siguiente cuatrimestre
                                int siguienteCuatrimestre = cuatrimestreActualNumerico + 1;

                                // Verificar si el cuatrimestre está dentro de un rango válido
                                if (siguienteCuatrimestre <= 3)
                                {
                                    label14.Text = "Siguiente cuatrimestre:  " + MapearNumeroACuatrimestre(siguienteCuatrimestre);
                                }
                                else
                                {
                                    label14.Text = "No hay cuatrimestre siguiente";
                                }
                            }
                        }
                    }
                }
            }
        }

        private int MapearCuatrimestreANumero(string cuatrimestre)
        {
            // Mapear nombres de cuatrimestres a números
            if (cuatrimestre == "Primer Cuatrimestre") return 1;
            if (cuatrimestre == "Segundo Cuatrimestre") return 2;
            if (cuatrimestre == "Tercer Cuatrimestre") return 3;
            return 0; // Cuatrimestre no válido
        }

        private string MapearNumeroACuatrimestre(int numero)
        {
            // Mapear números de cuatrimestres a nombres
            if (numero == 1) return "Primer Cuatrimestre";
            if (numero == 2) return "Segundo Cuatrimestre";
            if (numero == 3) return "Tercer Cuatrimestre";
            return "Cuatrimestre no válido";
        }


        private void ActualizarSiFechaEstaVencida(MySqlDataReader reader, string nombreColumna, Label etiqueta, int diasAdicionales)
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaLimite;

            if (DateTime.TryParse(reader[nombreColumna].ToString(), out fechaLimite))
            {
                if (fechaLimite < fechaActual)
                {
                    // La fecha está vencida, actualízala automáticamente con 5 días adicionales.
                    fechaLimite = fechaActual.AddDays(diasAdicionales);
                    // Ahora actualiza la fecha en la base de datos.
                    ActualizarFechaEnBaseDeDatos(nombreColumna, fechaLimite);

                    etiqueta.Text = "Fecha límite: " + fechaLimite.ToString();
                }
                else
                {
                    etiqueta.Text = "Fecha límite: " + fechaLimite.ToString();
                }
            }
        }

        private void ActualizarFechaEnBaseDeDatos(string nombreColumna, DateTime nuevaFecha)
        {
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = $"UPDATE notificaciones SET {nombreColumna} = @nuevaFecha WHERE id = 1";
                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@nuevaFecha", nuevaFecha);
                    updateCommand.ExecuteNonQuery();
                }
            }
        }

        private void VerificarPagosEstudiante()
        {
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Consulta para obtener la información de pagos del estudiante por su número de legajo
                string pagosQuery = "SELECT PagoMatricula, PagoCargosAdministrativos, PagoUtilidades FROM estudiantes WHERE Legajo = @legajo";

                using (MySqlCommand pagosCommand = new MySqlCommand(pagosQuery, connection))
                {
                    pagosCommand.Parameters.AddWithValue("@legajo", numeroEstudianteIngresado);

                    using (MySqlDataReader pagosReader = pagosCommand.ExecuteReader())
                    {
                        if (pagosReader.Read())
                        {
                            string pagoMatricula = pagosReader["PagoMatricula"].ToString();
                            string pagoCargosAdministrativos = pagosReader["PagoCargosAdministrativos"].ToString();
                            string pagoUtilidades = pagosReader["PagoUtilidades"].ToString();

                            if (pagoMatricula == "pagado" && pagoCargosAdministrativos == "pagado" && pagoUtilidades == "pagado")
                            {
                                // Si los tres pagos están realizados, oculta la notificación
                                label12.Text = "No hay pagos pendientes";
                            }
                            else
                            {
                                // Si falta uno o más pagos, muestra cuál falta en el Label 12
                                string pagosPendientes = "Falta pagar: ";
                                if (pagoMatricula != "pagado") pagosPendientes += "Matrícula ,";
                                if (pagoCargosAdministrativos != "pagado") pagosPendientes += "Cargos Administrativos ,";
                                if (pagoUtilidades != "pagado") pagosPendientes += "Utilidades ";

                                label12.Text = pagosPendientes;
                            }
                        }
                    }
                }
            }
        }


        private void GenerarPDF()
        {
            // Verificar si alguna notificación no se pudo mostrar
            bool hayErrores = false;

            // Verificar si alguna notificación está en blanco o tiene un error
            if (string.IsNullOrEmpty(label4.Text) || label4.Text.Contains("Error"))
            {
                hayErrores = true;
            }

            if (string.IsNullOrEmpty(label5.Text) || label5.Text.Contains("Error"))
            {
                hayErrores = true;
            }

            if (string.IsNullOrEmpty(label6.Text) || label6.Text.Contains("Error"))
            {
                hayErrores = true;
            }

            if (string.IsNullOrEmpty(label7.Text) || label7.Text.Contains("Error"))
            {
                hayErrores = true;
            }

            if (hayErrores)
            {
                // Crear un documento PDF en el escritorio solo si hay errores
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string pdfFilePath = Path.Combine(desktopPath, "Notificaciones.pdf");
                Document document = new Document();

                try
                {
                    PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
                    document.Open();

                    // Agregar título
                    Paragraph title = new Paragraph("Notificaciones");
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);

                    // Agregar número de estudiante
                    document.Add(new Paragraph("Número de Estudiante: " + numeroEstudianteIngresado));

                    // Agregar información de notificaciones
                    document.Add(new Paragraph("Fechas de Notificaciones:"));

                    // Agregar las fechas de notificaciones desde tus etiquetas (label4, label5, etc.) al documento PDF.
                    document.Add(new Paragraph("Fecha Límite de Inscripción: " + label4.Text));
                    document.Add(new Paragraph("Inicio del Período Académico: " + label5.Text));
                    document.Add(new Paragraph("Cambios de Horario: " + label6.Text));
                    document.Add(new Paragraph("Fecha de Pago: " + label7.Text));

                    // Cerrar el documento
                    document.Close();

                    MessageBox.Show("Notificaciones exportadas a PDF en el escritorio: Notificaciones.pdf");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar las notificaciones a PDF: " + ex.Message);
                }
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Volver al menú estudiante
            MenuEstudiante menuEstudiante = new MenuEstudiante(numeroEstudianteIngresado);
            menuEstudiante.Show();
            this.Hide();
        }
    }
}
