// Ejercicio C1_C7_04 - Cajero automático
namespace Ejercicio_C1_C7_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const decimal LIMITE_RETIRADA = 300m;
            decimal saldo = 1000m;
            int operaciones = 0;
            int opcion;

            string[] menu = { "1) Consultar saldo", "2) Ingresar dinero", "3) Retirar dinero", "4) Salir" };

            do
            {
                Console.WriteLine();
                Console.WriteLine("=== CAJERO AUTOMÁTICO ===");
                foreach (string linea in menu)
                    Console.WriteLine(linea);

                Console.Write("Elige una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida: escribe un número.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine($"Tu saldo es: {saldo:F2} €");
                        break;

                    case 2:
                    {
                        Console.Write("Importe a ingresar: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal importe) || importe <= 0)
                        {
                            Console.WriteLine("El importe tiene que ser un número mayor que 0.");
                        }
                        else
                        {
                            saldo += importe;
                            operaciones++;
                            Console.WriteLine($"Ingreso realizado. Nuevo saldo: {saldo:F2} €");
                        }
                        break;
                    }

                    case 3:
                    {
                        Console.Write("Importe a retirar: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal importe) || importe <= 0)
                        {
                            Console.WriteLine("El importe tiene que ser un número mayor que 0.");
                        }
                        else if (importe > LIMITE_RETIRADA)
                        {
                            Console.WriteLine($"El límite por operación es de {LIMITE_RETIRADA:F2} €.");
                        }
                        else if (importe > saldo)
                        {
                            Console.WriteLine("No tienes saldo suficiente.");
                        }
                        else
                        {
                            saldo -= importe;
                            operaciones++;
                            Console.WriteLine($"Retirada realizada. Nuevo saldo: {saldo:F2} €");
                        }
                        break;
                    }

                    case 4:
                        Console.WriteLine("Gracias por usar el cajero.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida: elige entre 1 y 4.");
                        break;
                }
            } while (opcion != 4);

            Console.WriteLine($"Operaciones realizadas: {operaciones}. Saldo final: {saldo:F2} €");
        }
    }
}
