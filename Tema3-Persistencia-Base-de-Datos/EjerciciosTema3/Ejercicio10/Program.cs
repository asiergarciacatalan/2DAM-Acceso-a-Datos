// Ejercicio 10 - Reto: mini sistema de biblioteca
using Microsoft.Data.SqlClient;

namespace Ejercicio10
{
    internal class Program
    {
        const string CadenaConexion = LibroRepository.CadenaConexion;

        static void Main(string[] args)
        {
            CrearTablas();
            LibroRepository repo = new LibroRepository();

            // Dar de alta libros
            int id1 = repo.Insertar("El Quijote");
            int id2 = repo.Insertar("La Regenta");
            repo.Insertar("Fortunata y Jacinta");
            MostrarLibros(repo, "Libros dados de alta");

            // Prestar uno
            Probar(() => PrestarLibro(id1, "Ana"));
            // Intentar prestarlo otra vez -> debe fallar
            Probar(() => PrestarLibro(id1, "Luis"));
            MostrarLibros(repo, "Después de prestar");

            // Devolverlo
            Probar(() => DevolverLibro(id1));
            MostrarLibros(repo, "Después de devolver");

            // El resto del CRUD también funciona
            Libro regenta = repo.ObtenerPorId(id2);
            regenta.Titulo = "La Regenta (edición de bolsillo)";
            repo.Actualizar(regenta);
            MostrarLibros(repo, "Después de actualizar un título");
        }

        static void CrearTablas()
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            // Empezamos de cero cada vez para que el ejemplo sea repetible
            string sql = @"DROP TABLE IF EXISTS Prestamos;
                           DROP TABLE IF EXISTS Libros;
                           CREATE TABLE Libros (
                               Id INT IDENTITY PRIMARY KEY,
                               Titulo NVARCHAR(200) NOT NULL,
                               Disponible BIT NOT NULL DEFAULT 1
                           );
                           CREATE TABLE Prestamos (
                               Id INT IDENTITY PRIMARY KEY,
                               LibroId INT NOT NULL REFERENCES Libros(Id),
                               Prestatario NVARCHAR(100) NOT NULL,
                               FechaPrestamo DATETIME NOT NULL
                           );";
            using SqlCommand comando = new SqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
        }

        static void PrestarLibro(int libroId, string prestatario)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlTransaction transaccion = conexion.BeginTransaction();
            try
            {
                // 1) ¿Está disponible?
                using (SqlCommand consultar = new SqlCommand("SELECT Disponible FROM Libros WHERE Id = @id", conexion, transaccion))
                {
                    consultar.Parameters.AddWithValue("@id", libroId);
                    object resultado = consultar.ExecuteScalar();
                    if (resultado == null)
                        throw new InvalidOperationException($"El libro {libroId} no existe.");
                    if (!(bool)resultado)
                        throw new InvalidOperationException($"El libro {libroId} ya está prestado.");
                }

                // 2) Marcarlo como no disponible
                using (SqlCommand marcar = new SqlCommand("UPDATE Libros SET Disponible = 0 WHERE Id = @id", conexion, transaccion))
                {
                    marcar.Parameters.AddWithValue("@id", libroId);
                    marcar.ExecuteNonQuery();
                }

                // 3) Registrar el préstamo
                using (SqlCommand registrar = new SqlCommand("INSERT INTO Prestamos (LibroId, Prestatario, FechaPrestamo) VALUES (@libro, @persona, @fecha)", conexion, transaccion))
                {
                    registrar.Parameters.AddWithValue("@libro", libroId);
                    registrar.Parameters.AddWithValue("@persona", prestatario);
                    registrar.Parameters.AddWithValue("@fecha", DateTime.Now);
                    registrar.ExecuteNonQuery();
                }

                transaccion.Commit();
                Console.WriteLine($"Libro {libroId} prestado a {prestatario}.");
            }
            catch
            {
                transaccion.Rollback();
                throw;   // lo relanzamos para que lo vea quien llamó
            }
        }

        static void DevolverLibro(int libroId)
        {
            using SqlConnection conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            using SqlTransaction transaccion = conexion.BeginTransaction();
            try
            {
                using SqlCommand comando = new SqlCommand("UPDATE Libros SET Disponible = 1 WHERE Id = @id", conexion, transaccion);
                comando.Parameters.AddWithValue("@id", libroId);
                if (comando.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"El libro {libroId} no existe.");

                transaccion.Commit();
                Console.WriteLine($"Libro {libroId} devuelto.");
            }
            catch
            {
                transaccion.Rollback();
                throw;
            }
        }

        // Ejecuta una acción y muestra el error si falla
        static void Probar(Action accion)
        {
            try
            {
                accion();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void MostrarLibros(LibroRepository repo, string titulo)
        {
            Console.WriteLine($"\n--- {titulo} ---");
            foreach (Libro libro in repo.ObtenerTodos())
                Console.WriteLine(libro);
            Console.WriteLine();
        }
    }
}
