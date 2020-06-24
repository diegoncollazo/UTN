using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_50
{
    class Program
    {
        static void Main(string[] args)
        {
            bool variable = true;

            GuardarTexto<bool, int> texto = new GuardarTexto<bool, int>();

            Serializar<bool, int> serializar = new Serializar<bool, int>();

            Console.WriteLine(texto.Guardar(variable));
            Console.WriteLine(texto.Leer());

            Console.WriteLine(serializar.Guardar(variable));
            Console.WriteLine(serializar.Leer());

            Console.ReadKey();
        }
    }
}
