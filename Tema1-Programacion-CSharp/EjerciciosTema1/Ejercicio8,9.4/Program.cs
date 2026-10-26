using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio8_9._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            saludar("Ala");
            saludar("Asier", "en");
            saludar(idioma:"en",nombre:"enalia");

        }
        static void saludar(string nombre,string idioma="es")
        {
            if (idioma=="en")
            {
                Console.WriteLine($"Hello,{nombre}");

            }
            else
            {
                Console.WriteLine($"Hola,{nombre}");
            }
        }
    }
}
