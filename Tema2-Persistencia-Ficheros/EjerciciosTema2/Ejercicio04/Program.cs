// Ejercicio 04 - Lector robusto de configuración
namespace Ejercicio04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creamos un fichero que sí existe para la prueba
            File.WriteAllText("config.txt", "modo=oscuro");

            Console.WriteLine($"config.txt -> {LeerConfiguracion("config.txt")}");
            Console.WriteLine($"no_existe.txt -> {LeerConfiguracion("no_existe.txt")}");
        }

        static string LeerConfiguracion(string ruta)
        {
            try
            {
                return File.ReadAllText(ruta);
            }
            catch (FileNotFoundException)
            {
                // Si no existe devolvemos un valor por defecto
                return "modo=normal";
            }
            catch (IOException ex)
            {
                // Cualquier otro error de E/S: avisamos y relanzamos
                Console.WriteLine($"Error al leer {ruta}: {ex.Message}");
                throw;
            }
        }
    }
}
