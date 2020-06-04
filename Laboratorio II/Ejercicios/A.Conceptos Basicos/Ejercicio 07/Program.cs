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
            Console.ReadKey();
                
        }
    }
}
