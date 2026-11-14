// Ejercicio C1_C2_03 - Esqueleto de un proyecto
namespace Ejercicio_C1_C2_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string raiz = "ProyectoDAM";
            string[] subcarpetas = { "docs", "src", "tests" };

            // 1 y 2) Crear carpetas y LEEME.txt si no existen
            foreach (string nombre in subcarpetas)
            {
                string carpeta = Path.Combine(raiz, nombre);
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                    Console.WriteLine($"Creada: {carpeta}");
                }
                else
                {
                    Console.WriteLine($"Ya existía: {carpeta}");
                }

                string leeme = Path.Combine(carpeta, "LEEME.txt");
                if (!File.Exists(leeme))
                    File.WriteAllText(leeme, $"Carpeta {nombre} del ProyectoDAM");
            }

            // 3) Información de cada LEEME.txt
            Console.WriteLine();
            foreach (string nombre in subcarpetas)
            {
                FileInfo info = new FileInfo(Path.Combine(raiz, nombre, "LEEME.txt"));
                Console.WriteLine($"{info.Name} ({nombre}) - {info.Length} bytes - creado el {info.CreationTime:dd/MM/yyyy HH:mm}");
            }

            // 4) ¿Fichero o carpeta?
            Console.WriteLine();
            string[] rutas = { Path.Combine(raiz, "docs"), Path.Combine(raiz, "docs", "LEEME.txt") };
            foreach (string ruta in rutas)
                Console.WriteLine($"{ruta} -> File.Exists: {File.Exists(ruta)} | Directory.Exists: {Directory.Exists(ruta)}");
        }
    }
}
