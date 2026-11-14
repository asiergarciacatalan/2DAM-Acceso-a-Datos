// Ejercicio 02 - Insertar y listar
using Microsoft.Data.SqlClient;

namespace Ejercicio02
{
    internal class Program
    {
        const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Tema03;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();

            // 1) Insertar con parámetros (nunca concatenando)
            Insertar(conexion, "Ana", 25);
            Insertar(conexion, "Luis", 32);
            Insertar(conexion, "Marta", 19);
            Insertar(conexion, "Pedro", 45);
            Console.WriteLine("4 personas insertadas.");

            // 2) Listar
            Console.WriteLine("\n--- Personas ---");
            using SqlCommand comando = new SqlCommand("SELECT Id, Nombre, Edad FROM Personas", conexion);
            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                int id = lector.GetInt32(0);
                string nombre = lector.GetString(1);
                int edad = lector.GetInt32(2);
                Console.WriteLine($"{id} - {nombre} ({edad} años)");
            }
        }

        static void Insertar(SqlConnection conexion, string nombre, int edad)
        {
            using SqlCommand comando = new SqlCommand("INSERT INTO Personas (Nombre, Edad) VALUES (@nombre, @edad)", conexion);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@edad", edad);
            comando.ExecuteNonQuery();
        }
    }
}
