// Ejercicio C1_C2_05 - Informe de una carpeta
namespace Ejercicio_C1_C2_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Preparación (dada por el profesor): crea la estructura de prueba
            string raiz = "instituto";
            if (Directory.Exists(raiz))
                Directory.Delete(raiz, recursive: true);

            Dictionary<string, int> ficheros = new Dictionary<string, int>
            {
                { Path.Combine("1DAM", "programacion.txt"), 120 },
                { Path.Combine("1DAM", "bases_datos.txt"), 80 },
                { Path.Combine("1DAM", "horario.pdf"), 300 },
                { Path.Combine("2DAM", "acceso_datos.txt"), 150 },
                { Path.Combine("2DAM", "proyectos", "tfc.pdf"), 900 },
                { Path.Combine("2DAM", "proyectos", "notas.csv"), 60 },
                { "normas.pdf", 200 }
            };
            foreach (var par in ficheros)
            {
                string ruta = Path.Combine(raiz, par.Key);
                Directory.CreateDirectory(Path.GetDirectoryName(ruta));
                File.WriteAllText(ruta, new string('x', par.Value));
            }

            // 1) Subcarpetas
            Console.WriteLine("Subcarpetas:");
            foreach (string carpeta in Directory.EnumerateDirectories(raiz, "*", SearchOption.AllDirectories).OrderBy(c => c))
                Console.WriteLine($"  {Path.GetRelativePath(raiz, carpeta)}");

            // 2) Ficheros con ruta relativa y tamaño
            Console.WriteLine();
            Console.WriteLine("Ficheros:");
            int total = 0;
            long bytesTotales = 0;
            FileInfo masGrande = null;

            foreach (string ruta in Directory.EnumerateFiles(raiz, "*", SearchOption.AllDirectories).OrderBy(r => r))
            {
                FileInfo info = new FileInfo(ruta);
                Console.WriteLine($"  {Path.GetRelativePath(raiz, ruta)} ({info.Length} bytes)");

                total++;
                bytesTotales += info.Length;
                if (masGrande == null || info.Length > masGrande.Length)
                    masGrande = info;
            }

            // 3, 4 y 5) Totales, el más grande y cuántos PDF
            Console.WriteLine();
            Console.WriteLine($"Total: {total} ficheros, {bytesTotales} bytes");
            Console.WriteLine($"Más grande: {masGrande.Name} ({masGrande.Length} bytes)");
            int pdfs = Directory.EnumerateFiles(raiz, "*.pdf", SearchOption.AllDirectories).Count();
            Console.WriteLine($"Ficheros PDF: {pdfs}");

            // Reto: tamaño de cada subcarpeta directa
            Console.WriteLine();
            foreach (string carpeta in Directory.EnumerateDirectories(raiz).OrderBy(c => c))
            {
                long tam = 0;
                foreach (string f in Directory.EnumerateFiles(carpeta, "*", SearchOption.AllDirectories))
                    tam += new FileInfo(f).Length;
                Console.WriteLine($"{Path.GetFileName(carpeta)}: {tam} bytes");
            }
        }
    }
}
