// Ejercicio 06 - Agenda de contactos en JSON
using System.Text.Json;

namespace Ejercicio06
{
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public Contacto() { }   // necesario para deserializar

        public Contacto(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string ruta = "contactos.json";
            JsonSerializerOptions opciones = new JsonSerializerOptions { WriteIndented = true };

            // 2) Crear y guardar
            List<Contacto> contactos = new List<Contacto>
            {
                new Contacto("Ana", "600111222"),
                new Contacto("Luis", "600333444"),
                new Contacto("Marta", "600555666"),
                new Contacto("Pedro", "600777888")
            };
            File.WriteAllText(ruta, JsonSerializer.Serialize(contactos, opciones));
            Console.WriteLine($"Guardados {contactos.Count} contactos en {ruta}");

            // 3) Cargar
            List<Contacto> cargados = JsonSerializer.Deserialize<List<Contacto>>(File.ReadAllText(ruta));
            Console.WriteLine($"Cargados {cargados.Count} contactos:");
            foreach (Contacto c in cargados)
                Console.WriteLine($"  {c.Nombre} - {c.Telefono}");

            // 4) Añadir uno y volver a guardar
            cargados.Add(new Contacto("Sara", "600999000"));
            File.WriteAllText(ruta, JsonSerializer.Serialize(cargados, opciones));
            Console.WriteLine($"Añadido Sara. Ahora hay {cargados.Count} contactos en {ruta}");
        }
    }
}
