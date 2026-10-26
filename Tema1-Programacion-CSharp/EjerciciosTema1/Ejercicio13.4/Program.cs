using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio13._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Alumno> alumnos = new List<Alumno>
            {
                new Alumno("Ana",   8.5),
                new Alumno("Luis",  4),
                new Alumno("Marta", 6.5),
                new Alumno("Pablo", 3.5),
                new Alumno("Lucía", 9),
                new Alumno("Jorge", 5),
                new Alumno("Sara",  7)
            };
            int aprobados = alumnos.Count(a => a.Nota >= 5);
            double media = alumnos.Average(a => a.Nota);
            double maxima = alumnos.Max(a => a.Nota);
            double minima = alumnos.Min(a => a.Nota);
            bool hayUnDiez = alumnos.Any(a => a.Nota == 10);        
            bool todosAlMenosTres = alumnos.All(a => a.Nota >= 3);  

            Console.WriteLine($"Aprobados: {aprobados} de {alumnos.Count}");
            Console.WriteLine($"Nota media: {media:F2}");
            Console.WriteLine($"Nota más alta: {maxima}");
            Console.WriteLine($"Nota más baja: {minima}");
            Console.WriteLine($"¿Alguien tiene un 10?: {hayUnDiez}");
            Console.WriteLine($"¿Todos tienen al menos un 3?: {todosAlMenosTres}");


            List<String>Ranking=alumnos
                 .Where(a => a.Nota >= 5)                  
                .OrderByDescending(a => a.Nota)           
                .Select(a => $"{a.Nombre} ({a.Nota})")    
                .ToList();
            Console.WriteLine($"Ranking de aprobados{string.Join("|",Ranking )}");

            List<String> suspensos = alumnos
                .Where(a => a.Nota < 5)
                .OrderBy(a => a.Nombre)
                .Select(a => a.Nombre)
                .ToList();
            Console.WriteLine($"Suspensos: {string.Join(", ", suspensos)}");

        }
    }
}
