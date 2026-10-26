using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_C2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (RecursoDemo recurso = new RecursoDemo("Bloque"))
            {
                recurso.Usar();
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.WriteLine();
            try
            {
                using (RecursoDemo recurso = new RecursoDemo("Bloque"))
                {
                    recurso.Usar();
                    throw new Exception("Error en el bloque de código");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo una excepción: {ex.Message}");
            }
            Console.WriteLine();





            String rutaArchivo = "archivo.txt";
            using(StreamWriter escritor = new StreamWriter(rutaArchivo))
            {
                escritor.WriteLine("Hola, este es un ejemplo de escritura en un archivo.");
                escritor.WriteLine("Segunda línea del archivo.");
            }

            using(StreamReader lector = new StreamReader(rutaArchivo))
            {
                string contenido = lector.ReadToEnd();
                Console.WriteLine("Contenido del archivo:");
                Console.WriteLine(contenido);
            }
        }
    }
}
