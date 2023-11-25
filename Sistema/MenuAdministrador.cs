using System;
using System.Windows.Forms;

namespace Sistema
{
    public partial class MenuAdministrador : Form
    {
        private System.Windows.Forms.Timer timer; // Especificar que se utilizará Timer de System.Windows.Forms

        public MenuAdministrador()
        {
            InitializeComponent();
            InitializeTimer();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                // Código que podría generar una excepción
                Application.Exit();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Código que podría generar una excepción
                RegistrarEstudiante registrarEstudiante = new RegistrarEstudiante();
                registrarEstudiante.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Código que podría generar una excepción
                GestionarCursos cursos = new GestionarCursos();
                cursos.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ir al form de listaInformes
            try
            {
                // Código que podría generar una excepción
                ListaInformes listaInformes = new ListaInformes();
                listaInformes.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //abrir elegircursoAcademico

            try
            {
                // Código que podría generar una excepción
                ElegirCursoAcademico elegirCursoAcademico = new ElegirCursoAcademico();
                elegirCursoAcademico.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //abrir elegircursoListaEspera
            try
            {
                // Código que podría generar una excepción
                ElegirCursoListaEspera elegirCursoListaEspera = new ElegirCursoListaEspera();
                elegirCursoListaEspera.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Ocurrió una excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //ir a menuGestionarProfesor con excepciones
            try
            {
                MenuGestionarProfesor menuGestionarProfesor = new MenuGestionarProfesor();
                menuGestionarProfesor.Show();
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
