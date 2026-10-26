using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10._2
{
    public class EmpleadoFijo : Empleado
    {
        public decimal SueldoBase { get; }
        public decimal Complemento { get; }

        public EmpleadoFijo(string nombre, decimal sueldoBase, decimal complemento)
            : base(nombre)
        {
            SueldoBase = sueldoBase;
            Complemento = complemento;
        }

        public override decimal CalcularSueldo() => SueldoBase + Complemento;
    }
}
