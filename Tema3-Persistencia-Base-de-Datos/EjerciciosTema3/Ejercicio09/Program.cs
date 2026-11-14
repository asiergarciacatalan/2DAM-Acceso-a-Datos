// Ejercicio 09 - Transacción: transferencia entre cuentas
using Microsoft.Data.SqlClient;

namespace Ejercicio09
{
    internal class Program
    {
        const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Tema03;Integrated Security=true;";

        static void Main(string[] args)
        {
            // 1) Crear la tabla desde cero con 2 cuentas (Id 1 y 2)
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                string sql = @"DROP TABLE IF EXISTS Cuentas;
                               CREATE TABLE Cuentas (
                                   Id INT IDENTITY PRIMARY KEY,
                                   Titular NVARCHAR(100),
                                   Saldo DECIMAL(10,2)
                               );
                               INSERT INTO Cuentas (Titular, Saldo) VALUES ('Ana', 500), ('Luis', 100);";
                using SqlCommand comando = new SqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
            }

            MostrarSaldos("Saldos iniciales");

            // 4a) Transferencia válida
            Transferir(1, 2, 200);
            MostrarSaldos("Después de transferir 200 de Ana a Luis");

            // 4b) Transferencia inválida (Luis no tiene 1000)
            Transferir(2, 1, 1000);
            MostrarSaldos("Después del intento de transferir 1000 de Luis a Ana");
        }

        static void Transferir(int idOrigen, int idDestino, decimal cantidad)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlTransaction transaccion = conexion.BeginTransaction();
            try
            {
                // Restar al origen
                using (SqlCommand restar = new SqlCommand("UPDATE Cuentas SET Saldo = Saldo - @cantidad WHERE Id = @id", conexion, transaccion))
                {
                    restar.Parameters.AddWithValue("@cantidad", cantidad);
                    restar.Parameters.AddWithValue("@id", idOrigen);
                    restar.ExecuteNonQuery();
                }

                // Comprobar que no se ha quedado en negativo
                using (SqlCommand consultar = new SqlCommand("SELECT Saldo FROM Cuentas WHERE Id = @id", conexion, transaccion))
                {
                    consultar.Parameters.AddWithValue("@id", idOrigen);
                    decimal saldo = (decimal)consultar.ExecuteScalar();
                    if (saldo < 0)
                        throw new InvalidOperationException("Saldo insuficiente en la cuenta de origen.");
                }

                // Sumar al destino
                using (SqlCommand sumar = new SqlCommand("UPDATE Cuentas SET Saldo = Saldo + @cantidad WHERE Id = @id", conexion, transaccion))
                {
                    sumar.Parameters.AddWithValue("@cantidad", cantidad);
                    sumar.Parameters.AddWithValue("@id", idDestino);
                    sumar.ExecuteNonQuery();
                }

                transaccion.Commit();   // todo bien: se guardan los dos cambios
                Console.WriteLine($"Transferencia de {cantidad} € hecha.");
            }
            catch (Exception ex)
            {
                transaccion.Rollback();   // algo falló: se deshace TODO, también la resta
                Console.WriteLine($"Transferencia cancelada: {ex.Message}");
            }
        }

        static void MostrarSaldos(string titulo)
        {
            Console.WriteLine($"\n--- {titulo} ---");
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("SELECT Id, Titular, Saldo FROM Cuentas", conexion);
            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
                Console.WriteLine($"{lector.GetInt32(0)} - {lector.GetString(1)}: {lector.GetDecimal(2)} €");
            Console.WriteLine();
        }
    }
}
