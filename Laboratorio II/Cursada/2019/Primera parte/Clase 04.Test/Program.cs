using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase04_Entidades;

namespace Clase04_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Cosa objeto1 = new Cosa();
            Cosa objeto2 = new Cosa(37);
            Cosa objeto3 = new Cosa(34, DateTime.Now);
            Cosa objeto4 = new Cosa(8, DateTime.Now, "Juan Ignacio");

            Console.WriteLine(objeto1.Mostrar());

            Console.WriteLine(objeto2.Mostrar());

            Console.WriteLine(objeto3.Mostrar());

            Console.WriteLine(objeto4.Mostrar());

            Console.ReadKey();
        }
    }
}
