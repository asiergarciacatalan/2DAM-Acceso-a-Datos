// Ejercicio 10 - Reto: agenda con búsqueda por índice
using System.Text.Json;

namespace Ejercicio10
{
    public class ContactoAgenda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public ContactoAgenda(int id, string nombre, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }
    }

    internal class Program
    {
        const int TAM_NOMBRE = 20;
        const int TAM_TELEFONO = 15;
        const int TAM_REGISTRO = 4 + TAM_NOMBRE + TAM_TELEFONO;   // 39 bytes (sin tildes)

        static void Main(string[] args)
        {
            string rutaBin = "agenda.bin";
            string rutaJson = "agenda.json";

            List<ContactoAgenda> contactos = new List<ContactoAgenda>
            {
                new ContactoAgenda(10, "Ana Garcia", "600111222"),
                new ContactoAgenda(20, "Luis Perez", "600333444"),
                new ContactoAgenda(30, "Marta Ruiz", "600555666"),
                new ContactoAgenda(40, "Pedro Gomez", "600777888"),
                new ContactoAgenda(50, "Sara Lopez", "600999000")
            };

            // 1) Crear la agenda
            CrearAgenda(rutaBin, contactos);
            Console.WriteLine($"Agenda creada con {contactos.Count} contactos.");

            // 2) Buscar por id
            ContactoAgenda encontrado = BuscarPorId(rutaBin, 30, contactos.Count);
            if (encontrado != null)
                Console.WriteLine($"Encontrado id 30: {encontrado.Nombre} - {encontrado.Telefono}");

            ContactoAgenda noExiste = BuscarPorId(rutaBin, 99, contactos.Count);
            Console.WriteLine(noExiste == null ? "El id 99 no existe." : "Encontrado id 99");

            // 3) Exportar a JSON
            ExportarAJson(rutaBin, rutaJson, contactos.Count);
            Console.WriteLine($"Agenda exportada a {rutaJson}:");
            Console.WriteLine(File.ReadAllText(rutaJson));
        }

        static void CrearAgenda(string ruta, List<ContactoAgenda> contactos)
        {
            using (BinaryWriter w = new BinaryWriter(File.Open(ruta, FileMode.Create)))
            {
                foreach (ContactoAgenda c in contactos)
                {
                    w.Write(c.Id);
                    w.Write(c.Nombre.PadRight(TAM_NOMBRE).Substring(0, TAM_NOMBRE).ToCharArray());
                    w.Write(c.Telefono.PadRight(TAM_TELEFONO).Substring(0, TAM_TELEFONO).ToCharArray());
                }
            }
        }

        // Lee el registro que está en la posición 'indice'
        static ContactoAgenda LeerRegistro(FileStream fichero, BinaryReader lector, int indice)
        {
            fichero.Seek(indice * TAM_REGISTRO, SeekOrigin.Begin);
            int id = lector.ReadInt32();
            string nombre = new string(lector.ReadChars(TAM_NOMBRE)).TrimEnd();
            string telefono = new string(lector.ReadChars(TAM_TELEFONO)).TrimEnd();
            return new ContactoAgenda(id, nombre, telefono);
        }

        static ContactoAgenda BuscarPorId(string ruta, int idBuscado, int totalRegistros)
        {
            using (FileStream fichero = new FileStream(ruta, FileMode.Open))
            using (BinaryReader lector = new BinaryReader(fichero))
            {
                for (int i = 0; i < totalRegistros; i++)
                {
                    ContactoAgenda c = LeerRegistro(fichero, lector, i);
                    if (c.Id == idBuscado)
                        return c;
                }
            }
            return null;
        }

        static void ExportarAJson(string rutaBinaria, string rutaJson, int totalRegistros)
        {
            List<ContactoAgenda> todos = new List<ContactoAgenda>();
            using (FileStream fichero = new FileStream(rutaBinaria, FileMode.Open))
            using (BinaryReader lector = new BinaryReader(fichero))
            {
                for (int i = 0; i < totalRegistros; i++)
                    todos.Add(LeerRegistro(fichero, lector, i));
            }

            JsonSerializerOptions opciones = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(rutaJson, JsonSerializer.Serialize(todos, opciones));
        }
    }
}
