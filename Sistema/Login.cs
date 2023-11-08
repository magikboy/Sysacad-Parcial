using Biblioteca;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sistema
{
    public partial class Login : Form
    {
        List<Administrador> admin = new List<Administrador>();
        List<Estudiante> estudiantes = new List<Estudiante>();

        public Login()
        {
            InitializeComponent();
            GuardarDatosAdministrador.CrearCarpeta();
            // Establecer la cadena de conexión a la base de datos MySQL
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

            // Crear una conexión a la base de datos
            MySqlConnection connection = new MySqlConnection(connectionString);

            //mostrar un mensaje si la conexion es exitosa
            try
            {
                // Abrir la conexión a la base de datos
                connection.Open();
                MessageBox.Show("Conexion exitosa");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                connection.Close();
            }

            try
            {
                // Verificar si el archivo de administradores ya existe
                if (!GuardarDatosAdministrador.FileExists())
                {
                    // Si no existe, crea un administrador predeterminado
                    List<Administrador> administradores = new List<Administrador>();
                    Administrador administrador = new Administrador("admin", "1234");
                    administradores.Add(administrador);
                    GuardarDatosAdministrador.WriteStreamJSON(administradores);
                }

                // Cargar la lista de administradores desde el archivo JSON si existe
                this.admin = GuardarDatosAdministrador.ReadStreamJSON() ?? new List<Administrador>();
                this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON() ?? new List<Estudiante>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }


        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contrasenia = textBox2.Text;

            try
            {
                // Verificar si el usuario es un administrador
                if (AutenticarCredenciales.AutenticarComoAdministrador(usuario, contrasenia))
                {
                    MessageBox.Show("Acceso como administrador");
                    // Abrir el formulario de administrador
                    MenuAdministrador menuAdministrador = new MenuAdministrador();
                    menuAdministrador.Show();
                    this.Hide();
                }
                else
                {
                    // Verificar si el usuario es un estudiante
                    Estudiante estudianteEncontrado = AutenticarCredenciales.AutenticarComoEstudiante(usuario, contrasenia);
                    if (estudianteEncontrado != null)
                    {
                        MessageBox.Show("Acceso como estudiante");
                        // Abrir el formulario de estudiante y pasar el número de estudiante
                        MenuEstudiante menuEstudiante = new MenuEstudiante(estudianteEncontrado.NumeroEstudiante);
                        menuEstudiante.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autenticar: " + ex.Message);
            }
        }


        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            //finalizar programa
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //// Crear un nuevo administrador
        //    //string usuario = "admin";
        //    //string contrasenia = "1234"; // Contraseña en texto plano
        //    //string contraseniaEncriptada = Hash.GetHash(contrasenia); // Encriptar la contraseña

        //    //Administrador administrador = new Administrador(usuario, contraseniaEncriptada);

        //    //// Guardar el administrador en el archivo JSON
        //    //List<Administrador> administradores = new List<Administrador>();
        //    //administradores.Add(administrador);
        //    //GuardarDatosAdministrador.WriteStreamJSON(administradores);

        //    //// Asignar los datos del estudiante a los campos correspondientes
        //    //textBox1.Text = administrador.Usuario;
        //    //textBox2.Text = contrasenia;

        //    //MessageBox.Show("Datos del Administrador cargados.");
        //    //string conexion = "server=localhost; database=bd_sistema; Uid=root; pwd=;";
        //    //MySqlConnection cnn = new MySqlConnection(conexion);
        //    //MySqlCommand cmd = new MySqlCommand("SELECT * FROM administrador WHERE usuario = @usuario AND contrasenia = @contrasenia", cnn);
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            // Establecer la cadena de conexión a la base de datos MySQL
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

            // Crear una conexión a la base de datos
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                // Abrir la conexión a la base de datos
                connection.Open();

                // Definir la consulta SQL para obtener los datos del administrador
                string sqlQuery = "SELECT * FROM administrador WHERE usuario = @usuario";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

                // Pasar el valor del usuario como parámetro
                cmd.Parameters.AddWithValue("@usuario", "admin"); // Reemplaza "admin" con el usuario que estás buscando

                // Ejecutar la consulta
                MySqlDataReader reader = cmd.ExecuteReader();

                // Verificar si se encontraron resultados
                if (reader.Read())
                {
                    // Obtener los datos del administrador desde la base de datos
                    string usuario = reader["usuario"].ToString();
                    string contraseniaHasheada = reader["contrasenia"].ToString();

                    // Deshashear la contraseña antes de mostrarla en el TextBox
                    string contrasenia = DeshashearContraseña(contraseniaHasheada);

                    // Asignar los datos del administrador a los campos correspondientes
                    textBox1.Text = usuario;
                    textBox2.Text = contrasenia;

                    MessageBox.Show("Datos del administrador cargados desde la base de datos.");
                }
                else
                {
                    MessageBox.Show("No se encontró un administrador con ese usuario.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar los datos del administrador desde la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                connection.Close();
            }
        }


        private string DeshashearContraseña(string contraseñaHasheada)
        {
            // Aquí puedes usar la misma función Hash.GetHash para deshashear la contraseña
            return "1234"; // La contraseña en texto plano o la que corresponda
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Establecer la cadena de conexión a la base de datos MySQL
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

            // Crear una conexión a la base de datos
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                // Abrir la conexión a la base de datos
                connection.Open();

                // Definir la consulta SQL para obtener los datos del estudiante
                string sqlQuery = "SELECT * FROM estudiantes WHERE Legajo = @Legajo";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);

                // Pasar el valor del número de estudiante como parámetro
                cmd.Parameters.AddWithValue("@Legajo", 1); // Reemplaza 12345 con el número de estudiante que estás buscando

                // Ejecutar la consulta
                MySqlDataReader reader = cmd.ExecuteReader();

                // Verificar si se encontraron resultados
                if (reader.Read())
                {
                    // Obtener los datos del estudiante desde la base de datos
                    int numeroEstudiante = Convert.ToInt32(reader["Legajo"]);
                    string nombre = reader["nombre"].ToString();
                    // Otros campos del estudiante...

                    // Asignar los datos del estudiante a los campos correspondientes
                    textBox1.Text = numeroEstudiante.ToString();
                    textBox2.Text = "1234"; // Contraseña en texto plano o la que corresponda

                    MessageBox.Show("Datos del estudiante cargados desde la base de datos.");
                }
                else
                {
                    MessageBox.Show("No se encontró un estudiante con ese número de estudiante.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar los datos del estudiante desde la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                connection.Close();
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    // Leer la lista de estudiantes desde el archivo JSON
        //    List<Estudiante> estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();

        //    // Verificar si hay al menos un estudiante en la lista
        //    if (estudiantes != null && estudiantes.Count > 0)
        //    {
        //        // Obtener el primer estudiante de la lista
        //        Estudiante estudiante = estudiantes[0];

        //        // Asignar los datos del estudiante a los campos correspondientes
        //        textBox1.Text = estudiante.NumeroEstudiante.ToString();
        //        textBox2.Text = "1234"; // Contraseña en texto plano

        //        MessageBox.Show("Datos del primer estudiante cargados.");
        //    }
        //    else
        //    {
        //        MessageBox.Show("No hay estudiantes en la lista.");
        //    }
        //}

    }
}
