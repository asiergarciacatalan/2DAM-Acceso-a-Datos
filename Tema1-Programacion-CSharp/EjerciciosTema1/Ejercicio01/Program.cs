// Ejercicio 01 - Datos personales por consola
namespace Ejercicio01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Año de nacimiento: ");
            if (!int.TryParse(Console.ReadLine(), out int anioNacimiento))
            {
                Console.WriteLine("El año no es un número válido.");
                return;
            }

            Console.Write("Altura en metros (ej: 1,68): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal altura))
            {
                Console.WriteLine("La altura no es un número válido.");
                return;
            }

            int edad = DateTime.Now.Year - anioNacimiento;
            Console.WriteLine($"{nombre} tiene {edad} años y mide {altura} m.");
        }
    }
}
