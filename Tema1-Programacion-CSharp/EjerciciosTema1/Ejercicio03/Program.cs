// Ejercicio 03 - Tabla de multiplicar y suma de pares
namespace Ejercicio03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1) for: tabla de multiplicar
            Console.Write("Número para la tabla de multiplicar: ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("Eso no es un número.");
                return;
            }
            for (int i = 1; i <= 10; i++)
                Console.WriteLine($"{numero} x {i} = {numero * i}");

            // 2) while: suma de los pares entre 1 y 100
            int suma = 0;
            int n = 1;
            while (n <= 100)
            {
                if (n % 2 == 0)
                    suma += n;
                n++;
            }
            Console.WriteLine($"Suma de los pares entre 1 y 100: {suma}");

            // 3) do-while: menú que se repite hasta elegir 3
            string opcion;
            do
            {
                Console.Write("Elige una opción (1-3): ");
                opcion = Console.ReadLine();
                if (opcion == "1" || opcion == "2")
                    Console.WriteLine($"Has elegido la opción {opcion}.");
                else if (opcion != "3")
                    Console.WriteLine("Opción no válida.");
            } while (opcion != "3");
            Console.WriteLine("Saliendo...");
        }
    }
}
