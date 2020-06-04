using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_11;

namespace Ejercicio_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero = 0;
            int min = -100;
            int max = 100;
            int total = 0;
            int contador = 0;
            int promedio;
            for (int i=0; i<10; i++)
            {
                Console.Write("Ingrese un numero: ");
                int.TryParse(Console.ReadLine(), out numero);
                if (Validacion.Validar(numero, min, max))
                {
                    total += numero;
                    contador++;
                }   
            }
            promedio = total / contador;
            Console.WriteLine("El total es de {0}", total);
            Console.WriteLine("El promedio es de {0}", promedio);
            //Faltaria mayoy y menor
            Console.ReadKey();
        }
    }
}
