using System;
using System.Windows.Forms;

namespace Sistema
{
    public partial class MenuAdministrador : Form
    {
        public MenuAdministrador()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Código que podría generar una excepción
                Login login = new Login();
                login.Show();
                this.Hide();
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
