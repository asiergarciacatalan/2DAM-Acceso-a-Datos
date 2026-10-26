using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio13._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int> { 12, 7, 25, 3, 18, 40, 9, 16 };
            List<int>pares=numeros.Where(x => x % 2==0).ToList();
            foreach(int x in pares)
            {
                Console.WriteLine(x);
            }
            List<int> mayoresQueDiez = numeros.Where(n => n > 10).ToList();
            foreach (int x in mayoresQueDiez)
            {
                Console.WriteLine(x);
            }
            List<int> entreDiezYVeinte = numeros.Where(n => n >= 10 && n <= 20).ToList();
            foreach (int x in entreDiezYVeinte)
            {
                Console.WriteLine(x);
            }
            int impares = numeros.Count(n => n % 2 != 0);
            Console.WriteLine(impares);
        }
    }
}
