using Biblioteca;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear un nuevo administrador
            string usuario = "admin";
            string contrasenia = "1234"; // Contraseña en texto plano
            string contraseniaEncriptada = Hash.GetHash(contrasenia); // Encriptar la contraseña

            Administrador administrador = new Administrador(usuario, contraseniaEncriptada);

            // Guardar el administrador en el archivo JSON
            List<Administrador> administradores = new List<Administrador>();
            administradores.Add(administrador);
            GuardarDatosAdministrador.WriteStreamJSON(administradores);

            // Asignar los datos del estudiante a los campos correspondientes
            textBox1.Text = administrador.Usuario;
            textBox2.Text = contrasenia;

            MessageBox.Show("Datos del Administrador cargados.");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Leer la lista de estudiantes desde el archivo JSON
            List<Estudiante> estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();

            // Verificar si hay al menos un estudiante en la lista
            if (estudiantes != null && estudiantes.Count > 0)
            {
                // Obtener el primer estudiante de la lista
                Estudiante estudiante = estudiantes[0];

                // Asignar los datos del estudiante a los campos correspondientes
                textBox1.Text = estudiante.NumeroEstudiante.ToString();
                textBox2.Text = "1234"; // Contraseña en texto plano

                MessageBox.Show("Datos del primer estudiante cargados.");
            }
            else
            {
                MessageBox.Show("No hay estudiantes en la lista.");
            }
        }

    }
}
