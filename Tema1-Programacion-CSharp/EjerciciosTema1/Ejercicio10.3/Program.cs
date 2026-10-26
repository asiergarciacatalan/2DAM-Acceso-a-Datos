using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cancion cancion = new Cancion("Bohemian Rhapsody", "Queen");
            Podcast podcast = new Podcast("Código Abierto", 12);

            
            List<IReproducible> lista = new List<IReproducible>
            {
                cancion,
                new Cancion("Mediterráneo", "Joan Manuel Serrat"),
                podcast
            };

            Console.WriteLine("=== LISTA DE REPRODUCCIÓN ===");
            foreach (IReproducible elemento in lista)
            {
                elemento.reproducir();   
            }

            Console.WriteLine();
            Console.WriteLine("=== DESCARGAS ===");
            cancion.descargar();         
        }
    }
}
