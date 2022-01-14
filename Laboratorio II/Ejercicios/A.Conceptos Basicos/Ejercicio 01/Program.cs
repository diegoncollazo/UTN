using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[5];
            int menor = 0;
            int mayor = 0;
            float suma = 0;
            bool bandera = true;
            for (int i=0; i<5; i++)
            {
                Console.Write("Ingrese un numero: ");
                numeros[i] = int.Parse (Console.ReadLine());
                suma += numeros[i];
                if (bandera == true)
                {
                    menor = numeros[0];
                    mayor = numeros[0];
                    bandera = false;
                }
                if (numeros[i] < menor)  
                    menor = numeros[i];
                else if (numeros[i] > mayor)
                    mayor = numeros[i];
            }
            Console.WriteLine("La suma es: {0:#,###.00}", suma);
            Console.WriteLine("El promedio es: {0:#,###.00}", suma/5);
            Console.WriteLine("El numero menor es: {0}", menor);
            Console.WriteLine("El numero mayor es: {0}", mayor);
            Console.ReadKey();
        }
    }
}                                                   
