// Ejercicio 05 - Catálogo de productos en CSV
namespace Ejercicio05
{
    internal class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Producto(string nombre, decimal precio, int stock)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Producto> productos = new List<Producto>
            {
                new Producto("Teclado", 25.50m, 10),
                new Producto("Ratón", 12.99m, 25),
                new Producto("Monitor", 149.00m, 4),
                new Producto("Webcam", 39.90m, 7),
                new Producto("Altavoces", 19.95m, 12)
            };

            // 2) Exportar a CSV con ; como separador
            using (StreamWriter escritor = new StreamWriter("productos.csv"))
            {
                escritor.WriteLine("Nombre;Precio;Stock");
                foreach (Producto p in productos)
                    escritor.WriteLine($"{p.Nombre};{p.Precio};{p.Stock}");
            }
            Console.WriteLine("Productos guardados en productos.csv");

            // 3) Leerlo de nuevo
            List<Producto> leidos = new List<Producto>();
            string[] lineas = File.ReadAllLines("productos.csv");
            for (int i = 1; i < lineas.Length; i++)   // empezamos en 1 para saltar la cabecera
            {
                string[] campos = lineas[i].Split(';');
                leidos.Add(new Producto(campos[0], decimal.Parse(campos[1]), int.Parse(campos[2])));
            }

            foreach (Producto p in leidos)
                Console.WriteLine($"{p.Nombre}: {p.Precio:F2} € x {p.Stock}");

            // 4) Valor total del inventario
            decimal total = leidos.Sum(p => p.Precio * p.Stock);
            Console.WriteLine($"Valor total del inventario: {total:F2} €");
        }
    }
}
