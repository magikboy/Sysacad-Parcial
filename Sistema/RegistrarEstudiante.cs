using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace Sistema
{
    public partial class RegistrarEstudiante : Form
    {
        List<Estudiante> estudiantes = new List<Estudiante>();

        public RegistrarEstudiante()
        {
            InitializeComponent();
            // Verificar si el archivo JSON existe antes de cargarlo
            if (File.Exists("estudiantes.json"))
            {
                estudiantes = GuardarDatos.ReadStreamJSON("estudiantes.json");

            }
        }

        public void GenerarContraseniaProvisoria(Estudiante estudiante)
        {
            // Generar contraseña provisoria para el estudiante una vez registrado
            string contrasenia = "1234";
            estudiante.Contrasenia = contrasenia;
        }

        public void GenerarNumeroEstudiante(Estudiante estudiante)
        {
            // Crear número aleatorio para el estudiante
            Random random = new Random();
            int numeroEstudiante = random.Next(1, 9999);
            estudiante.NumeroEstudiante = numeroEstudiante;
            // Validar que el número no esté repetido y crear uno nuevo si es necesario
            while (existeNumeroIdentificacionEnLaBaseDeDatos(numeroEstudiante.ToString()))
            {
                numeroEstudiante = random.Next(1, 9999);
                estudiante.NumeroEstudiante = numeroEstudiante;
            }
        }

        public bool existeNumeroIdentificacionEnLaBaseDeDatos(string numeroIdentificacion)
        {
            foreach (Estudiante estudiante in estudiantes)
            {
                if (estudiante.NumeroEstudiante.ToString() == numeroIdentificacion)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Verificar si algún campo está vacío
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                (!checkBox1.Checked && !checkBox2.Checked))
            {
                MessageBox.Show("Faltan completar campos. Por favor, llene todos los campos.");
            }
            else
            {
                // Validar el correo electrónico
                string correoElectronico = textBox3.Text;
                if (!Validacion.ValidarCorreo(correoElectronico))
                {
                    MessageBox.Show("El correo electrónico no es válido.");
                    return; // Salir del método si la validación falla
                }

                // Validar el número de teléfono
                string numeroTelefono = textBox5.Text;
                if (!Validacion.ValidarNumeroTelefono(numeroTelefono))
                {
                    MessageBox.Show("El número de teléfono no es válido.");
                    return; // Salir del método si la validación falla
                }

                // Todos los campos y validaciones están completos, puedes continuar con el proceso de registro.

                // Crear un objeto de tipo Estudiante
                Estudiante estudiante = new Estudiante();

                // Asignar los valores de los campos a las propiedades del objeto
                estudiante.NombreCompleto = textBox1.Text;
                estudiante.ApellidoCompleto = textBox2.Text;
                estudiante.CorreoElectronico = correoElectronico; // Usar el valor validado
                estudiante.Direccion = textBox4.Text;
                estudiante.NumeroTelefono = numeroTelefono; // Usar el valor validado
                estudiante.CuatrimestreEstudiante = textBox6.Text;

                // Llamar al método de creación de número de estudiante
                GenerarNumeroEstudiante(estudiante);

                // Si CheckBox1 está marcado, generar la contraseña provisoria
                if (checkBox1.Checked)
                {
                    GenerarContraseniaProvisoria(estudiante);
                }

                // Verificar si el estudiante ya existe en la lista
                if (estudiantes.Exists(est => est.NumeroEstudiante == estudiante.NumeroEstudiante))
                {
                    MessageBox.Show("El estudiante ya está registrado.");
                }
                else
                {
                    // Agregar el estudiante a la lista
                    estudiantes.Add(estudiante);

                    // Guardar la lista de estudiantes actualizada en el archivo JSON
                    GuardarDatos.WriteStreamJSON("estudiantes.json", estudiantes);

                    MessageBox.Show("Estudiante Registrado.");
                    MessageBox.Show("Se envio un Correo al Estudiante.");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //volver al menu administrador
            MenuAdministrador menuAdministrador = new MenuAdministrador();
            menuAdministrador.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //para que ingrese el nombre del estudiante

            string nombreCompleto = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //para que ingrese el Apellido de usuario

            string apellido = textBox2.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // para que ingrese la direccion de usuario

            string direccion = textBox4.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //para que ingrese el correo electronico

            string correoElectronico = textBox3.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //para que ingrese el Telefono

            string telefono = textBox5.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarEstudiante_Load(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string NumeroCuatrimestre = textBox6.Text;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
