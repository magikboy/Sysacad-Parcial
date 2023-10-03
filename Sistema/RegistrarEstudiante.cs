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
        private InicioSesion inicioSesion = new InicioSesion();

        public RegistrarEstudiante()
        {
            InitializeComponent();

            // Verificar si el archivo JSON existe antes de cargarlo
            if (File.Exists("estudiantes.json"))
            {
                this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
            }
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
                inicioSesion.GenerarNumeroEstudiante(estudiante);

                // Si CheckBox1 está marcado, generar la contraseña provisoria
                if (checkBox1.Checked)
                {
                    inicioSesion.GenerarConstaseniaProvisoria(estudiante);
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
                    GuardarDatosEstudiantes.WriteStreamJSON("estudiantes.json", estudiantes);

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

    }
}
