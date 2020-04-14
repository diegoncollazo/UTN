using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_14;

namespace Clase_14_test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write(" Ingrese un numero: ");
                int i = ParseadorDeEnteros.Parse(Console.ReadLine());
                Console.WriteLine(i);
            }

            catch(ErrorParserException e)
            {
                Console.ReadKey();
                Console.WriteLine(e.InnerException.Message);
                Console.ReadKey();
            }
            

        }
    }
}
