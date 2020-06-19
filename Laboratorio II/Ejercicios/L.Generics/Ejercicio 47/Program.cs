using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_47
{
    class Program
    {
        static void Main(string[] args)
        {
            Torneo<EquipoBasquet> torneoBasquet = new Torneo<EquipoBasquet>("Torneo Basquet 2020");

            EquipoBasquet equipoBasquet1 = new EquipoBasquet("Boca", new DateTime(1920, 10, 10));

            EquipoBasquet equipoBasquet2 = new EquipoBasquet("Atlas", new DateTime(1920, 10, 10));

            EquipoBasquet equipoBasquet3 = new EquipoBasquet("Gimnasia", new DateTime(1920, 10, 10));

            EquipoBasquet equipoBasquet4 = new EquipoBasquet("Independiente", new DateTime(1920, 10, 10));

            _ = torneoBasquet + equipoBasquet1;
            _ = torneoBasquet + equipoBasquet2;
            _ = torneoBasquet + equipoBasquet3;
            _ = torneoBasquet + equipoBasquet4;

            Console.WriteLine(torneoBasquet.Mostrar());

            Console.WriteLine(torneoBasquet.JugarPartido());
            Console.WriteLine(torneoBasquet.JugarPartido());
            Console.WriteLine(torneoBasquet.JugarPartido());
            Console.WriteLine(torneoBasquet.JugarPartido());

            Console.ReadKey();
        }
    }
}
