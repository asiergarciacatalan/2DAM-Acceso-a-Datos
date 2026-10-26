using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10._3
{
    public class Cancion : IReproducible,IDescargable
    {
        public string Titulo {  get;}
        public string Artista {  get;}
        public Cancion(string titulo, string artista)
        {
            Titulo=titulo;
            Artista=artista;
        }
        public void reproducir()
        {
            Console.WriteLine($"♪ Reproduciendo canción: {Titulo} - {Artista}");
        }

        public void descargar()
        {
            Console.WriteLine($"⬇ Descargando canción: {Titulo}");
        }
    }
}
