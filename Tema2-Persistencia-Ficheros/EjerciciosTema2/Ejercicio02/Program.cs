// Ejercicio 02 - Explorador de directorio
namespace Ejercicio02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ruta de la carpeta (Enter = carpeta actual): ");
            string ruta = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ruta))
                ruta = Directory.GetCurrentDirectory();

            if (!Directory.Exists(ruta))
            {
                Console.WriteLine("Esa carpeta no existe.");
                return;
            }

            // 2) Solo los .cs de esta carpeta
            Console.WriteLine("\nFicheros .cs (solo esta carpeta):");
            foreach (string fichero in Directory.EnumerateFiles(ruta, "*.cs"))
                Console.WriteLine($"  {Path.GetFileName(fichero)}");

            // 3) Todos los ficheros, también los de las subcarpetas
            Console.WriteLine("\nTodos los ficheros (con subcarpetas):");
            int total = 0;
            foreach (string fichero in Directory.EnumerateFiles(ruta, "*", SearchOption.AllDirectories))
            {
                Console.WriteLine($"  {Path.GetRelativePath(ruta, fichero)}");
                total++;
            }

            // 4) Total
            Console.WriteLine($"\nTotal de ficheros: {total}");
        }
    }
}
