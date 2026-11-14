// Ejercicio 02 - Clasificador de notas
namespace Ejercicio02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduce una nota (0-10): ");
            if (!double.TryParse(Console.ReadLine(), out double nota))
            {
                Console.WriteLine("Eso no es un número.");
                return;
            }
            if (nota < 0 || nota > 10)
            {
                Console.WriteLine("La nota tiene que estar entre 0 y 10.");
                return;
            }

            // 1) Con if / else if
            string categoria1;
            if (nota >= 9)
                categoria1 = "Sobresaliente";
            else if (nota >= 7)
                categoria1 = "Notable";
            else if (nota >= 5)
                categoria1 = "Aprobado";
            else
                categoria1 = "Suspenso";
            Console.WriteLine($"Con if/else: {categoria1}");

            // 2) Lo mismo con switch expression
            string categoria2 = nota switch
            {
                >= 9 => "Sobresaliente",
                >= 7 => "Notable",
                >= 5 => "Aprobado",
                _ => "Suspenso"
            };
            Console.WriteLine($"Con switch:  {categoria2}");
        }
    }
}
