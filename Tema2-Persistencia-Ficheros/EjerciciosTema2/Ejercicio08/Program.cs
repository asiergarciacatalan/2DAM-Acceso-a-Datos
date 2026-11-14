// Ejercicio 08 - Catálogo binario
namespace Ejercicio08
{
    internal class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string ruta = "productos.bin";
            List<Producto> productos = new List<Producto>
            {
                new Producto("Teclado", 25.50m),
                new Producto("Ratón", 12.99m),
                new Producto("Monitor", 149.00m),
                new Producto("Webcam", 39.90m)
            };

            GuardarBinario(ruta, productos);
            List<Producto> cargados = CargarBinario(ruta, productos.Count);

            // Comparamos uno a uno (no con ==, que compara referencias)
            for (int i = 0; i < productos.Count; i++)
            {
                string ok = Coinciden(productos[i], cargados[i]) ? "OK" : "DISTINTO";
                Console.WriteLine($"{cargados[i].Nombre} - {cargados[i].Precio:F2} € -> {ok}");
            }
        }

        static void GuardarBinario(string ruta, List<Producto> productos)
        {
            using (BinaryWriter escritor = new BinaryWriter(File.Open(ruta, FileMode.Create)))
            {
                foreach (Producto p in productos)
                {
                    escritor.Write(p.Nombre);
                    escritor.Write(p.Precio);
                }
            }
        }

        static List<Producto> CargarBinario(string ruta, int cantidad)
        {
            List<Producto> lista = new List<Producto>();
            using (BinaryReader lector = new BinaryReader(File.Open(ruta, FileMode.Open)))
            {
                for (int i = 0; i < cantidad; i++)
                {
                    // Se lee en el mismo orden en que se escribió: primero nombre, luego precio
                    string nombre = lector.ReadString();
                    decimal precio = lector.ReadDecimal();
                    lista.Add(new Producto(nombre, precio));
                }
            }
            return lista;
        }

        static bool Coinciden(Producto a, Producto b)
        {
            return a.Nombre == b.Nombre && a.Precio == b.Precio;
        }
    }
}
