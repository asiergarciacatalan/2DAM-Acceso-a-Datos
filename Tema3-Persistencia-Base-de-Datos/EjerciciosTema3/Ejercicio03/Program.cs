// Ejercicio 03 - Actualizar y eliminar
using Microsoft.Data.SqlClient;

namespace Ejercicio03
{
    internal class Program
    {
        const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Tema03;Integrated Security=true;";

        static void Main(string[] args)
        {
            // Insertamos una persona de prueba y nos guardamos su Id
            int id = InsertarPrueba("Persona de prueba", 30);
            Console.WriteLine($"Insertada persona con Id {id}");

            Console.WriteLine($"Actualizar edad del Id {id}: {ActualizarEdad(id, 31)}");
            Console.WriteLine($"Actualizar edad del Id 99999: {ActualizarEdad(99999, 50)}");   // no existe

            Console.WriteLine($"Eliminar Id {id}: {Eliminar(id)}");
            Console.WriteLine($"Eliminar Id {id} otra vez: {Eliminar(id)}");   // ya no existe
        }

        static bool ActualizarEdad(int id, int nuevaEdad)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("UPDATE Personas SET Edad = @edad WHERE Id = @id", conexion);
            comando.Parameters.AddWithValue("@edad", nuevaEdad);
            comando.Parameters.AddWithValue("@id", id);
            int filas = comando.ExecuteNonQuery();
            return filas > 0;   // true si ha cambiado alguna fila
        }

        static bool Eliminar(int id)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("DELETE FROM Personas WHERE Id = @id", conexion);
            comando.Parameters.AddWithValue("@id", id);
            return comando.ExecuteNonQuery() > 0;
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
    }
}
