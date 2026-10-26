using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<String> list = new List<String>();
            list.Add("HOLA");
            list.Add("Machaco");
            list.Add("Asier");
            foreach (String i in list)
            {
                Console.WriteLine(i);

            }
            list.Remove("Machaco");
            Console.WriteLine(list);
            Console.WriteLine($"te quedan {list.Count}tareas");
        }
    }
}
