using CRUD_Personal.Datos;
using CRUD_Personal.Modelos;
using CRUD_Personal.Repositorios;

namespace CRUD_Personal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;   // para que salgan bien tildes y emojis

            // 1) Antes de nada, comprobamos que hay conexión con AccesoDatos
            try
            {
                using var prueba = Conexion.Conectar();
                Console.WriteLine($"✅ Conectado a {prueba.Database} en {prueba.DataSource}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"❌ {ex.Message}: {ex.InnerException?.Message}");
                Console.WriteLine("¿Has ejecutado Scripts/crear-bd.sql en SSMS?");
                return;
            }

            // 2) El programa solo conoce la INTERFAZ: no sabe si por debajo hay ADO.NET o un ORM
            IPersonaRepository repo = new PersonaRepository();

            int opcion;
            do
            {
                Console.WriteLine();
                Console.WriteLine("===== CRUD PERSONAS =====");
                Console.WriteLine("1. Listar personas activas");
                Console.WriteLine("2. Buscar por Id");
                Console.WriteLine("3. Buscar por nombre");
                Console.WriteLine("4. Insertar persona");
                Console.WriteLine("5. Actualizar persona");
                Console.WriteLine("6. Dar de baja (borrado lógico)");
                Console.WriteLine("7. Eliminar (borrado físico)");
                Console.WriteLine("0. Salir");
                opcion = LeerEntero("Opción: ");
                Console.WriteLine();

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            Mostrar(repo.ObtenerTodas());
                            break;
                        case 2:
                            Persona? encontrada = repo.ObtenerPorId(LeerEntero("Id: "));
                            Console.WriteLine(encontrada?.ToString() ?? "No existe ninguna persona con ese Id.");
                            break;
                        case 3:
                            Mostrar(repo.BuscarPorNombre(LeerTexto("Texto a buscar: ")));
                            break;
                        case 4:
                            var nueva = new Persona
                            {
                                Nombre = LeerTexto("Nombre: "),
                                Email = LeerTexto("Email: "),
                                Edad = LeerEntero("Edad: ")
                            };
                            Console.WriteLine($"✅ Insertada con Id {repo.Insertar(nueva)}");
                            break;
                        case 5:
                            Persona? p = repo.ObtenerPorId(LeerEntero("Id a actualizar: "));
                            if (p == null)
                            {
                                Console.WriteLine("No existe ninguna persona con ese Id.");
                                break;
                            }
                            Console.WriteLine($"Actual: {p}  (Intro = dejar igual)");
                            string nombre = LeerTexto($"Nombre [{p.Nombre}]: ", permitirVacio: true);
                            string email = LeerTexto($"Email [{p.Email}]: ", permitirVacio: true);
                            string edad = LeerTexto($"Edad [{p.Edad}]: ", permitirVacio: true);
                            if (nombre != "") p.Nombre = nombre;
                            if (email != "") p.Email = email;
                            if (int.TryParse(edad, out int nuevaEdad)) p.Edad = nuevaEdad;
                            Console.WriteLine(repo.Actualizar(p) ? "✅ Actualizada" : "No se ha podido actualizar.");
                            break;
                        case 6:
                            Console.WriteLine(repo.DarDeBaja(LeerEntero("Id: "))
                                ? "✅ Dada de baja" : "No existe o ya estaba de baja.");
                            break;
                        case 7:
                            int idBorrar = LeerEntero("Id: ");
                            if (LeerTexto("¿Seguro? Se borrará para siempre (s/n): ").ToLower() == "s")
                                Console.WriteLine(repo.Eliminar(idBorrar) ? "✅ Eliminada" : "No existe ese Id.");
                            break;
                        case 0:
                            Console.WriteLine("¡Hasta luego!");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (InvalidOperationException ex)   // errores "traducidos" por el repositorio
                {
                    Console.WriteLine($"⚠️ {ex.Message}");
                }
            } while (opcion != 0);

            // ---------- Funciones auxiliares de consola ----------

            static void Mostrar(List<Persona> personas)
            {
                if (personas.Count == 0)
                {
                    Console.WriteLine("(no hay resultados)");
                    return;
                }
                foreach (Persona p in personas)
                    Console.WriteLine(p);
            }

            static int LeerEntero(string mensaje)
            {
                int valor;
                Console.Write(mensaje);
                while (!int.TryParse(Console.ReadLine(), out valor))
                    Console.Write("  Escribe un número entero: ");
                return valor;
            }

            static string LeerTexto(string mensaje, bool permitirVacio = false)
            {
                string texto;
                do
                {
                    Console.Write(mensaje);
                    texto = (Console.ReadLine() ?? "").Trim();
                } while (texto == "" && !permitirVacio);
                return texto;
            }
        }
    }
}
