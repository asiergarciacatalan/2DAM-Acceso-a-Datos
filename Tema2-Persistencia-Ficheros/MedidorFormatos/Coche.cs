namespace MedidorFormatos
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

        // hace falta para el JSON y el XML
        public Coche() { }

        public Coche(int id, string marca, string modelo, int anio, string combustible, string color, int kilometros, int precio)
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
            return Id + " " + Marca + " " + Modelo + " " + Anio + " " + Combustible + " " + Color + " " + Kilometros + "km " + Precio + "$";
        }
    }
}
