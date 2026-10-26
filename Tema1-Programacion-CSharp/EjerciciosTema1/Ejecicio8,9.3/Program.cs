using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejecicio8_9._3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(EsMayorDeEdad(16));   // False
            Console.WriteLine(EsMayorDeEdad(18));   // True
            Console.WriteLine(EsMayorDeEdad(25));
        }
        static bool EsMayorDeEdad(int edad)
        {
            return edad >= 18;
        }
    }
}
