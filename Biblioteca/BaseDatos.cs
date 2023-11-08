using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Biblioteca
{
    public class BaseDatos
    {
        private string connectionString;
        private MySqlConnection connection;

        public BaseDatos(string server, string database, string uid, string password)
        {
            connectionString = $"server={server};port=3306;database={database};Uid={uid};pwd={password}";
            connection = new MySqlConnection(connectionString);
        }

        public bool ConectarBase()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar con la base de datos: " + ex.Message);
                return false;
            }
        }

        public void DesconectarBase()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public bool Insertar(string query)
        {
            if (ConectarBase())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error al insertar datos: " + ex.Message);
                }
                finally
                {
                    DesconectarBase();
                }
            }
            return false;
        }

        public bool Actualizar(string query)
        {
            if (ConectarBase())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error al actualizar datos: " + ex.Message);
                }
                finally
                {
                    DesconectarBase();
                }
            }
            return false;
        }

        public bool Eliminar(string query)
        {
            if (ConectarBase())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error al eliminar datos: " + ex.Message);
                }
                finally
                {
                    DesconectarBase();
                }
            }
            return false;
        }
    }
}
