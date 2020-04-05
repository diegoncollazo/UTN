using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un año: ");
            int.TryParse(Console.ReadLine(), out int year); 
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                Console.WriteLine("Es bisiesto.");
            else
                Console.WriteLine("No es bisiesto.");
            Console.ReadKey();
        }
    }
}
