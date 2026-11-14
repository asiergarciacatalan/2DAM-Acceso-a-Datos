namespace Ejercicio_C1_C2_02
{
    internal class RecursoDemo : IDisposable
    {
        private string nombre;

        public RecursoDemo(string nombre)
        {
            this.nombre = nombre;
            Console.WriteLine($"[{nombre}] Abierto");
        }

        public void Usar()
        {
            Console.WriteLine($"[{nombre}] Trabajando...");
        }

        public void Dispose()
        {
            Console.WriteLine($"[{nombre}] Cerrado (Dispose)");
        }
    }
}
