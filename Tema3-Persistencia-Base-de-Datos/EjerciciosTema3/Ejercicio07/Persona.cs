namespace Ejercicio07
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Nombre} ({Edad} años)";
        }
    }
}
