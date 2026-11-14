// Ejercicio 03 - Libreta de notas en texto plano
namespace Ejercicio03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ruta = "notas.txt";

            // 1 y 2) Pedir alumnos y notas hasta escribir "fin"
            while (true)
            {
                Console.Write("Nombre del alumno (o 'fin'): ");
                string nombre = Console.ReadLine();
                if (nombre == null || nombre.ToLower() == "fin")
                    break;

                Console.Write("Nota: ");
                string nota = Console.ReadLine();

                // AppendAllText añade al final sin borrar lo que había
                File.AppendAllText(ruta, $"{nombre},{nota}{Environment.NewLine}");
            }

            // 3) Leer el fichero línea a línea
            if (!File.Exists(ruta))
            {
                Console.WriteLine("Todavía no hay notas guardadas.");
                return;
            }

            Console.WriteLine("\nNotas registradas:");
            int numero = 1;
            foreach (string linea in File.ReadLines(ruta))
            {
                Console.WriteLine($"{numero}. {linea}");
                numero++;
            }
        }
    }
}
