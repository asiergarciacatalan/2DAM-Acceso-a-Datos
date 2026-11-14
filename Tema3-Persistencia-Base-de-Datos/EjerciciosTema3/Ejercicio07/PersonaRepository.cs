using Microsoft.Data.SqlClient;

namespace Ejercicio07
{
    public class PersonaRepository : IPersonaRepository
    {
        const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Tema03;Integrated Security=true;";

        private SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            return conexion;
        }

        public int Insertar(Persona persona)
        {
            using SqlConnection conexion = Conectar();
            string sql = "INSERT INTO Personas (Nombre, Edad) VALUES (@nombre, @edad); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            using SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@nombre", persona.Nombre);
            comando.Parameters.AddWithValue("@edad", persona.Edad);
            persona.Id = (int)comando.ExecuteScalar();
            return persona.Id;
        }

        public Persona ObtenerPorId(int id)
        {
            using SqlConnection conexion = Conectar();
            using SqlCommand comando = new SqlCommand("SELECT Id, Nombre, Edad FROM Personas WHERE Id = @id", conexion);
            comando.Parameters.AddWithValue("@id", id);
            using SqlDataReader lector = comando.ExecuteReader();
            if (lector.Read())
                return new Persona { Id = lector.GetInt32(0), Nombre = lector.GetString(1), Edad = lector.GetInt32(2) };
            return null;
        }

        public List<Persona> ObtenerTodas()
        {
            List<Persona> personas = new List<Persona>();
            using SqlConnection conexion = Conectar();
            using SqlCommand comando = new SqlCommand("SELECT Id, Nombre, Edad FROM Personas", conexion);
            using SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
                personas.Add(new Persona { Id = lector.GetInt32(0), Nombre = lector.GetString(1), Edad = lector.GetInt32(2) });
            return personas;
        }

        public bool Actualizar(Persona persona)
        {
            using SqlConnection conexion = Conectar();
            using SqlCommand comando = new SqlCommand("UPDATE Personas SET Nombre = @nombre, Edad = @edad WHERE Id = @id", conexion);
            comando.Parameters.AddWithValue("@nombre", persona.Nombre);
            comando.Parameters.AddWithValue("@edad", persona.Edad);
            comando.Parameters.AddWithValue("@id", persona.Id);
            return comando.ExecuteNonQuery() > 0;
        }

        public bool Eliminar(int id)
        {
            using SqlConnection conexion = Conectar();
            using SqlCommand comando = new SqlCommand("DELETE FROM Personas WHERE Id = @id", conexion);
            comando.Parameters.AddWithValue("@id", id);
            return comando.ExecuteNonQuery() > 0;
        }
    }
}
