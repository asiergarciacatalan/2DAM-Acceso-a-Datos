// Ejercicio 06 - Calculadora con métodos
namespace Ejercicio06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Sumar(1, 2, 3, 4, 5) = {Sumar(1, 2, 3, 4, 5)}");
            Console.WriteLine($"Sumar() = {Sumar()}");

            if (DividirSeguro(10, 2, out int resultado))
                Console.WriteLine($"10 / 2 = {resultado}");

            if (!DividirSeguro(10, 0, out resultado))
                Console.WriteLine("No se puede dividir entre 0.");

            Saludar("Ana");
            Saludar("Luis", "Buenos días");
            Saludar(saludo: "Buenas tardes", nombre: "Marta");   // argumentos nombrados
        }

        // params: acepta cualquier cantidad de números
        static int Sumar(params int[] numeros)
        {
            int total = 0;
            foreach (int n in numeros)
                total += n;
            return total;
        }

        // out: devuelve el resultado por el parámetro y true/false según si se pudo
        static bool DividirSeguro(int a, int b, out int resultado)
        {
            if (b == 0)
            {
                resultado = 0;
                return false;
            }
            resultado = a / b;
            return true;
        }

        // saludo tiene valor por defecto
        static void Saludar(string nombre, string saludo = "Hola")
        {
            Console.WriteLine($"{saludo}, {nombre}!");
        }
    }
}
