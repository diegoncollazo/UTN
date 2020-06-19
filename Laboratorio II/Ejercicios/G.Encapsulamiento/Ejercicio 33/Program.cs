using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_33
{
    class Program
    {
        static void Main(string[] args)
        {
            Libro libro = new Libro();

            Console.WriteLine("{0}", libro[2]);
            Console.ReadKey();
        }
    }
}
