// Ejercicio C4_02 - Catálogo en JSON
using System.Text.Json;

namespace Ejercicio_C4_02
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1) Cargar el JSON
            string json = File.ReadAllText("coches.json");
            List<Coche> coches = JsonSerializer.Deserialize<List<Coche>>(json);
            if (coches == null)
            {
                Console.WriteLine("No se ha podido leer coches.json");
                return;
            }
            Console.WriteLine($"Coches leídos: {coches.Count}");

            // 2) El más caro
            Coche masCaro = coches.OrderByDescending(c => c.Precio).First();
            Console.WriteLine();
            Console.WriteLine($"Más caro: {masCaro}");

            // 3) Coches de 2020 o posteriores y su media de km
            List<Coche> recientes = coches.Where(c => c.Anio >= 2020).ToList();
            Console.WriteLine();
            Console.WriteLine($"Coches de 2020 o posteriores: {recientes.Count}");
            Console.WriteLine($"Media de kilómetros: {recientes.Average(c => c.Kilometros):N0} km");

            // 4) Guardar los Toyota con sangría y compacto
            List<Coche> toyotas = coches.Where(c => c.Marca == "Toyota").ToList();
            JsonSerializerOptions opciones = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText("toyota.json", JsonSerializer.Serialize(toyotas, opciones));
            File.WriteAllText("toyota_compacto.json", JsonSerializer.Serialize(toyotas));

            long conSangria = new FileInfo("toyota.json").Length;
            long compacto = new FileInfo("toyota_compacto.json").Length;
            double porcentaje = (conSangria - compacto) * 100.0 / compacto;

            Console.WriteLine();
            Console.WriteLine($"Toyota: {toyotas.Count} coches");
            Console.WriteLine($"toyota.json (con sangría): {conSangria:N0} bytes");
            Console.WriteLine($"toyota_compacto.json (compacto): {compacto:N0} bytes");
            Console.WriteLine($"El formato con sangría ocupa un {porcentaje:F0} % más");

            // 5) Volver a cargar toyota.json
            List<Coche> releidos = JsonSerializer.Deserialize<List<Coche>>(File.ReadAllText("toyota.json"));
            string resultado = releidos.Count == toyotas.Count ? "OK" : "ERROR";
            Console.WriteLine();
            Console.WriteLine($"Releídos {releidos.Count} coches de toyota.json: {resultado}");
        }
    }
}
