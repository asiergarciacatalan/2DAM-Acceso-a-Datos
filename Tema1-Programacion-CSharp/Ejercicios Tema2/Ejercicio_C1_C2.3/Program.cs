using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_C1_C2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String raiz = "Proyecto1";
            String[] docs = { "archivo1", "archivo2", "archivo3" };
            foreach (String doc in docs)
            {
                string carpetas = Path.Combine(raiz, doc);
                if (!Directory.Exists(carpetas))
                {
                    Directory.CreateDirectory(carpetas);
                    Console.WriteLine($"Se creó la carpeta: {carpetas}");

                }
                else
                {
                    Console.WriteLine($"La carpeta ya existe: {carpetas}");
                }
                string leeme = Path.Combine(carpetas, "leeme.txt");
                if (!File.Exists(leeme))
                {
                    File.WriteAllText(leeme, "Este es el contenido del archivo leeme.txt");
                    Console.WriteLine($"Se creó el archivo: {leeme}");
                }
                else
                {
                    Console.WriteLine($"El archivo ya existe: {leeme}");
                }
                Console.WriteLine();
                foreach(String doco in docs)
                {
                    FileInfo archivo = new FileInfo(Path.Combine(raiz, doco, "leeme.txt"));
                    Console.WriteLine($"Tamaño del archivo {archivo.Name}: {archivo.Length} bytes");

                }
                string[] rutasprueba =
                {
                Path.Combine(raiz, "archivo1", "leeme.txt"),
                Path.Combine(raiz, "archivo2", "leeme.txt")


                };
                foreach(string ruta in rutasprueba)
                {
                    Console.WriteLine($"{ruta} -> File.Exists: {File.Exists(ruta)} | " +
                    $"Directory.Exists: {Directory.Exists(ruta)}");









                }
            }
        }
    }
}
