using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_57
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona1 = new Persona("Diego","Collazo");

            Persona.Guardar("Persona.xml", persona1);

            Console.WriteLine(persona1.ToString());

            Persona persona2 = Persona.Leer("persona.xml");

            Console.WriteLine(persona2.ToString());

            Console.ReadKey();
        }
    }
}
