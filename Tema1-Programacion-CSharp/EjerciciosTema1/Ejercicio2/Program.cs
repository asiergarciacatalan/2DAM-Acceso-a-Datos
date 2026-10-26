using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ano");
            if (!int.TryParse(Console.ReadLine(), out int ano) || ano < 1) ;
            Console.WriteLine("El año tiene que ser mayor que 0");

            Console.Write("Mes: ");
            if (!int.TryParse(Console.ReadLine(), out int mes) || mes > 1 || mes < 12) ;
            Console.WriteLine("El mes tiene que estar entre 1 y 12");
            Console.Write("Dia: ");
            if (!int.TryParse(Console.ReadLine(), out int dia)) ;
            Console.WriteLine("El dia tiene que ser un numero entero");
            bool esbisiesto = (ano % 4 == 0 && ano % 100 != 0) || ano % 400 == 0;
            if (esbisiesto)
            {
                Console.WriteLine("El año es bisiesto");
            }
            else if (!esbisiesto)
            {
                Console.WriteLine("El año no es bisiesto");
            }
            int diadelmes = 0;
            switch (mes)
            {
                case 1:
                    Console.WriteLine("El mes de enero tiene 31 dias");
                    diadelmes = 31 - dia;
                    break;
                case 2:
                    if (esbisiesto)
                    {
                        Console.WriteLine("El mes de febrero tiene 29 dias");
                        diadelmes = 29 - dia;
                    }
                    else
                    {
                        Console.WriteLine("El mes de febrero tiene 28 dias");
                        diadelmes = 28 - dia;
                    }
                    break;
                case 3:
                    Console.WriteLine("El mes de marzo tiene 31 dias");
                    diadelmes = 31 - dia;
                    break;
                case 4:
                    Console.WriteLine("El mes de abril tiene 30 dias");
                    diadelmes = 30 - dia;
                    break;
                case 5:
                    Console.WriteLine("El mes de mayo tiene 31 dias");
                    diadelmes = 31 - dia;
                    break;
                case 6:
                    Console.WriteLine("El mes de junio tiene 30 dias");
                    diadelmes = 30 - dia;
                    break;
                case 7:
                    Console.WriteLine("El mes de julio tiene 31 dias");
                    diadelmes = 31 - dia;
                    break;
                case 8:
                    Console.WriteLine("El mes de agosto tiene 31 dias");
                    diadelmes = 31 - dia;
                    break;
                case 9:
                    Console.WriteLine("El mes de septiembre tiene 30 dias");
                    diadelmes = 30 - dia;
                    break;
                case 10:
                    Console.WriteLine("El mes de octubre tiene 31 dias");
                    diadelmes = 31 - dia;
                    break;
                case 11:
                    Console.WriteLine("El mes de noviembre tiene 30 dias");
                    diadelmes = 30 - dia;
                    break;
                case 12:
                    Console.WriteLine("El mes de diciembre tiene 31 dias");
                    diadelmes = 31 - dia;
                    break;
            }
            switch (mes)
            {
                case 1:
                    if (mes == 12 || mes == 1 || mes == 2)
                    {
                        Console.WriteLine("estacion del año invierno");
                    }
                    break;
                case 2:
                    if (mes == 3 || mes == 4 || mes == 5)
                    {
                        Console.WriteLine("estacion del año primavera");
                    }
                    break;
                case 3:
                    if (mes == 6 || mes == 7 || mes == 8)
                    {
                        Console.WriteLine("estacion del año verano");
                    }
                    break;
                case 4:
                    if (mes == 9 || mes == 10 || mes == 11)
                    {
                        Console.WriteLine("estacion del año otoño");
                    }
                    break;

            }










        }   
    }
}
