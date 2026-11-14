// Ejercicio 07 - Patrón Repository
// El Main solo usa el repositorio: aquí no hay ni una línea de SQL.
namespace Ejercicio07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPersonaRepository repo = new PersonaRepository();

            // Insertar 3 personas
            int id1 = repo.Insertar(new Persona { Nombre = "Carlos", Edad = 28 });
            int id2 = repo.Insertar(new Persona { Nombre = "Elena", Edad = 35 });
            int id3 = repo.Insertar(new Persona { Nombre = "Jorge", Edad = 22 });
            Console.WriteLine($"Insertadas con Id {id1}, {id2} y {id3}");

            // Listar todas
            Console.WriteLine("\n--- Todas ---");
            foreach (Persona p in repo.ObtenerTodas())
                Console.WriteLine(p);

            // Actualizar una
            Persona elena = repo.ObtenerPorId(id2);
            elena.Edad = 36;
            Console.WriteLine($"\nActualizar Elena: {repo.Actualizar(elena)}");
            Console.WriteLine(repo.ObtenerPorId(id2));

            // Eliminar otra
            Console.WriteLine($"\nEliminar Jorge: {repo.Eliminar(id3)}");
            Console.WriteLine($"¿Sigue existiendo? {repo.ObtenerPorId(id3) != null}");
        }
    }
}
