// Ejercicio 04 - Clave autonumérica frente a GUID
using Microsoft.Data.SqlClient;

namespace Ejercicio04
{
    internal class Program
    {
        const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Tema03;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();

            // 1 y 2) Crear las dos tablas
            Ejecutar(conexion, @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Productos' AND xtype='U')
                                 CREATE TABLE Productos (
                                     Id INT IDENTITY(1,1) PRIMARY KEY,
                                     Nombre NVARCHAR(100)
                                 )");
            Ejecutar(conexion, @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Pedidos' AND xtype='U')
                                 CREATE TABLE Pedidos (
                                     Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                                     Cliente NVARCHAR(100)
                                 )");

            // 3a) Autonumérica: SCOPE_IDENTITY() devuelve el Id que se acaba de generar
            string sqlProducto = "INSERT INTO Productos (Nombre) VALUES (@nombre); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            using (SqlCommand comando = new SqlCommand(sqlProducto, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", "Teclado");
                int id = (int)comando.ExecuteScalar();
                Console.WriteLine($"Producto insertado con Id: {id}");
            }

            // 3b) GUID: OUTPUT INSERTED.Id nos devuelve la fila recién insertada
            string sqlPedido = "INSERT INTO Pedidos (Cliente) OUTPUT INSERTED.Id VALUES (@cliente)";
            using (SqlCommand comando = new SqlCommand(sqlPedido, conexion))
            {
                comando.Parameters.AddWithValue("@cliente", "Ana");
                Guid id = (Guid)comando.ExecuteScalar();
                Console.WriteLine($"Pedido insertado con Id: {id}");
            }

            // 4) ¿Cuándo usar cada una?
            // - IDENTITY (autonumérica): lo normal. Es corta, legible y ordenada (1, 2, 3...).
            //   Ideal para una sola base de datos.
            // - GUID: cuando el Id tiene que ser único entre varias bases de datos o sistemas,
            //   o cuando no quieres que se pueda adivinar cuántos registros hay.
            //   Inconveniente: es larga y ocupa más.
        }

        static void Ejecutar(SqlConnection conexion, string sql)
        {
            using SqlCommand comando = new SqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
        }
    }
}
