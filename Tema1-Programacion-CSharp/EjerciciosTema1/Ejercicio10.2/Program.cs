using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> plantilla = new List<Empleado>
            {
                new EmpleadoFijo("Ana", 1800m, 300m),
                new EmpleadoFijo("Carlos", 1600m, 250m),
                new Empleadoporhoras("Lucía", 80, 15m),
                new Empleadoporhoras("Pedro", 48, 15m)
            };

            Console.WriteLine("=== NÓMINAS DEL MES ===");

            decimal total = 0;
            foreach (Empleado e in plantilla)
            {
                e.MostrarNomina();              
                total += e.CalcularSueldo();
            }

            Console.WriteLine("-----------------------");
            Console.WriteLine($"Total nóminas: {total:F2} €");
        }
    }
}
