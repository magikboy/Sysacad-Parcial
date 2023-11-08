using System;
using Biblioteca;
using MySql.Data.MySqlClient;

namespace Sistema
{
    public class AutenticarCredenciales
    {
        public static bool AutenticarComoAdministrador(string usuario, string contrasenia)
        {
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Usuario, Contrasenia FROM administrador WHERE Usuario = @admin";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@admin", usuario);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPasswordHash = reader["Contrasenia"].ToString();

                            if (Hash.ValidatePassword(contrasenia, storedPasswordHash))
                            {
                                return true; // Contraseña válida, usuario autenticado
                            }
                        }
                    }
                }
            }

            return false; // Usuario o contraseña incorrectos
        }

        public static Estudiante AutenticarComoEstudiante(string usuario, string contrasenia)
        {
            string connectionString = "server=localhost;port=3306;database=datos_sysacad;Uid=root;pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                if (int.TryParse(usuario, out int numeroEstudiante))
                {
                    string query = "SELECT Legajo, Contrasenia FROM estudiantes WHERE Legajo = @Legajo";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Legajo", numeroEstudiante);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPasswordHash = reader["Contrasenia"].ToString();

                                if (Hash.ValidatePassword(contrasenia, storedPasswordHash))
                                {
                                    // Puedes cargar los datos del estudiante desde la base de datos aquí
                                    Estudiante estudiante = new Estudiante();
                                    estudiante.NumeroEstudiante = numeroEstudiante;
                                    // Cargar otros datos del estudiante desde la base de datos

                                    return estudiante; // Contraseña válida, retorna el estudiante encontrado
                                }
                            }
                        }
                    }
                }
            }

            return null; // Usuario o contraseña incorrectos
        }
    }
}
