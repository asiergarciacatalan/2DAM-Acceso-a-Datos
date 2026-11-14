// Ejercicio C1_C7_02 - Validador de fechas
namespace Ejercicio_C1_C7_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Año: ");
            if (!int.TryParse(Console.ReadLine(), out int anio) || anio <= 0)
            {
                Console.WriteLine("El año tiene que ser un número mayor que 0.");
                return;
            }

            Console.Write("Mes (1-12): ");
            if (!int.TryParse(Console.ReadLine(), out int mes) || mes < 1 || mes > 12)
            {
                Console.WriteLine("El mes tiene que estar entre 1 y 12.");
                return;
            }

            Console.Write("Día: ");
            if (!int.TryParse(Console.ReadLine(), out int dia))
            {
                Console.WriteLine("El día tiene que ser un número entero.");
                return;
            }

            // Bisiesto: divisible entre 4 y no entre 100, o divisible entre 400
            bool bisiesto = (anio % 4 == 0 && anio % 100 != 0) || anio % 400 == 0;

            string nombreMes = mes switch
            {
                1 => "enero", 2 => "febrero", 3 => "marzo", 4 => "abril",
                5 => "mayo", 6 => "junio", 7 => "julio", 8 => "agosto",
                9 => "septiembre", 10 => "octubre", 11 => "noviembre", _ => "diciembre"
            };

            int diasMes = mes switch
            {
                4 or 6 or 9 or 11 => 30,
                2 => bisiesto ? 29 : 28,
                _ => 31
            };

            string estacion = mes switch
            {
                12 or 1 or 2 => "invierno",
                3 or 4 or 5 => "primavera",
                6 or 7 or 8 => "verano",
                _ => "otoño"
            };

            Console.WriteLine();
            Console.WriteLine(bisiesto ? $"El año {anio} es bisiesto." : $"El año {anio} no es bisiesto.");
            Console.WriteLine($"El mes de {nombreMes} de {anio} tiene {diasMes} días.");

            if (dia >= 1 && dia <= diasMes)
            {
                Console.WriteLine($"La fecha {dia} de {nombreMes} de {anio} es válida.");
                Console.WriteLine($"Quedan {diasMes - dia} días para acabar el mes.");
                Console.WriteLine($"Estación aproximada: {estacion}.");
            }
            else
            {
                Console.WriteLine($"La fecha {dia}/{mes}/{anio} NO es válida: {nombreMes} solo tiene {diasMes} días.");
            }
        }
    }
}
