using Biblioteca;
using Microsoft.VisualBasic.ApplicationServices;
using System.Threading.Tasks;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Administrador administrador = new Administrador("admin", "1234"); // Credenciales de administrador
        List<Estudiante> estudiantes = new List<Estudiante>();
        public void CargarEstudiantesDesdeJSON()
        {
            // Cargar la lista de estudiantes desde el archivo JSON si existe
            estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Cargar la lista de estudiantes desde el archivo JSON
            CargarEstudiantesDesdeJSON();

            // Verificar si las credenciales ingresadas son del administrador
            if (textBox1.Text == administrador.Usuario && textBox2.Text == administrador.Contraseña)
            {
                MessageBox.Show("Acceso como administrador");
                this.Hide();
            }
            else
            {
                // Intentar convertir el valor de textBox1.Text a un entero
                if (int.TryParse(textBox1.Text, out int numeroEstudiante))
                {
                    // Verificar si las credenciales coinciden con algún estudiante
                    Estudiante estudianteEncontrado = estudiantes.FirstOrDefault(est => est.NumeroEstudiante == numeroEstudiante && est.Contrasenia == textBox2.Text);

                    if (estudianteEncontrado != null)
                    {
                        MessageBox.Show("Acceso como estudiante");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
                else
                {
                    MessageBox.Show("Número de estudiante no válido.");
                }
            }
        }

    }
}