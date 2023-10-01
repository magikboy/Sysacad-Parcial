using Biblioteca;
using Microsoft.VisualBasic.ApplicationServices;
using System.Threading.Tasks;

namespace Sistema
{
    public partial class Login : Form
    {
        List<Administrador> admin = new List<Administrador>();
        List<Estudiante> estudiantes = new List<Estudiante>();
        public Login()
        {
            InitializeComponent();
        }
        public void CargarEstudiantesDesdeJSON()
        {
            // Cargar la lista de estudiantes desde el archivo JSON si existe
            estudiantes = GuardarDatosEstudiantes.ReadStreamJSON("estudiantes.json");
            admin = GuardarDatosAdministrador.ReadStreamJSON("administrador.json");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contrasenia = textBox2.Text;

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


        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
