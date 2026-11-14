// Ejercicio 01 - Gestión básica de ficheros y carpetas
namespace Ejercicio01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string carpeta = "datos";
            string saludo = Path.Combine(carpeta, "saludo.txt");
            string copia = Path.Combine(carpeta, "saludo_copia.txt");

            // 1) Crear la carpeta si no existe
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
                Console.WriteLine("Carpeta 'datos' creada.");
            }

            // 2) Crear saludo.txt si no existe
            if (!File.Exists(saludo))
            {
                File.WriteAllText(saludo, "Hola, Acceso a Datos!");
                Console.WriteLine("Fichero saludo.txt creado.");
            }

            // 3) Copiar (sobrescribiendo si ya existe)
            File.Copy(saludo, copia, overwrite: true);
            Console.WriteLine("Copia creada.");

            // 4) Tamaños
            Console.WriteLine($"saludo.txt: {new FileInfo(saludo).Length} bytes");
            Console.WriteLine($"saludo_copia.txt: {new FileInfo(copia).Length} bytes");

            // 5) Borrar la copia
            File.Delete(copia);
            Console.WriteLine("Copia eliminada.");
        }
    }
}
