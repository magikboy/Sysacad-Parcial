using Biblioteca;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema
{
    public partial class DatosEstudiante : Form
    {
        private List<Estudiante> estudiantes;
        private int numeroEstudianteIngresado;

        public DatosEstudiante(int numeroEstudiante)
        {
            InitializeComponent();
            //buscar el estudiante por el numero de estudiante por la base de datos
            this.numeroEstudianteIngresado = numeroEstudiante;
            MostrarNumeroEstudiante();

            try
            {
                // Establece la cadena de conexión a la base de datos MySQL
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener los datos del estudiante
                    string query = "SELECT * FROM estudiantes WHERE Legajo = @Legajo";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Legajo", numeroEstudianteIngresado);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Mostrar la información del estudiante en los Labels
                            label11.Text = reader["Nombre"].ToString();
                            label12.Text = reader["Apellido"].ToString();
                            label13.Text = reader["Direccion"].ToString();
                            label14.Text = reader["CorreoElectronico"].ToString();
                            label15.Text = "+54-11-" + reader["Telefono"].ToString();
                            label16.Text = reader["Cuatrimestre"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un estudiante con ese número.");
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del estudiante desde la base de datos: " + ex.Message);
                this.Close();
            }
        }

        private void MostrarNumeroEstudiante()
        {
            label17.Text = numeroEstudianteIngresado.ToString();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    // Obtengo la contraseña actual ingresada por el estudiante en texto plano
        //    string actualContraseña = textBox6.Text;
        //    string nuevaContraseña = textBox7.Text;

        //    try
        //    {
        //        // Busco el estudiante por su número de estudiante
        //        Estudiante estudianteSeleccionado = estudiantes.Find(est => est.NumeroEstudiante == numeroEstudianteIngresado);

        //        if (estudianteSeleccionado != null)
        //        {
        //            // Verifica si la contraseña actual coincide con la contraseña encriptada almacenada
        //            if (Hash.ValidatePassword(actualContraseña, estudianteSeleccionado.Contrasenia))
        //            {
        //                // Cambia la contraseña del estudiante
        //                estudianteSeleccionado.CambiarContraseña(nuevaContraseña);

        //                // Actualiza la contraseña en el archivo JSON
        //                GuardarDatosEstudiantes.ActualizarContraseñaEstudiante(estudianteSeleccionado);

        //                MessageBox.Show("Contraseña cambiada exitosamente.");
        //            }
        //            else
        //            {
        //                MessageBox.Show("La contraseña actual es incorrecta. Por favor, inténtelo de nuevo.");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("No se encontró un estudiante con ese número.");
        //        }

        //        // Limpia los TextBox después de cambiar la contraseña
        //        textBox6.Clear();
        //        textBox7.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cambiar la contraseña: " + ex.Message);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtengo la contraseña actual ingresada por el estudiante en texto plano
            string actualContraseña = textBox6.Text;
            string nuevaContraseña = textBox7.Text;

            try
            {
                // Establece la cadena de conexión a la base de datos MySQL
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para actualizar la contraseña del estudiante en la base de datos
                    string updateQuery = "UPDATE estudiantes SET Contrasenia = @NuevaContrasenia WHERE Legajo = @Legajo";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@NuevaContrasenia", Hash.GetHash(nuevaContraseña)); // Hashear la nueva contraseña
                    updateCmd.Parameters.AddWithValue("@Legajo", numeroEstudianteIngresado);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Contraseña actualizada con éxito en la base de datos
                        MessageBox.Show("Contraseña cambiada exitosamente en la base de datos.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un estudiante con ese número.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar la contraseña en la base de datos: " + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menú del estudiante
            this.Hide();
            MenuEstudiante menuEstudiante = new MenuEstudiante(numeroEstudianteIngresado);
            menuEstudiante.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //salir
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Muestro la contraseña sin taparla
                textBox6.UseSystemPasswordChar = true;
                textBox7.UseSystemPasswordChar = true;
            }
            else
            {
                // Muestro la contraseña tapada con asteriscos
                textBox6.UseSystemPasswordChar = false;
                textBox7.UseSystemPasswordChar = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string HistorialAcademico = textBox1.Text;

            try
            {
                // Establece la cadena de conexión a la base de datos MySQL
                string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para actualizar el historial académico del estudiante
                    string query = "UPDATE estudiantes SET HistorialAcademico = @HistorialAcademico WHERE Legajo = @Legajo";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@HistorialAcademico", HistorialAcademico);
                    cmd.Parameters.AddWithValue("@Legajo", numeroEstudianteIngresado);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Actualización exitosa
                        MessageBox.Show("Historial académico actualizado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un estudiante con ese número.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el historial académico en la base de datos: " + ex.Message);
            }
        }
    }
}
