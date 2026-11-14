// Ejercicio 04 - Gestión de una lista de la compra
namespace Ejercicio04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> compra = new List<string>();
            compra.Add("Leche");
            compra.Add("Pan");
            compra.Add("Huevos");
            compra.Add("Manzanas");
            compra.Add("Arroz");

            Console.WriteLine("Lista de la compra:");
            int i = 1;
            foreach (string producto in compra)
            {
                Console.WriteLine($"{i}. {producto}");
                i++;
            }

            compra.Remove("Pan");
            Console.WriteLine("\nHe quitado el Pan.");

            Console.WriteLine($"¿Hay Huevos? {compra.Contains("Huevos")}");
            Console.WriteLine($"Quedan {compra.Count} productos.");
        }
    }
}
