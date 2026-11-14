using CRUD_Personal.Datos;
using CRUD_Personal.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personal.Repositorios
{
    internal class PersonaRepository : IPersonaRepository 
    {
        // Las columnas que leen todos los SELECT, en un único sitio
        private const string Columnas = "Id, Nombre, Email, Edad, Activo";

        // Convierte la fila ACTUAL del lector en un objeto Persona
        private static Persona MapearPersona(SqlDataReader lector)
        {
            int colEdad = lector.GetOrdinal("Edad");

            return new Persona
            {
                Id = lector.GetInt32(lector.GetOrdinal("Id")),
                Nombre = lector.GetString(lector.GetOrdinal("Nombre")),
                Email = lector.GetString(lector.GetOrdinal("Email")),
                Edad = lector.IsDBNull(colEdad) ? 0 : lector.GetInt32(colEdad),
                Activo = lector.GetBoolean(lector.GetOrdinal("Activo"))
            };
        }

        public Persona? ObtenerPorId(int id)
        {
            using SqlConnection conexion = Conexion.Conectar();
            using SqlCommand comando = new SqlCommand(
                $"SELECT {Columnas} FROM Personas WHERE Id = @id", conexion);
            comando.Parameters.AddWithValue("@id", id);
            using SqlDataReader lector = comando.ExecuteReader();

            // Por clave primaria hay como mucho UNA fila → if, no while
            return lector.Read() ? MapearPersona(lector) : null;
        }

        public List<Persona> ObtenerTodas()
        {
            List<Persona> resultado = new();
            using SqlConnection conexion = Conexion.Conectar();
            using SqlCommand comando = new SqlCommand(
                $"SELECT {Columnas} FROM Personas WHERE Activo = 1 ORDER BY Nombre", conexion);
            using SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
                resultado.Add(MapearPersona(lector));

            return resultado;
        }

        public List<Persona> BuscarPorNombre(string texto)
        {
            List<Persona> resultado = new();
            using SqlConnection conexion = Conexion.Conectar();
            using SqlCommand comando = new SqlCommand(
                $"SELECT {Columnas} FROM Personas " +
                "WHERE Activo = 1 AND Nombre LIKE @patron ORDER BY Nombre", conexion);
            comando.Parameters.AddWithValue("@patron", $"%{texto}%");   // §3.5.6, ejemplo 3
            using SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
                resultado.Add(MapearPersona(lector));

            return resultado;
        }
        public int Insertar(Persona p)
        {
            string sql = @"INSERT INTO Personas (Nombre, Email, Edad)
                   OUTPUT INSERTED.Id
                   VALUES (@nombre, @email, @edad)";
            try
            {
                using SqlConnection conexion = Conexion.Conectar();
                using SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@nombre", p.Nombre);
                comando.Parameters.AddWithValue("@email", p.Email);
                comando.Parameters.AddWithValue("@edad", p.Edad);

                p.Id = (int)comando.ExecuteScalar()!;   // el objeto ya conoce su Id
                return p.Id;
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                throw new InvalidOperationException($"Ya existe una persona con el email {p.Email}", ex);
            }
        }
        public bool Actualizar(Persona p)
        {
            try
            {
                using SqlConnection conexion = Conexion.Conectar();
                using SqlCommand comando = new SqlCommand(
                    @"UPDATE Personas
              SET Nombre = @nombre, Email = @email, Edad = @edad
              WHERE Id = @id", conexion);
                comando.Parameters.AddWithValue("@nombre", p.Nombre);
                comando.Parameters.AddWithValue("@email", p.Email);
                comando.Parameters.AddWithValue("@edad", p.Edad);
                comando.Parameters.AddWithValue("@id", p.Id);

                return comando.ExecuteNonQuery() == 1;   // false → no existe ese Id
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                throw new InvalidOperationException($"Ya existe otra persona con el email {p.Email}", ex);
            }
        }

        // Borrado LÓGICO: la fila se queda, marcada como baja (§3.4.5)
        public bool DarDeBaja(int id)
        {
            using SqlConnection conexion = Conexion.Conectar();
            using SqlCommand comando = new SqlCommand(
                "UPDATE Personas SET Activo = 0 WHERE Id = @id AND Activo = 1", conexion);
            comando.Parameters.AddWithValue("@id", id);

            return comando.ExecuteNonQuery() == 1;   // false → no existe o ya estaba de baja
        }

        // Borrado FÍSICO: la fila desaparece para siempre
        public bool Eliminar(int id)
        {
            try
            {
                using SqlConnection conexion = Conexion.Conectar();
                using SqlCommand comando = new SqlCommand(
                    "DELETE FROM Personas WHERE Id = @id", conexion);
                comando.Parameters.AddWithValue("@id", id);

                return comando.ExecuteNonQuery() == 1;
            }
            catch (SqlException ex) when (ex.Number == 547)   // otra tabla la referencia (clave ajena)
            {
                throw new InvalidOperationException(
                    $"La persona {id} tiene datos relacionados: usa mejor el borrado lógico", ex);
            }
        }   
        
    }
}
