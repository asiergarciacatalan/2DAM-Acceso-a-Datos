using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10._1
{
    public class Vehiculo
    {
        public string Marca { get; }
        public string Modelo { get; }
        public int Anio { get; }

        public Vehiculo(string marca, string modelo, int anio)
        {
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
        }

        
        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Marca: {Marca} · Modelo: {Modelo} · Año: {Anio}");
        }

    }
}
