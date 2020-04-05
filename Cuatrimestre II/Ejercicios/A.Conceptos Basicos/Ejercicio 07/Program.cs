using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_07
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DateTime date1 = new DateTime(2008, 6, 1);
          
            Console.WriteLine(date1.ToString());
            DateTime date2 = new DateTime();
            date2 = DateTime.Today;
            Console.WriteLine(date2.ToString());
            date2.ToUniversalTime(); 
            Console.WriteLine(date2.DayOfWeek);
            Console.WriteLine(date2.ToString("dd/MM/yyyy"));


            /*
            double a = 3.25;
            double b = Math.Floor(a);
            double c = a - b;
            Console.WriteLine(b);
            Console.ReadLine();
            */

            //int year;
            //Console.Write("Ingrese su fecha de nacimiento: ");
            //year = int.Parse(Console.ReadLine());



            //if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            //    Console.WriteLine("Es bisiesto.");
            //else
            //    Console.WriteLine("No es bisiesto.");
            Console.ReadKey();
                
        }
    }
}
