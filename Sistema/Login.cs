using Biblioteca;
using Microsoft.VisualBasic.ApplicationServices;
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
            // Cargar la lista de administradores desde el archivo JSON si existe
            this.admin = GuardarDatosAdministrador.ReadStreamJSON();
            this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contrasenia = textBox2.Text;

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
            // Hardcodear un administrador y escribirlos en el textbox1 y 2
            Administrador administrador = new Administrador("admin", "1234");
            textBox1.Text = administrador.Usuario;
            textBox2.Text = administrador.Contrasenia;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crear un nuevo estudiante con la información del JSON
            Estudiante estudiante = new Estudiante(
                "Massimo",
                "Bosco",
                "1234",
                "calle 314",
                "11232122",
                "Massimo@gmail.com",
                1,
                "Primer Cuatrimestre",
                "Matematica",
                "Laboratorio I",
                "Ingles",
                "Programacion I",
                "SPD",
                "",
                "pagado",
                "pagado",
                "pagado",
                "Secundario Completo"
            );

            // Asignar el número de estudiante al campo textBox1
            textBox1.Text = estudiante.NumeroEstudiante.ToString();
            // Asignar los demás datos del estudiante a los campos correspondientes
            textBox2.Text = estudiante.Contrasenia;
        }

    }
}
