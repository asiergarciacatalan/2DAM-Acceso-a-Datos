using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] temperaturas = { 18, 21, 19, 23, 20 };
            int suma = 0;
            foreach (int i in temperaturas)
            {
                Console.WriteLine(i);
               
                suma += i;

            }
            double media = suma / temperaturas.Length;
            Console.WriteLine(media);
            




        }
        

    }
}
