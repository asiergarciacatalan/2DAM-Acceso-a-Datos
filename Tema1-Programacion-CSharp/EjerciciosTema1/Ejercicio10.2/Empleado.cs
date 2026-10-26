using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10._2
{
    public abstract class Empleado
    {
        public string Nombre { get; }

        protected Empleado(string nombre)   
        {
            Nombre = nombre;
        }

        
        public abstract decimal CalcularSueldo();

        
        public void MostrarNomina()
        {
            Console.WriteLine($"{Nombre}: {CalcularSueldo():F2} €");
        }
    }
}
