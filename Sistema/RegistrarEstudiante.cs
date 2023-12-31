﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;
using MySql.Data.MySqlClient;

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
                try
                {
                    this.estudiantes = GuardarDatosEstudiantes.ReadStreamJSON();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos de estudiantes: " + ex.Message);
                }
            }
        }

        //private void btnIngresar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Verificar si algún campo está vacío
        //        if (string.IsNullOrWhiteSpace(textBox1.Text) ||
        //            string.IsNullOrWhiteSpace(textBox2.Text) ||
        //            string.IsNullOrWhiteSpace(textBox3.Text) ||
        //            string.IsNullOrWhiteSpace(textBox4.Text) ||
        //            string.IsNullOrWhiteSpace(textBox5.Text) ||
        //            string.IsNullOrWhiteSpace(textBox6.Text) ||
        //            (!checkBox1.Checked && !checkBox2.Checked))
        //        {
        //            MessageBox.Show("Faltan completar campos. Por favor, llene todos los campos.");
        //        }
        //        else
        //        {
        //            // Validar el correo electrónico
        //            string correoElectronico = textBox3.Text;
        //            if (!Validacion.ValidarCorreo(correoElectronico))
        //            {
        //                MessageBox.Show("El correo electrónico no es válido.");
        //                return; // Salir del método si la validación falla
        //            }

        //            // Validar el número de teléfono
        //            string numeroTelefono = textBox5.Text;
        //            if (!Validacion.ValidarNumeroTelefono(numeroTelefono))
        //            {
        //                MessageBox.Show("El número de teléfono no es válido.");
        //                return; // Salir del método si la validación falla
        //            }

        //            // Crear un objeto de tipo Estudiante
        //            Estudiante estudiante = new Estudiante
        //            (
        //            textBox1.Text,
        //            textBox2.Text,
        //            "contraseña_predeterminada", //contraseña que se generara
        //            textBox4.Text,
        //            textBox5.Text,
        //            textBox3.Text,
        //            0, //número de estudiante adecuado
        //            textBox6.Text,
        //            "",  // Las materias 
        //            "",
        //            "",
        //            "",
        //            "",
        //            "",
        //            "",
        //            "", // Los pagos
        //            "",
        //            "");

        //            // Llamar al método de creación de número de estudiante
        //            inicioSesion.GenerarNumeroEstudiante(estudiante);

        //            // Si CheckBox1 está marcado, generar la contraseña provisoria
        //            if (checkBox1.Checked)
        //            {
        //                inicioSesion.GenerarConstaseniaProvisoria(estudiante);
        //            }

        //            if (checkBox2.Checked)
        //            {
        //                //poner contrasenia en blanco
        //                estudiante.Contrasenia = "";
        //            }

        //            // Verificar si el estudiante ya existe en la lista
        //            if (estudiantes.Exists(est => est.NumeroEstudiante == estudiante.NumeroEstudiante))
        //            {
        //                MessageBox.Show("El estudiante ya está registrado.");
        //            }
        //            else
        //            {
        //                // Agregar el estudiante a la lista en memoria
        //                estudiantes.Add(estudiante);

        //                // Guardar la lista completa de estudiantes (incluyendo el nuevo estudiante) en el archivo JSON
        //                GuardarDatosEstudiantes.WriteStreamJSON(estudiantes);

        //                MessageBox.Show("Estudiante Registrado.");
        //                MessageBox.Show("Se envió un Correo al Estudiante.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrió un error al registrar al estudiante: " + ex.Message);
        //    }
        //}

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
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
                    Estudiante estudiante = new Estudiante
                    (
                    textBox1.Text,
                    textBox2.Text,
                    "contraseña_predeterminada", //contraseña que se generará
                    textBox4.Text,
                    textBox5.Text,
                    textBox3.Text,
                    0, //número de estudiante adecuado
                    textBox6.Text,
                    "",  // Las materias 
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "", // Los pagos
                    "",
                    "");

                    // Llamar al método de creación de número de estudiante
                    inicioSesion.GenerarNumeroEstudiante(estudiante);

                    // Si CheckBox1 está marcado, generar la contraseña provisoria
                    if (checkBox1.Checked)
                    {
                        inicioSesion.GenerarConstaseniaProvisoria(estudiante);
                    }

                    if (checkBox2.Checked)
                    {
                        // Poner contraseña en blanco
                        estudiante.Contrasenia = "";
                    }

                    // Verificar si el estudiante ya existe en la lista (puedes omitir esto si no estás utilizando una lista en memoria)
                    if (estudiantes.Exists(est => est.NumeroEstudiante == estudiante.NumeroEstudiante))
                    {
                        MessageBox.Show("El estudiante ya está registrado.");
                    }
                    else
                    {
                        string connectionString = "server=localhost;port=3306;database=datos_sysacad;uid=root;pwd=;";
                        // Agregar el estudiante a la base de datos MySQL
                        using (MySqlConnection connection = new MySqlConnection (connectionString))
                        {
                            connection.Open();

                            string insertQuery = "INSERT INTO estudiantes (Nombre, Apellido, CorreoElectronico, Direccion, Telefono, Legajo, Cuatrimestre, Contrasenia) " +
                                                "VALUES (@nombre, @apellido, @correo, @direccion, @telefono, @legajo, @cuatrimestre, @contrasenia)";

                            MySqlCommand command = new MySqlCommand(insertQuery, connection);
                            command.Parameters.AddWithValue("@nombre", estudiante.NombreCompleto);
                            command.Parameters.AddWithValue("@apellido", estudiante.ApellidoCompleto);
                            command.Parameters.AddWithValue("@correo", estudiante.CorreoElectronico);
                            command.Parameters.AddWithValue("@direccion", estudiante.Direccion);
                            command.Parameters.AddWithValue("@telefono", estudiante.NumeroTelefono);
                            command.Parameters.AddWithValue("@legajo", estudiante.NumeroEstudiante);
                            command.Parameters.AddWithValue("@cuatrimestre", estudiante.CuatrimestreEstudiante);
                            command.Parameters.AddWithValue("@contrasenia", estudiante.Contrasenia);

                            int rowsAffected = command.ExecuteNonQuery();


                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Estudiante registrado en la base de datos.");
                                MessageBox.Show("Se envió un correo al estudiante.");
                            }
                            else
                            {
                                MessageBox.Show("Error al registrar al estudiante en la base de datos.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar al estudiante: " + ex.Message);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            // Opciones para los datos
            string[] nombres = { "Juan", "Maria", "Carlos", "Laura", "Ana" };
            string[] apellidos = { "Perez", "Gomez", "Rodriguez", "Martinez", "Lopez" };
            string[] Direccion = { "Calle 312", "Calle 211", "Calle 987", "Calle 11", "Calle 242", "Calle 23211", "Calle 23111" };
            string[] correos = { "juan@example.com", "maria@example.com", "carlos@example.com", "laura@example.com", "ana@example.com" };
            string[] telefonos = { "12345678", "98765432", "55555555", "99999999", "77777777" };
            string[] Cuatrimestre = { "Primer Cuatrimestre", "Segundo Cuatrimestre", "Tercer Cuatrimestre", "Cuarto Cuatrimestre" };

            // Generar datos aleatorios
            string nombreAleatorio = nombres[random.Next(nombres.Length)];
            string apellidoAleatorio = apellidos[random.Next(apellidos.Length)];
            string direccionAleatorio = Direccion[random.Next(Direccion.Length)];
            string correoAleatorio = correos[random.Next(correos.Length)];
            string telefonoAleatorio = telefonos[random.Next(telefonos.Length)];
            string cuatrimestreAleatorio = Cuatrimestre[random.Next(Cuatrimestre.Length)];

            // Llenar los Labels con datos aleatorios
            textBox1.Text = nombreAleatorio;
            textBox2.Text = apellidoAleatorio;
            textBox4.Text = direccionAleatorio;
            textBox3.Text = correoAleatorio;
            textBox5.Text = telefonoAleatorio;
            textBox6.Text = cuatrimestreAleatorio;
        }
    }
}
