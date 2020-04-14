using System;

namespace Ejercicio_17
{
    class Program
    {
        static void Main(string[] args)
        {
            Boligrafo azul = new Boligrafo(100, ConsoleColor.Blue);
            Boligrafo rojo = new Boligrafo(50, ConsoleColor.Blue);

            string parametro = "";

            bool pudo =  azul.Pintar(75, out parametro);
            if (pudo)
            {
                Console.WriteLine("Alcanzó la tinta.");
            }
            else
            {
                Console.WriteLine("No alcanzó la tinta.");
            }

            Console.ReadKey();
        }
    }
}
