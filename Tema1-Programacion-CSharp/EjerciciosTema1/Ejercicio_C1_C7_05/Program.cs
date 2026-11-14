// Ejercicio C1_C7_05 - Adivina el número
namespace Ejercicio_C1_C7_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MIN = 1;
            const int MAX = 100;
            const int MAX_INTENTOS = 7;

            int partidas = 0;
            int ganadas = 0;
            int mejorPartida = 0;   // mínimo de intentos en una partida ganada (0 = ninguna)
            string respuesta;

            do
            {
                partidas++;
                int secreto = Random.Shared.Next(MIN, MAX + 1);
                int intentos = 0;
                bool acertado = false;

                Console.WriteLine($"Partida {partidas}: he pensado un número entre {MIN} y {MAX}. Tienes {MAX_INTENTOS} intentos.");

                while (intentos < MAX_INTENTOS && !acertado)
                {
                    Console.Write($"Intento {intentos + 1}/{MAX_INTENTOS}: ");
                    if (!int.TryParse(Console.ReadLine(), out int numero))
                    {
                        Console.WriteLine("Eso no es un número (este intento no cuenta).");
                        continue;
                    }
                    if (numero < MIN || numero > MAX)
                    {
                        Console.WriteLine($"Tiene que estar entre {MIN} y {MAX} (este intento no cuenta).");
                        continue;
                    }

                    intentos++;
                    if (numero == secreto)
                        acertado = true;
                    else
                        Console.WriteLine(numero < secreto ? "Demasiado bajo." : "Demasiado alto.");
                }

                if (acertado)
                {
                    ganadas++;
                    if (mejorPartida == 0 || intentos < mejorPartida)
                        mejorPartida = intentos;

                    string valoracion = intentos switch
                    {
                        1 => "¡Increíble!",
                        2 or 3 => "Excelente",
                        4 or 5 => "Bien jugado",
                        _ => "Justito"
                    };
                    Console.WriteLine($"¡Correcto! Lo has adivinado en {intentos} intentos. {valoracion}");
                }
                else
                {
                    Console.WriteLine($"Se acabaron los intentos. El número era {secreto}.");
                }

                Console.Write("¿Otra partida? (s/n): ");
                respuesta = (Console.ReadLine() ?? "").Trim().ToLower();
                Console.WriteLine();
            } while (respuesta == "s");

            Console.WriteLine($"Has ganado {ganadas} de {partidas} partidas.");
            if (mejorPartida > 0)
                Console.WriteLine($"Tu mejor partida: {mejorPartida} intentos.");
        }
    }
}
