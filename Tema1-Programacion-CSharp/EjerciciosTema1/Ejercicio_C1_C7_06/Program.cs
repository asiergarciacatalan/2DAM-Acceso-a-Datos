// Ejercicio C1_C7_06 - Laboratorio de números
namespace Ejercicio_C1_C7_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] menu = { "1) Serie de Fibonacci", "2) Números primos hasta N", "3) Secuencia de Collatz", "4) Salir" };
            int consultas = 0;
            int opcion;

            do
            {
                Console.WriteLine();
                Console.WriteLine("=== LABORATORIO DE NÚMEROS ===");
                foreach (string linea in menu)
                    Console.WriteLine(linea);

                Console.Write("Elige una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Escribe un número.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                    {
                        Console.Write("¿Cuántos términos (1-50)? ");
                        if (!int.TryParse(Console.ReadLine(), out int n) || n < 1 || n > 50)
                        {
                            Console.WriteLine("Tiene que estar entre 1 y 50.");
                            break;
                        }
                        long a = 0, b = 1;   // long: los términos grandes no caben en int
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write(a + " ");
                            long siguiente = a + b;
                            a = b;
                            b = siguiente;
                        }
                        Console.WriteLine();
                        consultas++;
                        break;
                    }

                    case 2:
                    {
                        Console.Write("¿Hasta qué número (2-1000)? ");
                        if (!int.TryParse(Console.ReadLine(), out int n) || n < 2 || n > 1000)
                        {
                            Console.WriteLine("Tiene que estar entre 2 y 1000.");
                            break;
                        }
                        int total = 0;
                        for (int candidato = 2; candidato <= n; candidato++)
                        {
                            bool esPrimo = true;
                            for (int divisor = 2; divisor * divisor <= candidato; divisor++)
                            {
                                if (candidato % divisor == 0)
                                {
                                    esPrimo = false;
                                    break;      // ya sabemos que no es primo
                                }
                            }
                            if (!esPrimo)
                                continue;       // pasamos al siguiente candidato

                            Console.Write(candidato + " ");
                            total++;
                        }
                        Console.WriteLine();
                        Console.WriteLine($"Total: {total} primos.");
                        consultas++;
                        break;
                    }

                    case 3:
                    {
                        Console.Write("Número inicial (1-1000000): ");
                        if (!int.TryParse(Console.ReadLine(), out int inicial) || inicial < 1 || inicial > 1000000)
                        {
                            Console.WriteLine("Tiene que estar entre 1 y 1000000.");
                            break;
                        }
                        long valor = inicial;   // long: puede crecer mucho
                        long maximo = valor;
                        int pasos = 0;
                        while (valor != 1)
                        {
                            if (valor % 2 == 0)
                                valor = valor / 2;
                            else
                                valor = 3 * valor + 1;
                            pasos++;
                            if (valor > maximo)
                                maximo = valor;
                        }
                        Console.WriteLine($"Collatz({inicial}) llega a 1 en {pasos} pasos. Valor máximo alcanzado: {maximo}.");
                        consultas++;
                        break;
                    }

                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida: elige entre 1 y 4.");
                        break;
                }
            } while (opcion != 4);

            Console.WriteLine($"Has realizado {consultas} consultas. ¡Hasta luego!");
        }
    }
}
