using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroPerfecto;
            for (int i = 1; i < 10000; i++)
            {
                numeroPerfecto = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        numeroPerfecto += j;
                    }
                }
                if (numeroPerfecto == i)
                {
                    Console.WriteLine("Numero perfecto: {0}", numeroPerfecto);
                }
            }
            Console.ReadKey();
        }
    }
}
