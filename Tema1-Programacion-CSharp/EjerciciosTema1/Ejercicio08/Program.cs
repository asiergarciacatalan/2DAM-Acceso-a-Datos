// Ejercicio 08 - Herencia: Empleado y Encargado
namespace Ejercicio08
{
    internal class Empleado
    {
        public string Nombre { get; set; }
        public decimal SalarioBase { get; set; }

        public Empleado(string nombre, decimal salarioBase)
        {
            Nombre = nombre;
            SalarioBase = salarioBase;
        }

        public virtual decimal CalcularSalario()
        {
            return SalarioBase;
        }
    }

    internal class Encargado : Empleado
    {
        public decimal Plus { get; set; }

        public Encargado(string nombre, decimal salarioBase, decimal plus) : base(nombre, salarioBase)
        {
            Plus = plus;
        }

        public override decimal CalcularSalario()
        {
            return SalarioBase + Plus;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> plantilla = new List<Empleado>
            {
                new Empleado("Ana", 1500m),
                new Encargado("Luis", 1600m, 400m),
                new Empleado("Marta", 1450m),
                new Encargado("Pedro", 1700m, 350m)
            };

            // Polimorfismo: cada uno usa su propio CalcularSalario()
            foreach (Empleado e in plantilla)
                Console.WriteLine($"{e.Nombre}: {e.CalcularSalario():F2} €");

            List<Encargado> encargados = plantilla.OfType<Encargado>().ToList();
            Console.WriteLine($"Hay {encargados.Count} encargados.");
        }
    }
}
