using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10._2
{
    public class Empleadoporhoras : Empleado
    {
        public int Horas { get; }
        public decimal PrecioHora { get; }

        public Empleadoporhoras(string nombre, int horas, decimal precioHora)
            : base(nombre)
        {
            Horas = horas;
            PrecioHora = precioHora;
        }

        public override decimal CalcularSueldo() => Horas * PrecioHora;
    }
}
