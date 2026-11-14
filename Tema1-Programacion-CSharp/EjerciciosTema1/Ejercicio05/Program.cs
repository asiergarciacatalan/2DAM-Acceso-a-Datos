// Ejercicio 05 - Diccionario de precios
namespace Ejercicio05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> catalogo = new Dictionary<string, decimal>();
            catalogo.Add("Café", 3.50m);
            catalogo.Add("Té", 2.80m);
            catalogo.Add("Zumo", 1.90m);
            catalogo.Add("Agua", 1.00m);
            catalogo.Add("Refresco", 1.75m);

            Console.Write("¿Qué producto quieres consultar? ");
            string producto = Console.ReadLine();

            // TryGetValue: no se rompe si el producto no existe
            if (catalogo.TryGetValue(producto, out decimal precio))
                Console.WriteLine($"{producto} cuesta {precio:F2} €");
            else
                Console.WriteLine($"{producto} no está en el catálogo.");

            // Actualizar un precio
            catalogo["Café"] = 3.75m;
            Console.WriteLine("Precio del Café actualizado a 3,75 €.");

            // Precio medio con un bucle (sin LINQ)
            decimal suma = 0;
            foreach (decimal p in catalogo.Values)
                suma += p;
            Console.WriteLine($"Precio medio: {suma / catalogo.Count:F2} €");
        }
    }
}
