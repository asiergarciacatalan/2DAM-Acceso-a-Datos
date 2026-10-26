using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejecicio_C1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String dato = "datos";
            String clase = "2DAM";
            String archivo = "alumnos.csv";


            String ruta = Path.Combine(dato, clase, archivo);
            Console.WriteLine(Path.GetFileName(ruta));
            Console.WriteLine(Path.GetFileNameWithoutExtension(ruta));
            Console.WriteLine(Path.GetExtension(ruta));
            Console.WriteLine(Path.GetDirectoryName(ruta));
            String ruta2 = Path.ChangeExtension(ruta, ".json");
            Console.WriteLine(Path.GetFileName(ruta2));
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Path.GetFullPath(ruta));
            string[] rutas = { "foto.PNG", "notas.txt", "logo.gif", "informe.pdf", "playa.Jpg", "LEEME" };
            foreach(String rutita in rutas)
            {
                string extension= Path.GetExtension(rutita).ToLower();
                bool esImagen = extension == ".png" || extension == ".jpg" || extension == ".gif";

                Console.WriteLine($"{rutita} -> {(esImagen ? "imagen" : "no es imagen")}");
            }
        }
    }
}
