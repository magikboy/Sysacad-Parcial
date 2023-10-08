using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class ElegirCurso : Form
    {

        List<Biblioteca.Cursos> cursos = new List<Biblioteca.Cursos>();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //hacer que lea el codigo del curso
            string Codigo = textBox1.Text;
        }

        public ElegirCurso()
        {
            InitializeComponent();
            // Llamo a un método para cargar y mostrar los datos
            CargarYMostrarDatos();
        }

        // Método para cargar y mostrar los datos en los labels
        private void CargarYMostrarDatos()
        {
            try
            {
                // Lee la lista de cursos desde el archivo JSON
                var lista = GuardarDatosCursos.ReadStreamJSON();

                // Verificar si hay cursos en la lista antes de mostrar datos
                if (lista.Count > 0)
                {
                    label3.Text = lista[0].Nombre.ToString();
                    label10.Text = lista[0].Codigo.ToString();
                }

                if (lista.Count > 1)
                {
                    label4.Text = lista[1].Nombre.ToString();
                    label11.Text = lista[1].Codigo.ToString();
                }

                if (lista.Count > 2)
                {
                    label5.Text = lista[2].Nombre.ToString();
                    label12.Text = lista[2].Codigo.ToString();
                }

                if (lista.Count > 3)
                {
                    label6.Text = lista[3].Nombre.ToString();
                    label13.Text = lista[3].Codigo.ToString();
                }

                if (lista.Count > 4)
                {
                    label7.Text = lista[4].Nombre.ToString();
                    label14.Text = lista[4].Codigo.ToString();
                }

                if (lista.Count > 5)
                {
                    label8.Text = lista[5].Nombre.ToString();
                    label15.Text = lista[5].Codigo.ToString();
                }

                if (lista.Count > 6)
                {
                    label9.Text = lista[6].Nombre.ToString();
                    label16.Text = lista[6].Codigo.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar y mostrar datos: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Volver al menú administrador
                this.Hide();
                MenuAdministrador menu = new MenuAdministrador();
                menu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al volver al menú administrador: {ex.Message}");
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                string codigoIngresado = textBox1.Text;

                if (int.TryParse(codigoIngresado, out int codigoEntero))
                {
                    var listaCursos = GuardarDatosCursos.ReadStreamJSON();

                    Biblioteca.Cursos cursoEncontrado = listaCursos.FirstOrDefault(curso => curso.Codigo == codigoEntero);

                    if (cursoEncontrado != null)
                    {
                        MessageBox.Show($"Curso encontrado: {cursoEncontrado.Nombre}");
                        this.Hide();
                        EditarCurso editarCurso = new EditarCurso(cursoEncontrado.Codigo, cursoEncontrado.Nombre);
                        editarCurso.Show();
                    }
                    else
                    {
                        MessageBox.Show("El código de curso ingresado no existe.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un código de curso válido (número entero).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar y mostrar curso: {ex.Message}");
            }
        }
    }
}
