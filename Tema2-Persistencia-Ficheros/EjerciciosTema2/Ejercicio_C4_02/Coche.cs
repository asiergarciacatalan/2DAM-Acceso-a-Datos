namespace Ejercicio_C4_02
{
    public class Coche
    {
        public int Id { get; set; }
        public string Marca { get; set; } = "";
        public string Modelo { get; set; } = "";
        public int Anio { get; set; }
        public string Combustible { get; set; } = "";
        public string Color { get; set; } = "";
        public int Kilometros { get; set; }
        public int Precio { get; set; }

        // Constructor vacío: lo necesitan JsonSerializer y XmlSerializer
        public Coche() { }

        public Coche(int id, string marca, string modelo, int anio, string combustible,
                     string color, int kilometros, int precio)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            Combustible = combustible;
            Color = color;
            Kilometros = kilometros;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"{Id} - {Marca} {Modelo} ({Anio}), {Combustible}, {Kilometros:N0} km, {Precio:N0} €";
        }
    }
}
