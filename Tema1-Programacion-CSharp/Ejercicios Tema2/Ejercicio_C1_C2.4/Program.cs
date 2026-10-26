using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_C1_C2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string descargas = "descargas";

            if (Directory.Exists(descargas))
            {
                Directory.Delete(descargas, recursive: true);   // borra la carpeta y todo su contenido
            }
            Directory.CreateDirectory(descargas);

            string[] ficherosPrueba = { "apuntes.pdf", "foto1.jpg", "practica.zip",
                            "foto2.jpg", "temp1.tmp", "examen.pdf", "temp2.tmp" };
            foreach (string nombre in ficherosPrueba)
            {
                File.WriteAllText(Path.Combine(descargas, nombre), $"Contenido de {nombre}");
            }



            int cantidadFicheros = Directory.GetFiles(descargas).Length;
            Console.WriteLine($"Cantidad de ficheros en {descargas}: {cantidadFicheros}");

            foreach (string fichero in Directory.GetFiles(descargas))
            {
                if (Path.GetExtension(fichero) == ".tmp")
                {
                    File.Delete(fichero);
                    Console.WriteLine($"Se eliminó el fichero: {fichero}");
                }
            }
            String[] ficherosRestantes = Directory.GetFiles(descargas);
            Array.Sort(ficherosRestantes);
            foreach (string ruta in ficherosRestantes)
            {
                string extension = Path.GetExtension(ruta);
                string rutaDestino = Path.Combine(descargas, extension);
                Directory.CreateDirectory(rutaDestino);
                string nombreArchivo = Path.GetFileName(ruta);
                File.Move(ruta, Path.Combine(rutaDestino, nombreArchivo));
                Console.WriteLine($"Se movió el fichero {nombreArchivo} a la carpeta {rutaDestino}");

            }
            string copia = "copia_pdf";
            Directory.CreateDirectory(copia);
            string[] pdfFiles = Directory.GetFiles(descargas, "*.pdf");
            foreach (string ruta in pdfFiles)
            {
                File.Copy(ruta, Path.Combine(copia, Path.GetFileName(ruta)), overwrite: true);

            }
            Console.WriteLine($"Se copiaron {pdfFiles.Length} ficheros PDF a la carpeta {copia}");
            Console.WriteLine();

            Console.WriteLine($"Cantidad de ficheros en la carpeta {descargas}: {Directory.GetFiles(descargas).Length}");
            string[] subcarpetas = Directory.GetDirectories(descargas);
            Array.Sort(subcarpetas);
            foreach (string subcarpeta in subcarpetas)
            {
                Console.WriteLine($"Cantidad de ficheros en la carpeta {subcarpeta}: {Directory.GetFiles(subcarpeta).Length}");
            }
            Console.WriteLine();
            try
            {
                Directory.Delete(descargas, recursive: true);
                Console.WriteLine($"Se eliminó la carpeta {descargas} y todo su contenido");

            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al eliminar la carpeta {descargas}: {ex.Message}");
            }
        }
    }
}
