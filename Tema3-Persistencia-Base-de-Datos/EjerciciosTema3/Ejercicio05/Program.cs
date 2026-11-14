// Ejercicio 05 - Restricciones y SqlException
using Microsoft.Data.SqlClient;

namespace Ejercicio05
{
    internal class Program
    {
        const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Tema03;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();

            // 1) Crear la tabla y vaciarla para que el ejercicio se pueda repetir
            string sqlTabla = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuarios' AND xtype='U')
                                CREATE TABLE Usuarios (
                                    Id INT IDENTITY PRIMARY KEY,
                                    Email NVARCHAR(100) UNIQUE NOT NULL
                                );
                                DELETE FROM Usuarios;";
            using (SqlCommand comando = new SqlCommand(sqlTabla, conexion))
                comando.ExecuteNonQuery();

            // 2) Insertar un usuario
            InsertarUsuario(conexion, "ana@correo.com");

            // 3) Mismo email otra vez -> viola UNIQUE
            InsertarUsuario(conexion, "ana@correo.com");

            // 4) Email null -> viola NOT NULL
            InsertarUsuario(conexion, null);
        }

        static void InsertarUsuario(SqlConnection conexion, string email)
        {
            try
            {
                using SqlCommand comando = new SqlCommand("INSERT INTO Usuarios (Email) VALUES (@email)", conexion);
                // null de C# no vale como parámetro: hay que usar DBNull.Value
                comando.Parameters.AddWithValue("@email", email ?? (object)DBNull.Value);
                comando.ExecuteNonQuery();
                Console.WriteLine($"Usuario '{email}' insertado.");
            }
            catch (SqlException ex)
            {
                // 2627 y 2601 = clave duplicada, 515 = valor NULL no permitido
                if (ex.Number == 2627 || ex.Number == 2601)
                    Console.WriteLine($"No se puede insertar: el email '{email}' ya existe.");
                else if (ex.Number == 515)
                    Console.WriteLine("No se puede insertar: el email es obligatorio.");
                else
                    Console.WriteLine($"Error de base de datos: {ex.Message}");
            }
        }
    }
}
