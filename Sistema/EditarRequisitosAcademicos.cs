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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

namespace Sistema
{
    public partial class EditarRequisitosAcademicos : Form
    {
        private MySqlConnection connection;
        private int cursoId; // Variable para almacenar el ID del curso

        public EditarRequisitosAcademicos(int idCurso, string nombreCurso)
        {
            InitializeComponent();
            this.cursoId = idCurso;
            MostrarNombreCurso(nombreCurso);
            CargarDatosCurso();

            // Suscribe eventos de validación a los TextBox
            textBox3.Validating += TextBox3_Validating;
            textBox5.Validating += TextBox5_Validating;
            textBox4.Validating += TextBox4_Validating;
        }


        private void MostrarNombreCurso(string nombreCurso)
        {
            label1.Text = "Curso a Editar: " + nombreCurso;
        }

        private void TextBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!EsValorValido(textBox3.Text, 0, 10))
            {
                MessageBox.Show("El valor debe estar entre 0 y 10.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void TextBox5_Validating(object sender, CancelEventArgs e)
        {
            if (!EsValorValido(textBox5.Text, 0, 10))
            {
                MessageBox.Show("El valor debe estar entre 0 y 10.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void TextBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text != "Secundario Completo" && textBox4.Text != "Posgrado Completo")
            {
                MessageBox.Show("El valor debe ser 'Secundario Completo' o 'Posgrado Completo'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        // Función auxiliar para verificar si un valor es numérico y se encuentra dentro del rango especificado.
        private bool EsValorValido(string valor, int min, int max)
        {
            if (int.TryParse(valor, out int num))
            {
                return num >= min && num <= max;
            }
            return false;
        }

        private void CargarDatosCurso()
        {
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                // Obtén los datos del curso desde la base de datos
                string selectQuery = "SELECT * FROM cursos WHERE id = @id";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@id", cursoId);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Muestra los datos del curso en los controles del formulario
                    textBox1.Text = reader["nombre"].ToString();
                    textBox2.Text = reader["id"].ToString();
                    textBox4.Text = reader["PreRequisitos"].ToString();
                    textBox5.Text = reader["CréditosAcumulados"].ToString();
                    textBox3.Text = reader["PromedioAcadémico"].ToString();
                }
                else
                {
                    MessageBox.Show("El curso seleccionado no se encuentra en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del curso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén los nuevos valores del curso desde los controles en el formulario
                string nuevaPreRequisitos = textBox4.Text; // Cambiado a textBox4
                string nuevoPromedioAcumulado = textBox5.Text; // Cambiado a textBox5
                string nuevoPromedioAcademico = textBox3.Text; // Cambiado a textBox3


                connection.Open();

                // Actualiza solo los campos PreRequisitos, CréditosAcumulados y PromedioAcadémico en la base de datos
                string updateQuery = "UPDATE cursos SET PreRequisitos = @PreRequisitos, CréditosAcumulados = @CréditosAcumulados, PromedioAcadémico = @PromedioAcadémico WHERE id = @id";

                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@PreRequisitos", nuevaPreRequisitos);
                command.Parameters.AddWithValue("@CréditosAcumulados", nuevoPromedioAcumulado);
                command.Parameters.AddWithValue("@PromedioAcadémico", nuevoPromedioAcademico);
                command.Parameters.AddWithValue("@id", cursoId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Los datos del curso se actualizaron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el curso en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del curso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //volver al menu de administrador con excepcion
            try
            {
                // Código que podría generar una excepción
                MenuAdministrador menuAdministrador = new MenuAdministrador();
                menuAdministrador.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
