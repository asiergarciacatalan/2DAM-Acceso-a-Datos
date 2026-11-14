// Ejercicio C4_03 - Chollos en XML
using System.Xml.Serialization;

namespace Ejercicio_C4_03
{
    public class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Coche>));

            // 1) Cargar coches.xml
            List<Coche> coches;
            using (StreamReader lector = new StreamReader("coches.xml"))
            {
                coches = (List<Coche>)serializador.Deserialize(lector);
            }
            Console.WriteLine($"Coches leídos: {coches.Count}");

            // 2) Chollos: 2018 o posterior, menos de 60.000 km y menos de 15.000 €
            List<Coche> chollos = coches
                .Where(c => c.Anio >= 2018 && c.Kilometros < 60000 && c.Precio < 15000)
                .OrderBy(c => c.Precio)
                .ToList();
            Console.WriteLine();
            Console.WriteLine($"Chollos encontrados: {chollos.Count}");

            // 3) Los 5 más baratos
            Console.WriteLine();
            Console.WriteLine("--- Los 5 más baratos ---");
            foreach (Coche c in chollos.Take(5))
                Console.WriteLine(c);

            // 4) Guardar chollos.xml
            using (StreamWriter escritor = new StreamWriter("chollos.xml"))
            {
                serializador.Serialize(escritor, chollos);
            }
            Console.WriteLine();
            Console.WriteLine($"Guardados {chollos.Count} chollos en chollos.xml");

            // 5) Volver a cargarlo
            List<Coche> releidos;
            using (StreamReader lector = new StreamReader("chollos.xml"))
            {
                releidos = (List<Coche>)serializador.Deserialize(lector);
            }
            Console.WriteLine($"Releídos {releidos.Count}. Primero: {releidos[0]}");
        }
    }
}
