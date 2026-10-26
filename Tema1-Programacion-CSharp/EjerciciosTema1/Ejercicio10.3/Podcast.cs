using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10._3
{
    internal class Podcast :IReproducible
    {
        public string Titulo {  get; }
        public int Episodio {  get; }
        public Podcast(string titulo, int episodio)
        {
            Titulo= titulo;
            Episodio = episodio;
        }
        public void reproducir()
        {
            Console.WriteLine($"🎙 Reproduciendo pódcast: {Titulo} (episodio {Episodio})");
        }

    }
}
