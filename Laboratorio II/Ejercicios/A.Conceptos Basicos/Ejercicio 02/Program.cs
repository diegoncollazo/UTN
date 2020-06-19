using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_02
{
    class Program
    {
        static void Main(string[] args)
        {
            double numero;
            do
            {
                Console.Write("Ingrese un numero: ");
                numero = double.Parse (Console.ReadLine());
            } while (numero <= 0);
            double cuadrado = Math.Pow(numero, 2);
            double cubo = Math.Pow(numero, 3);
            Console.WriteLine("\nEl cuadrado de ese numero es: {0}", cuadrado);
            Console.Write("El cubo de ese numero es: {0}", cubo);
            Console.ReadKey();
        }
    }
}
