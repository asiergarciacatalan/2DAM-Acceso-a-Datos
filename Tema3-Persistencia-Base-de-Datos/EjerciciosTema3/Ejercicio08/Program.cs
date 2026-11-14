// Ejercicio 08 - Inyección SQL: vulnerable frente a seguro
using Microsoft.Data.SqlClient;

namespace Ejercicio08
{
    internal class Program
    {
        const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Tema03;Integrated Security=true;";

        static void Main(string[] args)
        {
            Console.WriteLine("--- Nombre normal: 'Ana' ---");
            Console.WriteLine($"Vulnerable: {BuscarVulnerable("Ana")} resultados");
            Console.WriteLine($"Seguro:     {BuscarSeguro("Ana")} resultados");

            string malicioso = "' OR '1'='1";
            Console.WriteLine($"\n--- Entrada maliciosa: {malicioso} ---");
            // Vulnerable: el SQL queda  WHERE Nombre = '' OR '1'='1'  -> siempre es verdad,
            // así que devuelve TODAS las personas de la tabla.
            Console.WriteLine($"Vulnerable: {BuscarVulnerable(malicioso)} resultados");
            // Seguro: el texto se trata como un dato, se busca a alguien que se llame
            // literalmente  ' OR '1'='1  -> 0 resultados.
            Console.WriteLine($"Seguro:     {BuscarSeguro(malicioso)} resultados");
        }

        // MAL HECHO A PROPÓSITO: concatena el texto del usuario dentro del SQL
        static int BuscarVulnerable(string nombre)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            string sql = "SELECT Id, Nombre FROM Personas WHERE Nombre = '" + nombre + "'";
            using SqlCommand comando = new SqlCommand(sql, conexion);
            return ContarYMostrar(comando);
        }

        // BIEN HECHO: el nombre va como parámetro
        static int BuscarSeguro(string nombre)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("SELECT Id, Nombre FROM Personas WHERE Nombre = @nombre", conexion);
            comando.Parameters.AddWithValue("@nombre", nombre);
            return ContarYMostrar(comando);
        }

        static int ContarYMostrar(SqlCommand comando)
        {
            int total = 0;
            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
                total++;
            return total;
        }
    }
}
