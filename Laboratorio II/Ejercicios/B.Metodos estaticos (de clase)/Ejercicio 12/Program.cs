using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero, total = 0;
            char respuesta = ' ';
            do
            {
                Console.Write("Ingrese un numero: ");
                int.TryParse(Console.ReadLine(), out numero);
                total += numero;
                Console.Write("¿Continuar? (S/N): ");
                char.TryParse(Console.ReadLine(), out respuesta);
            } while (ValidarRespuesta.ValidaS_N(respuesta));
        }
    }
}
