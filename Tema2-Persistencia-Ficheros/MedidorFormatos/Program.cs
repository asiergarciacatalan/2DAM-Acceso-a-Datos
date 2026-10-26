using System.Text.Json;
using System.Xml.Serialization;

namespace MedidorFormatos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // leo los 3 ficheros
            List<Coche> listaCsv = LeerCsv("coches.csv");
            List<Coche> listaJson = LeerJson("coches.json");
            List<Coche> coches = LeerXml("coches.xml");

            Console.WriteLine("CSV: " + listaCsv.Count + " coches");
            Console.WriteLine("JSON: " + listaJson.Count + " coches");
            Console.WriteLine("XML: " + coches.Count + " coches");
            Console.WriteLine();

            // creo la carpeta salida
            if (!Directory.Exists("salida"))
            {
                Directory.CreateDirectory("salida");
            }

            string csv = Path.Combine("salida", "coches.csv");
            string json = Path.Combine("salida", "coches.json");
            string xml = Path.Combine("salida", "coches.xml");

            // guardo el csv
            using (StreamWriter sw = new StreamWriter(csv))
            {
                sw.WriteLine("Id;Marca;Modelo;Anio;Combustible;Color;Kilometros;Precio");
                foreach (Coche c in coches)
                {
                    sw.WriteLine(c.Id + ";" + c.Marca + ";" + c.Modelo + ";" + c.Anio + ";" + c.Combustible + ";" + c.Color + ";" + c.Kilometros + ";" + c.Precio);
                }
            }

            // guardo el json
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;
            File.WriteAllText(json, JsonSerializer.Serialize(coches, opciones));

            // guardo el xml
            XmlSerializer serializer = new XmlSerializer(typeof(List<Coche>));
            using (StreamWriter sw = new StreamWriter(xml))
            {
                serializer.Serialize(sw, coches);
            }

            // tamaños
            long tamCsv = new FileInfo(csv).Length;
            long tamJson = new FileInfo(json).Length;
            long tamXml = new FileInfo(xml).Length;

            Console.WriteLine("Fichero       Bytes      MB");
            Console.WriteLine("coches.csv    " + tamCsv + "     " + Math.Round(tamCsv / 1024.0 / 1024.0, 2));
            Console.WriteLine("coches.json   " + tamJson + "    " + Math.Round(tamJson / 1024.0 / 1024.0, 2));
            Console.WriteLine("coches.xml    " + tamXml + "    " + Math.Round(tamXml / 1024.0 / 1024.0, 2));
            Console.WriteLine();

            Console.WriteLine("El JSON ocupa " + Math.Round((double)tamJson / tamCsv, 2) + " veces mas que el CSV");
            Console.WriteLine("El XML ocupa " + Math.Round((double)tamXml / tamCsv, 2) + " veces mas que el CSV");

            // cuanto ocupan solo los datos (sin etiquetas ni nada)
            long datos = 0;
            foreach (Coche c in coches)
            {
                string linea = c.Id + c.Marca + c.Modelo + c.Anio + c.Combustible + c.Color + c.Kilometros + c.Precio;
                datos = datos + linea.Length;
            }
            double porcentaje = (tamXml - datos) * 100.0 / tamXml;
            Console.WriteLine("En el XML el " + Math.Round(porcentaje, 1) + "% no son datos");
            Console.WriteLine();

            // vuelvo a leer lo que he guardado
            List<Coche> l1 = LeerCsv(csv);
            List<Coche> l2 = LeerJson(json);
            List<Coche> l3 = LeerXml(xml);
            Console.WriteLine("salida/coches.csv: " + l1.Count + " coches, sospechosos: " + Sospechosos(l1));
            Console.WriteLine("salida/coches.json: " + l2.Count + " coches, sospechosos: " + Sospechosos(l2));
            Console.WriteLine("salida/coches.xml: " + l3.Count + " coches, sospechosos: " + Sospechosos(l3));
            Console.WriteLine();

            // mi coche (soy el 7 -> 700)
            foreach (Coche c in coches)
            {
                if (c.Id == 700)
                {
                    Console.WriteLine("Mi coche: " + c);
                }
            }
            Console.WriteLine();

            // pruebas con los ficheros rotos
            Console.WriteLine("PRUEBAS");
            string[] ficheros = Directory.GetFiles("pruebas");
            foreach (string f in ficheros)
            {
                Console.WriteLine(Path.GetFileName(f));
                try
                {
                    List<Coche> lista;
                    string ext = Path.GetExtension(f);
                    if (ext == ".csv")
                    {
                        lista = LeerCsv(f);
                    }
                    else if (ext == ".json")
                    {
                        lista = LeerJson(f);
                    }
                    else
                    {
                        lista = LeerXml(f);
                    }

                    Console.WriteLine("  OK: " + lista.Count + " coches, sospechosos: " + Sospechosos(lista));
                    foreach (Coche c in lista)
                    {
                        if (EsSospechoso(c))
                        {
                            Console.WriteLine("  sospechoso -> " + c);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("  ERROR: " + ex.GetType().Name);
                    Console.WriteLine("  " + ex.Message);
                }
                Console.WriteLine();
            }
        }

        static List<Coche> LeerCsv(string ruta)
        {
            List<Coche> lista = new List<Coche>();
            using (StreamReader sr = new StreamReader(ruta))
            {
                string? linea = sr.ReadLine(); // la cabecera
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] p = linea.Split(';');
                    lista.Add(new Coche(int.Parse(p[0]), p[1], p[2], int.Parse(p[3]), p[4], p[5], int.Parse(p[6]), int.Parse(p[7])));
                }
            }
            return lista;
        }

        static List<Coche> LeerJson(string ruta)
        {
            string texto = File.ReadAllText(ruta);
            List<Coche>? lista = JsonSerializer.Deserialize<List<Coche>>(texto);
            if (lista == null)
            {
                lista = new List<Coche>();
            }
            return lista;
        }

        static List<Coche> LeerXml(string ruta)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Coche>));
            List<Coche>? lista;
            using (StreamReader sr = new StreamReader(ruta))
            {
                lista = (List<Coche>?)serializer.Deserialize(sr);
            }
            if (lista == null)
            {
                lista = new List<Coche>();
            }
            return lista;
        }

        // sospechoso si tiene algun texto vacio o algun numero a 0
        static bool EsSospechoso(Coche c)
        {
            if (c.Marca == "" || c.Modelo == "" || c.Combustible == "" || c.Color == "")
            {
                return true;
            }
            if (c.Id == 0 || c.Anio == 0 || c.Kilometros == 0 || c.Precio == 0)
            {
                return true;
            }
            return false;
        }

        static int Sospechosos(List<Coche> lista)
        {
            int cont = 0;
            foreach (Coche c in lista)
            {
                if (EsSospechoso(c))
                {
                    cont++;
                }
            }
            return cont;
        }
    }
}
