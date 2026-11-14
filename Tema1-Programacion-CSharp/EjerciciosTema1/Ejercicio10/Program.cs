// Ejercicio 10 - Reto: informe de alumnos con LINQ y excepciones
namespace Ejercicio10
{
    internal record Alumno(string Nombre, int Nota);

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Alumno> alumnos = new List<Alumno>
            {
                new Alumno("Ana", 9),
                new Alumno("Luis", 4),
                new Alumno("Marta", 7),
                new Alumno("Pedro", 3),
                new Alumno("Sara", 10),
                new Alumno("Iván", 6)
            };

            // Aprobados de mayor a menor nota
            List<string> aprobados = alumnos
                .Where(a => a.Nota >= 5)
                .OrderByDescending(a => a.Nota)
                .Select(a => a.Nombre)
                .ToList();
            Console.WriteLine($"Aprobados: {string.Join(", ", aprobados)}");

            // Nota media (con try/catch por si la lista está vacía)
            MostrarMedia(alumnos);
            MostrarMedia(new List<Alumno>());

            // Mejor nota
            Alumno mejor = alumnos.OrderByDescending(a => a.Nota).First();
            Console.WriteLine($"Mejor nota: {mejor.Nombre} con un {mejor.Nota}");

            // Validar notas
            try
            {
                ValidarNota(8);
                Console.WriteLine("La nota 8 es válida.");
                ValidarNota(15);
                Console.WriteLine("La nota 15 es válida.");   // no llega a ejecutarse
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void MostrarMedia(List<Alumno> alumnos)
        {
            try
            {
                double media = alumnos.Average(a => a.Nota);
                Console.WriteLine($"Nota media: {media:F2}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("No se puede calcular la media: la lista está vacía.");
            }
        }

        static void ValidarNota(int nota)
        {
            if (nota < 0 || nota > 10)
                throw new ArgumentException($"La nota {nota} no está entre 0 y 10.");
        }
    }
}
