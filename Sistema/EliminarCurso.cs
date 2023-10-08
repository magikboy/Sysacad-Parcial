using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sistema
{
    public partial class EliminarCurso : Form
    {
        List<Biblioteca.Cursos> cursos = new List<Biblioteca.Cursos>();
        public EliminarCurso()
        {
            InitializeComponent();

            // Llamamos a un método para cargar y mostrar los datos
            CargarYMostrarDatos();
            this.cursos = GuardarDatosCursos.ReadStreamJSON();
        }

        // Método para cargar y mostrar los datos en los labels
        private void CargarYMostrarDatos()
        {
            try
            {
                // Leer la lista de cursos desde el archivo JSON
                var lista = GuardarDatosCursos.ReadStreamJSON();

                // Mostrar cursos en los labels (tiene un máximo de 7 cursos)
                for (int i = 0; i < Math.Min(lista.Count, 7); i++)
                {
                    var labelNombre = Controls.Find($"label{i + 3}", true)[0] as Label; // Encuentra el label por nombre
                    var labelCodigo = Controls.Find($"label{i + 10}", true)[0] as Label;

                    labelNombre.Text = lista[i].Nombre.ToString();
                    labelCodigo.Text = lista[i].Codigo.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Volver al menú del administrador
            this.Hide();
            MenuAdministrador menu = new MenuAdministrador();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtengo el código ingresado por el usuario
                string codigoIngresado = textBox1.Text;

                // Intento convertir el código ingresado a un entero
                if (int.TryParse(codigoIngresado, out int codigoEntero))
                {
                    // Leer la lista de cursos desde el archivo JSON
                    var listaCursos = GuardarDatosCursos.ReadStreamJSON();

                    // Buscar el curso con el código ingresado
                    var cursoEncontrado = listaCursos.Find(curso => curso.Codigo == codigoEntero);

                    // Verificar si se encontró el curso
                    if (cursoEncontrado != null)
                    {
                        // Mostrar un cuadro de diálogo de confirmación
                        DialogResult result = MessageBox.Show($"¿Está seguro de que desea eliminar el curso {cursoEncontrado.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // El usuario confirmó la eliminación, puedes proceder a eliminar el curso
                            listaCursos.Remove(cursoEncontrado);
                            GuardarDatosCursos.EliminarCurso(cursoEncontrado.Codigo); // Elimina el curso del archivo JSON
                            MessageBox.Show($"Curso {cursoEncontrado.Nombre} eliminado correctamente.");
                            CargarYMostrarDatos(); // Actualizar la lista de cursos mostrada
                        }
                        else
                        {
                            // El usuario canceló la eliminación
                            MessageBox.Show("Eliminación cancelada.");
                        }
                    }
                    else
                    {
                        // El curso no fue encontrado
                        MessageBox.Show("El código de curso ingresado no existe.");
                    }
                }
                else
                {
                    // El código ingresado no es un número entero válido
                    MessageBox.Show("Por favor, ingrese un código de curso válido (número entero).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
