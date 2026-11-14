// Ejercicio 09 - record Punto con sobrecarga de operadores
namespace Ejercicio09
{
    internal record Punto(double X, double Y)
    {
        // Sumar dos puntos coordenada a coordenada
        public static Punto operator +(Punto a, Punto b)
        {
            return new Punto(a.X + b.X, a.Y + b.Y);
        }
        // El == no hace falta escribirlo: el record ya compara por valor
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Punto p1 = new Punto(1, 2);
            Punto p2 = new Punto(3, 4);

            Punto suma = p1 + p2;
            Console.WriteLine($"p1 + p2 = {suma}");   // ToString() automático del record

            Punto p3 = new Punto(1, 2);
            Console.WriteLine($"p1 == p3: {p1 == p3}");   // true: mismos valores

            Punto p4 = p1 with { X = 5 };   // copia cambiando solo la X
            Console.WriteLine($"p4 = {p4}");
        }
    }
}
