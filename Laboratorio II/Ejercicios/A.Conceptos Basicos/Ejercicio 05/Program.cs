using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroUno, numeroDos, prevCenter = 0, nextCenter = 0;
            do
            {
                Console.Write("Ingrese el primer numero: ");
                int.TryParse(Console.ReadLine(), out numeroUno);
                Console.Write("Ingrese el segundo numero: ");
                int.TryParse(Console.ReadLine(), out numeroDos);
            } while (numeroUno >= numeroDos);
            if (numeroDos > numeroUno)
            {
                for (int i = 1; i < numeroUno; i++)
                {
                    prevCenter += i;
                }
                for (int j = numeroUno + 1; j <= numeroDos; j++)
                {
                    nextCenter += j;
                    if (prevCenter == nextCenter)
                    {
                        Console.WriteLine("Centro perfecto {0}", numeroUno);
                    }
                }
            }//Luego hacer que busquen solos por rangos.
            Console.ReadKey();
        }
    }
}
