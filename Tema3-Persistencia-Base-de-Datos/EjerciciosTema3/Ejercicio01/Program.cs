// Ejercicio 01 - Primera conexión y tabla
// Ejecuta este ejercicio el PRIMERO: crea la base de datos Tema03 si no existe.
using Microsoft.Data.SqlClient;

namespace Ejercicio01
{
    internal class Program
    {
        const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Tema03;Integrated Security=true;";
        const string CadenaMaster = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=true;";

        static void Main(string[] args)
        {
            try
            {
                CrearBaseDeDatos();

                using SqlConnection conexion = Conectar();
                Console.WriteLine("Conexión abierta correctamente.");

                string sql = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Personas' AND xtype='U')
                               CREATE TABLE Personas (
                                   Id INT IDENTITY(1,1) PRIMARY KEY,
                                   Nombre NVARCHAR(100),
                                   Edad INT
                               )";
                using SqlCommand comando = new SqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
                Console.WriteLine("Tabla Personas lista.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("No se pudo conectar a la base de datos Tema03", ex);
            }
        }

        // Extra: crea la base de datos Tema03 si todavía no existe
        static void CrearBaseDeDatos()
        {
            using SqlConnection conexion = new SqlConnection(CadenaMaster);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("IF DB_ID('Tema03') IS NULL CREATE DATABASE Tema03", conexion);
            comando.ExecuteNonQuery();
        }
    }
}
