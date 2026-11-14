// Ejercicio 07 - Exportar un inventario a XML
using System.Xml.Serialization;

namespace Ejercicio07
{
    // XmlSerializer necesita clase pública, propiedades con set y constructor vacío
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto() { }

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
            List<Producto> productos = new List<Producto>
            {
                new Producto("Teclado", 25.50m),
                new Producto("Ratón", 12.99m),
                new Producto("Monitor", 149.00m)
            };

            XmlSerializer serializador = new XmlSerializer(typeof(List<Producto>));

            // 2) Guardar
            using (StreamWriter escritor = new StreamWriter("productos.xml"))
            {
                serializador.Serialize(escritor, productos);
            }
            Console.WriteLine("Productos guardados en productos.xml");

            // 3) Leer y mostrar
            List<Producto> leidos;
            using (StreamReader lector = new StreamReader("productos.xml"))
            {
                leidos = (List<Producto>)serializador.Deserialize(lector);
            }
            foreach (Producto p in leidos)
                Console.WriteLine($"{p.Nombre}: {p.Precio:F2} €");
        }
    }
}
