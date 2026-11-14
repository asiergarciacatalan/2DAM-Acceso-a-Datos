// Ejercicio C4_01 - Inventario en CSV
namespace Ejercicio_C4_01
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1) Leer el CSV
            List<Coche> coches = LeerCsv("coches.csv");
            Console.WriteLine($"Coches leídos: {coches.Count}");

            // 2) Coches por combustible
            Console.WriteLine();
            Console.WriteLine("--- Coches por combustible ---");
            string[] combustibles = { "Gasolina", "Diesel", "Hibrido", "Electrico", "GLP" };
            foreach (string combustible in combustibles)
            {
                int cantidad = coches.Count(c => c.Combustible == combustible);
                Console.WriteLine($"{combustible}: {cantidad}");
            }

            // 3) Precio medio
            Console.WriteLine();
            Console.WriteLine($"Precio medio: {coches.Average(c => c.Precio):N0} €");

            // 4) Exportar los eléctricos de más barato a más caro
            List<Coche> electricos = coches
                .Where(c => c.Combustible == "Electrico")
                .OrderBy(c => c.Precio)
                .ToList();
            EscribirCsv("coches_electricos.csv", electricos);
            Console.WriteLine();
            Console.WriteLine($"Exportados {electricos.Count} coches a coches_electricos.csv");

            // 5) Volver a leerlo con nuestro propio método
            List<Coche> releidos = LeerCsv("coches_electricos.csv");
            Console.WriteLine();
            Console.WriteLine($"Releídos {releidos.Count} coches de coches_electricos.csv");
            Console.WriteLine($"Más barato: {releidos.First()}");
            Console.WriteLine($"Más caro: {releidos.Last()}");
        }

        static List<Coche> LeerCsv(string ruta)
        {
            List<Coche> coches = new List<Coche>();
            using (StreamReader lector = new StreamReader(ruta))
            {
                string linea = lector.ReadLine();   // saltamos la cabecera
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] campos = linea.Split(';');
                    coches.Add(new Coche(int.Parse(campos[0]), campos[1], campos[2], int.Parse(campos[3]),
                                         campos[4], campos[5], int.Parse(campos[6]), int.Parse(campos[7])));
                }
            }
            return coches;
        }

        static void EscribirCsv(string ruta, List<Coche> coches)
        {
            using (StreamWriter escritor = new StreamWriter(ruta))
            {
                escritor.WriteLine("Id;Marca;Modelo;Anio;Combustible;Color;Kilometros;Precio");
                foreach (Coche c in coches)
                    escritor.WriteLine($"{c.Id};{c.Marca};{c.Modelo};{c.Anio};{c.Combustible};{c.Color};{c.Kilometros};{c.Precio}");
            }
        }
    }
}
