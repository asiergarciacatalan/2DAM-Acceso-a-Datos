// Ejercicio C1_C2_02 - ¿Cuándo se cierra el fichero?
namespace Ejercicio_C1_C2_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ----- Parte A -----
            Console.WriteLine("--- Parte A ---");
            using (RecursoDemo recurso = new RecursoDemo("Bloque"))
            {
                recurso.Usar();
            }
            Console.WriteLine("Después del bloque using");
            Console.WriteLine();

            try
            {
                using (RecursoDemo recurso = new RecursoDemo("Excepción"))
                {
                    recurso.Usar();
                    throw new InvalidOperationException("Fallo a propósito");
                }
            }
            catch (InvalidOperationException ex)
            {
                // Dispose() ya se ha llamado antes de llegar aquí
                Console.WriteLine($"Capturada: {ex.Message}");
            }

            // ----- Parte B -----
            Console.WriteLine();
            Console.WriteLine("--- Parte B ---");
            using (StreamWriter escritor = new StreamWriter("diario.txt"))
            {
                escritor.WriteLine("Lunes: empezamos el Tema 2");
                escritor.WriteLine("Martes: practicamos con System.IO");
                escritor.WriteLine("Miércoles: ya domino using");
            }

            using StreamReader lector = new StreamReader("diario.txt");   // using declaration
            Console.WriteLine("Contenido de diario.txt:");
            Console.WriteLine(lector.ReadToEnd());

            // Pregunta: si el StreamWriter no se cerrara (sin using ni Close), lo escrito
            // podría quedarse en el buffer sin llegar al disco, y al leerlo el fichero
            // saldría vacío o incompleto (y además seguiría bloqueado).
        }
    }
}
