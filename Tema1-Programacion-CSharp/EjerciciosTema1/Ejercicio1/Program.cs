using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const decimal IVA = 0.21m;
            decimal enviogratis = 50.00m;
            decimal costeenvio = 4.95m;

            Console.Write("Producto: ");
            string producto = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(producto))
            {
                producto = "Producto sin nombre";
            }

            Console.Write("Precio unitario (€): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal precio) || precio <= 0)
            {
                Console.WriteLine("El precio debe ser un número mayor que 0.");
                return;
            }

            Console.Write("Unidades: ");
            if (!int.TryParse(Console.ReadLine(), out int unidades) || unidades <= 0)
            {
                Console.WriteLine("Las unidades deben ser un número entero mayor que 0.");
                return;
            }

            Console.Write("Cupón de descuento (Enter si no tienes): ");
            string cupon = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(cupon))
            {
                cupon = null;   // "no ha escrito nada" lo representamos con null
            }

            // --- 2. Cálculos ---
            // '?.' : si cupon es null, no llama a ToUpper() y codigo vale null (apartado 4.3)
            string codigo = cupon?.ToUpper();

            // switch expression (apartado 6): '_' recoge null y cualquier cupón desconocido
            decimal porcentaje = 0;
            switch (codigo)
            {
                case "DAM10":
                    porcentaje = 0.20m;
                    break;

                case "DAM20":
                    porcentaje = 0.20m;
                    break;
                case "_":
                    porcentaje = 0m;
                    break;

            }
            ;

            decimal subtotal = precio * unidades;
            decimal descuento = subtotal * porcentaje;
            decimal baseImponible = subtotal - descuento;
            decimal importeIva = baseImponible * IVA;
            decimal totalProductos = baseImponible + importeIva;

            // Operador ternario (apartado 6)
            decimal envio = totalProductos >= enviogratis ? 0m : costeenvio;
            decimal totalAPagar = totalProductos + envio;

            string textoUnidades = unidades == 1 ? "unidad" : "unidades";
            string textoCupon = codigo ?? "(ninguno)";   // '??' : valor por defecto si es null
            string textoEnvio = envio == 0m ? "gratis" : $"{envio:F2} €";

            // --- 3. Salida ---
            Console.WriteLine();
            Console.WriteLine("========== TICKET ==========");
            Console.WriteLine($"{producto}: {unidades} {textoUnidades} x {precio:F2} €");
            Console.WriteLine($"Subtotal:            {subtotal:F2} €");
            Console.WriteLine($"Cupón {textoCupon}:   -{descuento:F2} € ({porcentaje * 100:F0} %)");
            Console.WriteLine($"Base imponible:      {baseImponible:F2} €");
            Console.WriteLine($"IVA ({IVA * 100:F0} %):          {importeIva:F2} €");
            Console.WriteLine($"Envío:               {textoEnvio}");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"TOTAL A PAGAR:       {totalAPagar:F2} €");

            if (codigo != null && porcentaje == 0m)
            {
                Console.WriteLine($"Aviso: el cupón '{codigo}' no es válido y no se ha aplicado.");
            }
        }
    }
}
