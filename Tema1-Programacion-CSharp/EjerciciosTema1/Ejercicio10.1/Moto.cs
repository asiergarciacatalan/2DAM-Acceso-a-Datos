using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10._1
{
    public class Moto : Vehiculo
    {
        public int Cilindrada { get; }

        public Moto(string marca, string modelo, int anio, int cilindrada)
            : base(marca, modelo, anio)
        {
            Cilindrada = cilindrada;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"Cilindrada: {Cilindrada} cc");
        }
    }
}
