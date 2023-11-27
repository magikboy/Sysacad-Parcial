using Biblioteca;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class MenuEstudiante : Form
    {
        private int numeroEstudianteIngresado;
        private List<Estudiante> estudiantes;

        private NotificacionManejada notificacionManejada;

        private System.Windows.Forms.Timer timer; // Especificar que se utilizará Timer de System.Windows.Forms

        public MenuEstudiante(int numeroEstudiante)
        {
            InitializeComponent();
            InitializeTimer();
            this.numeroEstudianteIngresado = numeroEstudiante;
            this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
            label1.ForeColor = Color.White;
            MostrarNumeroEstudiante();
            // Inicializar NotificacionManejada
            notificacionManejada = new NotificacionManejada();

            // Suscribirte al evento NotificacionClicada
            notificacionManejada.NotificacionClicada += NotificacionClicadaHandler;
        }

        private void InitializeTimer()
        {
            // Inicializar el temporizador
            timer = new System.Windows.Forms.Timer(); // Especificar que se utilizará Timer de System.Windows.Forms
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 2000; // Intervalo de 2000 milisegundos (2 segundos)
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Este método se llama cuando el temporizador alcanza su intervalo
            timer.Stop(); // Detener el temporizador para evitar llamadas adicionales

            // Redirigir al formulario de login
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Iniciar el temporizador cuando se hace clic en el botón
                timer.Start();
                //mensaje de que esta volviendo al menu de login
                MessageBox.Show("Volviendo al menú de login", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NotificacionClicadaHandler(object sender, NotificacionEventArgs e)
        {
            // Este método ahora se utiliza para actualizar el label5 con el número de notificaciones sin leer
            int numeroNotificaciones = e.NumeroNotificaciones;
            label5.Text = numeroNotificaciones > 0 ? $"{numeroNotificaciones}" : "";

            // Verificar pagos del estudiante y actualizar label5
            VerificarPagosEstudiante();
        }

        private void VerificarPagosEstudiante()
        {
            try
            {
                // Establece la cadena de conexión a la base de datos MySQL
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

                                // Contar la cantidad de pagos pendientes
                                int pagosPendientes = 0;
                                if (pagoMatricula != "pagado") pagosPendientes++;
                                if (pagoCargosAdministrativos != "pagado") pagosPendientes++;
                                if (pagoUtilidades != "pagado") pagosPendientes++;

                                label5.Text = pagosPendientes > 0 ? $"{pagosPendientes}" : "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al verificar los pagos: " + ex.Message);
            }
        }

        private void MostrarNumeroEstudiante()
        {
            label1.Text = numeroEstudianteIngresado.ToString();
            label1.ForeColor = Color.White;

            try
            {
                // Establece la cadena de conexión a la base de datos MySQL
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener los campos PagoMatricula, PagoUtilidades, y PagoCargosAdministrativos
                    string query = "SELECT PagoMatricula, PagoUtilidades, PagoCargosAdministrativos FROM estudiantes WHERE Legajo = @Legajo";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Legajo", numeroEstudianteIngresado);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Verificar pagos del estudiante y actualizar label5
                            VerificarPagosEstudiante();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al verificar los pagos: " + ex.Message);
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Establece la cadena de conexión a la base de datos MySQL
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para buscar al estudiante por su número de legajo
                    string query = "SELECT * FROM estudiantes WHERE Legajo = @Legajo";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Legajo", numeroEstudianteIngresado);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Si se encuentra un estudiante, puedes obtener los datos aquí
                            // Puedes abrir el formulario de DatosEstudiante para mostrar los detalles si es necesario
                            DatosEstudiante datosEstudiante = new DatosEstudiante(numeroEstudianteIngresado);
                            datosEstudiante.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un estudiante con ese número.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar ingresar: " + ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            MostrarNumeroEstudiante();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Entra al formulario de cursos y horarios
                MenuCursosYHorariosEstudiantes menuCursosYHorariosEstudiantes = new MenuCursosYHorariosEstudiantes(numeroEstudianteIngresado);
                menuCursosYHorariosEstudiantes.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar acceder a los cursos y horarios: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Ir al menú de realizar pagos
                Realizar_Pagos realizar_Pagos = new Realizar_Pagos(numeroEstudianteIngresado);
                realizar_Pagos.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar realizar pagos: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //abrir menuNotificaciones con excepciones
            try
            {
                MenuNotificacion menuNotificaciones = new MenuNotificacion(numeroEstudianteIngresado);
                menuNotificaciones.Show();
                this.Hide();
                // Llamar al método para simular el clic en el icono de notificaciones
                notificacionManejada.SimularClicNotificaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar acceder a las notificaciones: " + ex.Message);
            }
        }
    }
}
