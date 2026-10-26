using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio13
{
    public class Producto
    {
        public String Nombre {  get;}
        public String Categoria {  get;}
        public decimal Precio {  get;}

        public Producto(String nombre, String categoria,decimal precio )
        {
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
        }

       


    }
}
