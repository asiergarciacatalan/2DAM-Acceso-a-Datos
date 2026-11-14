// Ejercicio 07 - Clase Libro con propiedades
namespace Ejercicio07
{
    internal class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Paginas { get; set; }

        // Propiedad de solo lectura
        public bool EsLargo => Paginas > 300;

        public Libro(string titulo, string autor, int paginas)
        {
            Titulo = titulo;
            Autor = autor;
            Paginas = paginas;
        }

        public void MostrarFicha()
        {
            Console.WriteLine($"{Titulo} - {Autor} - {Paginas} páginas (largo: {EsLargo})");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Libro> libros = new List<Libro>
            {
                new Libro("El Quijote", "Cervantes", 863),
                new Libro("Rebelión en la granja", "George Orwell", 152),
                new Libro("Cien años de soledad", "García Márquez", 471)
            };

            foreach (Libro libro in libros)
                libro.MostrarFicha();
        }
    }
}
