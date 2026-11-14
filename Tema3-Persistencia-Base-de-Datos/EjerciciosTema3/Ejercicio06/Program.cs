// Ejercicio 06 - Borrado lógico
using Microsoft.Data.SqlClient;

namespace Ejercicio06
{
    internal class Program
    {
        const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Tema03;Integrated Security=true;";

        static void Main(string[] args)
        {
            // 1) Añadir la columna Activo (solo si todavía no existe)
            Ejecutar("IF COL_LENGTH('Personas', 'Activo') IS NULL ALTER TABLE Personas ADD Activo BIT NOT NULL DEFAULT 1");

            // Persona de prueba
            int id = InsertarPrueba("Borrado Logico", 40);
            Console.WriteLine($"Insertada persona con Id {id}");
            Console.WriteLine($"¿Aparece en activas? {ObtenerActivas().Contains(id)}");

            // 2) Borrado lógico
            EliminarLogico(id);
            Console.WriteLine($"\nBorrado lógico del Id {id} hecho.");

            // 4) Sigue en la tabla, pero ya no sale en las activas
            Console.WriteLine($"¿Sigue en la tabla? {ExisteEnTabla(id)}");
            Console.WriteLine($"¿Aparece en activas? {ObtenerActivas().Contains(id)}");
        }

        static bool EliminarLogico(int id)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("UPDATE Personas SET Activo = 0 WHERE Id = @id", conexion);
            comando.Parameters.AddWithValue("@id", id);
            return comando.ExecuteNonQuery() > 0;
        }

        // 3) Devuelve los Id de las personas activas
        static List<int> ObtenerActivas()
        {
            List<int> ids = new List<int>();
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("SELECT Id FROM Personas WHERE Activo = 1", conexion);
            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
                ids.Add(lector.GetInt32(0));
            return ids;
        }

        static bool ExisteEnTabla(int id)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("SELECT COUNT(*) FROM Personas WHERE Id = @id", conexion);
            comando.Parameters.AddWithValue("@id", id);
            return (int)comando.ExecuteScalar() > 0;
        }

        static int InsertarPrueba(string nombre, int edad)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            string sql = "INSERT INTO Personas (Nombre, Edad) VALUES (@nombre, @edad); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            using SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@edad", edad);
            return (int)comando.ExecuteScalar();
        }

        static void Ejecutar(string sql)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
        }
    }
}
