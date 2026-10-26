using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10._1
{
    public class Coche:Vehiculo
    {
        public int Puertas { get; }

        
        public Coche(string marca, string modelo, int anio, int puertas)
            : base(marca, modelo, anio)
        {
            Puertas = puertas;
        }

        
        public override void MostrarInfo()
        {
            base.MostrarInfo();                          
            Console.WriteLine($"Puertas: {Puertas}");    
        }

    }
}
