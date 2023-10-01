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

            // Llamamo a un método para cargar y mostrar los datos
            CargarYMostrarDatos();
        }

        // Método para cargar y mostrar los datos en los labels
        private void CargarYMostrarDatos()
        {
            // Leer la lista de cursos desde el archivo JSON
            var lista = GuardarDatosCursos.ReadStreamJSON(GuardarDatosCursos.archivoCursos);

            // me Aseguro de que hay al menos un curso en la lista antes de mostrar datos
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

            // Repite si hay mas cursos.
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //volver al menú administrador
            this.Hide();
            MenuAdministrador menu = new MenuAdministrador();
            menu.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // Obtengo el código ingresado por el usuario
            string codigoIngresado = textBox1.Text;

            // Intento convertir el código ingresado a un entero
            if (int.TryParse(codigoIngresado, out int codigoEntero))
            {
                // Lee la lista de cursos desde el archivo JSON
                var listaCursos = GuardarDatosCursos.ReadStreamJSON(GuardarDatosCursos.archivoCursos);

                // Variable para almacenar el curso encontrado
                Biblioteca.Cursos cursoEncontrado = null;

                // Busco el curso con el código ingresado
                foreach (var curso in listaCursos)
                {
                    if (curso.Codigo == codigoEntero)
                    {
                        cursoEncontrado = curso;
                        break; // Salir del bucle una vez que se encuentre el curso
                    }
                }

                // Verificar si se encontró el curso
                if (cursoEncontrado != null)
                {
                    // El curso existe en el JSON, puedes mostrar sus datos
                    MessageBox.Show($"Curso encontrado: {cursoEncontrado.Nombre}");

                    // Abrir el formulario EditarCurso y pasar el número y nombre del curso
                    this.Hide();
                    EditarCurso editarCurso = new EditarCurso(cursoEncontrado.Codigo, cursoEncontrado.Nombre);
                    editarCurso.Show();
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
    }
}
