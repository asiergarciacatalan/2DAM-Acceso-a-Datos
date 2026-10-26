using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejecicio13._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> nombres = new List<string> { "ana", "luis", "marta", "pablo" };
            List<string> mayusculas=nombres.Select(x => x.ToUpper()).ToList();
            List<int> letras = nombres.Select(n => n.Length).ToList();
            List<string> saludos = nombres.Select(n => $"Hola, {n}").ToList();
            List<string> largos = nombres
              .Where(n => n.Length > 4)
              .Select(n => n.ToUpper())
              .ToList();
            Console.WriteLine($"Mayúsculas: {string.Join(", ", mayusculas)}");
            Console.WriteLine($"Letras: {string.Join(", ", letras)}");

            foreach (string saludo in saludos)
            {
                Console.WriteLine(saludo);
            }

            Console.WriteLine($"Más de 4 letras: {string.Join(", ", largos)}");
        }
    }
}
