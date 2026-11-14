using Microsoft.Data.SqlClient;

const string CadenaConexion =
    @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Prueba;Integrated Security=true;";

using SqlConnection conexion = new SqlConnection(CadenaConexion);
conexion.Open();
Console.WriteLine($"Conectado a {conexion.Database}");

using (SqlCommand insertar = new SqlCommand(
    "INSERT INTO Personas (Nombre, Edad) VALUES (@nombre, @edad)", conexion))
{
    insertar.Parameters.AddWithValue("@nombre", "Asi");
    insertar.Parameters.AddWithValue("@edad", 19);
    Console.WriteLine($"Filas insertadas: {insertar.ExecuteNonQuery()}");
}

using (SqlCommand contar = new SqlCommand("SELECT COUNT(*) FROM Personas", conexion))
{
    Console.WriteLine($"Personas en la tabla: {(int)contar.ExecuteScalar()!}");
}
