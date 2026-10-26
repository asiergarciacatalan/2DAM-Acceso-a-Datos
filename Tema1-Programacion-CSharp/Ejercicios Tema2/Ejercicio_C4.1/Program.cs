using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_C4._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Coche> coches = LeerCsv("coches.csv");
            foreach (Coche c in coches)
            {

            }
            string[] combustibles = { "Gasolina", "Diesel", "Hibrido", "Electrico", "GLP" };
            int Gasolina = 0, Diesel = 0, Hibrido = 0, Electrico = 0, GLP = 0;

            if (coches.Count > 0)
            {
                foreach (Coche c in coches)
                {
                    switch (c.Combustible)
                    {
                        case "Gasolina":
                            Gasolina++;
                            break;
                        case "Diesel":
                            Diesel++;
                            break;
                        case "Hibrido":
                            Hibrido++;
                            break;
                        case "Electrico":
                            Electrico++;
                            break;
                        case "GLP":
                            GLP++;
                            break;
                    }
                }
            }
            Console.WriteLine("Gasolina: {0}", Gasolina);
            Console.WriteLine("Diesel: {0}", Diesel);
            Console.WriteLine("Hibrido: {0}", Hibrido);
            Console.WriteLine("Electrico: {0}", Electrico);
            Console.WriteLine("GLP: {0}", GLP);



            double preciomedio = coches.Average(c => c.Precio);
            Console.WriteLine("Precio medio: {0}", preciomedio);


            List<Coche> cochesElectricos = coches
                .Where(c => c.Combustible == "Electrico")
                .OrderBy(c => c.Precio)
                .ToList();

            string rutaElectricos = "coches_electricos.csv";
            EscribirCsv(rutaElectricos, cochesElectricos);
            Console.WriteLine();
            Console.WriteLine($"Exportados {cochesElectricos.Count} coches a {rutaElectricos}");

            List<Coche> releidos = LeerCsv(rutaElectricos);
            Console.WriteLine();
            Console.WriteLine($"Releidos {releidos.Count} coches de {rutaElectricos}");

            Console.WriteLine($"Mas barato: {releidos.First()}");
            Console.WriteLine($"Mas caro: {releidos.Last()}");

        }






            public static List<Coche> LeerCsv(string ruta)
        {
            List<Coche> coches = new List<Coche>();



            using (StreamReader lector = new StreamReader(ruta))


            {
                string linea = lector.ReadLine();   // descarta la cabecera
                while ((linea = lector.ReadLine()) != null)
                {

                    string[] campos = linea.Split(';');
                    coches.Add(new Coche(int.Parse(campos[0]), campos[1], campos[2], int.Parse(campos[3]), campos[4], campos[5], int.Parse(campos[6]), int.Parse(campos[7])));

                }
            }
            return coches;
        }
        public static void EscribirCsv(string ruta, List<Coche> coches)
        {
            using (StreamWriter escritor = new StreamWriter(ruta))
            {
                escritor.WriteLine("Id;Marca;Modelo;Anio;Combustible;Color;Kilometros;Precio");
                foreach (Coche c in coches)
                {
                    escritor.WriteLine($"{c.Id};{c.Marca};{c.Modelo};{c.Anio};{c.Combustible};{c.Color};{c.Kilometros};{c.Precio}");
                }
            }

        }


    }

}

  

