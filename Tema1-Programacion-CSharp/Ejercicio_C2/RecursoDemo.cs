using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_C2
{
    public class RecursoDemo : IDisposable
    {
        private readonly string Nombre;
        public RecursoDemo(string nombre)
        {
            this.Nombre = nombre;
            Console.WriteLine(nombre);
        }
        public void Usar()
        {
            Console.WriteLine($"{Nombre},trabajando...");



        }
        public void Dispose()
        {
            Console.WriteLine($"{Nombre},liberando recursos...");

        }
    }
}
