using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coche coche = new Coche("Seat", "Ibiza", 2021, 5);
            Moto moto = new Moto("Yamaha", "MT-07", 2023, 689);

            Console.WriteLine("--- Coche ---");
            coche.MostrarInfo();

            Console.WriteLine("--- Moto ---");
            moto.MostrarInfo();
        }
    }
}
