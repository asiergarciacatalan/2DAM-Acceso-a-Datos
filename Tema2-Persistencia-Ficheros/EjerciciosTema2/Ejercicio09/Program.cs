// Ejercicio 09 - Acceso aleatorio a un fichero de alumnos
namespace Ejercicio09
{
    internal class Program
    {
        const int TAM_NOMBRE = 20;                       // caracteres del nombre
        const int TAM_REGISTRO = 4 + TAM_NOMBRE;         // int (4 bytes) + 20 bytes de nombre
        // Ojo: nombres sin tildes, así cada carácter ocupa exactamente 1 byte

        static void Main(string[] args)
        {
            string ruta = "alumnos.bin";

            using (BinaryWriter escritor = new BinaryWriter(File.Open(ruta, FileMode.Create)))
            {
                EscribirAlumno(escritor, 1, "Ana");
                EscribirAlumno(escritor, 2, "Luis");
                EscribirAlumno(escritor, 3, "Marta");
                EscribirAlumno(escritor, 4, "Pedro");
                EscribirAlumno(escritor, 5, "Sara");
            }
            Console.WriteLine($"5 alumnos guardados (cada registro ocupa {TAM_REGISTRO} bytes).");

            // Leemos directamente la posición 3 (índice 2) sin leer los anteriores
            string alumno = LeerAlumnoEnPosicion(ruta, 2);
            Console.WriteLine($"Alumno en la posición 3: {alumno}");
        }

        static void EscribirAlumno(BinaryWriter w, int id, string nombre)
        {
            w.Write(id);
            // PadRight rellena con espacios hasta 20; Write(char[]) no añade longitud delante
            w.Write(nombre.PadRight(TAM_NOMBRE).Substring(0, TAM_NOMBRE).ToCharArray());
        }

        static string LeerAlumnoEnPosicion(string ruta, int indice)
        {
            using (FileStream fichero = new FileStream(ruta, FileMode.Open))
            using (BinaryReader lector = new BinaryReader(fichero))
            {
                fichero.Seek(indice * TAM_REGISTRO, SeekOrigin.Begin);   // saltamos al registro
                int id = lector.ReadInt32();
                string nombre = new string(lector.ReadChars(TAM_NOMBRE)).TrimEnd();
                return $"id={id}, nombre={nombre}";
            }
        }
    }
}
