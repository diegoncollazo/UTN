using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_19;

namespace Ejercicio_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Sumador s1 = new Sumador(2);
            Sumador s2 = new Sumador(3);
            Console.WriteLine(s1 + s2);

            Console.ReadKey();
        }
    }
}
