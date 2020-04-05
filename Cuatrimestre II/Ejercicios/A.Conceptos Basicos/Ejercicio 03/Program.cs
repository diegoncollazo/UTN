using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero = 0;
            bool bandera = false;
            do
            {
                Console.Write("Ingrese un numero: ");
                numero = int.Parse(Console.ReadLine());
            } while (numero <= 0);
            for (int j=1; j <= numero; j++)
            {
                bandera = false;
                for (int i=2; i < j; i++)
                {
                    if (j % i == 0)
                    {
                        bandera = true;
                        break;
                    }
                }
                if (bandera)
                {
                    Console.WriteLine("Es numero {0} no es primo.", j);
                }
                else
                {
                    Console.WriteLine("Es numero {0} es primo.", j);
                }
            }
            Console.ReadKey();
        }
    }
}
