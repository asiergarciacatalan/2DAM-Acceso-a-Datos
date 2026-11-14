using Microsoft.Data.SqlClient;

namespace Ejercicio10
{
    public class LibroRepository
    {
        public const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Tema03;Integrated Security=true;";

        public int Insertar(string titulo)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            string sql = "INSERT INTO Libros (Titulo) VALUES (@titulo); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            using SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@titulo", titulo);
            return (int)comando.ExecuteScalar();
        }

        public Libro ObtenerPorId(int id)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("SELECT Id, Titulo, Disponible FROM Libros WHERE Id = @id", conexion);
            comando.Parameters.AddWithValue("@id", id);
            using SqlDataReader lector = comando.ExecuteReader();
            if (lector.Read())
                return new Libro { Id = lector.GetInt32(0), Titulo = lector.GetString(1), Disponible = lector.GetBoolean(2) };
            return null;
        }

        public List<Libro> ObtenerTodos()
        {
            List<Libro> libros = new List<Libro>();
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("SELECT Id, Titulo, Disponible FROM Libros", conexion);
            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
                libros.Add(new Libro { Id = lector.GetInt32(0), Titulo = lector.GetString(1), Disponible = lector.GetBoolean(2) });
            return libros;
        }

        public bool Actualizar(Libro libro)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("UPDATE Libros SET Titulo = @titulo, Disponible = @disponible WHERE Id = @id", conexion);
            comando.Parameters.AddWithValue("@titulo", libro.Titulo);
            comando.Parameters.AddWithValue("@disponible", libro.Disponible);
            comando.Parameters.AddWithValue("@id", libro.Id);
            return comando.ExecuteNonQuery() > 0;
        }

        public bool Eliminar(int id)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlCommand comando = new SqlCommand("DELETE FROM Libros WHERE Id = @id", conexion);
            comando.Parameters.AddWithValue("@id", id);
            return comando.ExecuteNonQuery() > 0;
        }
    }
}
