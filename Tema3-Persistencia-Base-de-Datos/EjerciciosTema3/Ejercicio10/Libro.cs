namespace Ejercicio10
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Disponible { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Titulo} ({(Disponible ? "disponible" : "prestado")})";
        }
    }
}
