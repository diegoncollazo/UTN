using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_29;

namespace Ejercicio_29
{
    class Program
    {
        static void Main(string[] args)
        {
            Jugador jugador = new Jugador(26858171, "Diego Collazo", 17, 100);

            Console.WriteLine(jugador.MostrarDatos());

            Console.ReadKey();
        }
    }
}
