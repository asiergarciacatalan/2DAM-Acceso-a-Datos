// Ejercicio C1_C7_03 - Pirámide, dígitos y FizzBuzz
namespace Ejercicio_C1_C7_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ----- Parte A: pirámide con for anidados -----
            Console.Write("Altura de la pirámide (1-20): ");
            if (!int.TryParse(Console.ReadLine(), out int altura) || altura < 1 || altura > 20)
            {
                Console.WriteLine("La altura tiene que estar entre 1 y 20.");
                return;
            }

            for (int fila = 1; fila <= altura; fila++)
            {
                for (int i = 0; i < altura - fila; i++)
                    Console.Write(" ");
                for (int i = 0; i < 2 * fila - 1; i++)
                    Console.Write("*");
                Console.WriteLine();
            }

            // ----- Parte B: dígitos con while -----
            Console.WriteLine();
            Console.Write("Introduce un número entero positivo: ");
            if (!int.TryParse(Console.ReadLine(), out int numero) || numero <= 0)
            {
                Console.WriteLine("Tiene que ser un número entero positivo.");
                return;
            }

            int copia = numero;
            int cifras = 0;
            int suma = 0;
            long invertido = 0;   // long porque el inverso de un int grande no cabe en un int

            while (copia > 0)
            {
                int digito = copia % 10;
                cifras++;
                suma += digito;
                invertido = invertido * 10 + digito;
                copia = copia / 10;
            }

            Console.WriteLine($"{numero} tiene {cifras} dígitos y suman {suma}.");
            Console.WriteLine($"Invertido: {invertido}.");
            Console.WriteLine(invertido == numero ? "Es capicúa." : "No es capicúa.");

            // ----- Parte C: FizzBuzz -----
            Console.WriteLine();
            Console.WriteLine("FizzBuzz del 1 al 30:");
            for (int i = 1; i <= 30; i++)
            {
                if (i % 15 == 0)
                    Console.Write("FizzBuzz ");
                else if (i % 3 == 0)
                    Console.Write("Fizz ");
                else if (i % 5 == 0)
                    Console.Write("Buzz ");
                else
                    Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
