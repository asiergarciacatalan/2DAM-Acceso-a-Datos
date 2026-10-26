using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Producto> Productos = new List<Producto>
            {
                new Producto("Teclado","Periféricos", 25.99m),
                new Producto("Monitor","Pantallas", 149.00m),
                new Producto("Raton","Periféricos", 12.50m),
                new Producto("Portátil","Ordenadores", 799.00m),
                new Producto("Webcam","Periféricos", 39.90m),
                new Producto("Tablet","Ordenadores", 229.00m)

            };
            List<Producto> porprecio= Productos.OrderBy(p => p.Precio).ToList();
            foreach (Producto p in porprecio)
            {
                Console.WriteLine($"{  p.Nombre} : {p.Precio}");
            }
            Producto mascaro = Productos.OrderByDescending(p => p.Precio).First();
            Console.WriteLine();
            Console.WriteLine($"El más caro: {mascaro.Nombre} ({mascaro.Precio} ");
            List<Producto> porcategoria = Productos
                .OrderBy(p => p.Categoria)
                .ThenBy(p=>p.Nombre)
                .ToList();
            Console.WriteLine();
            foreach (Producto p in porcategoria)
            {
                Console.WriteLine($"la categoria es : {p.Categoria}---- {p.Nombre}");

            }
            Producto impresora = Productos.FirstOrDefault(p => p.Categoria == "Impresoras");

            Console.WriteLine();
            if (impresora == null)
            {
                Console.WriteLine("No hay impresoras en el catálogo.");
            }
            else
            {
                Console.WriteLine($"Primera impresora: {impresora.Nombre}");
            }
        }
    }
}
