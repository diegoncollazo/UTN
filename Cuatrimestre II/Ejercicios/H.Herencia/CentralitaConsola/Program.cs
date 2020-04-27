using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_37;

namespace CentralitaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creacion de lista Centralita -> central
            Centralita central = new Centralita("Telefonica");

            //Creacion de nuevas llamadas ( 2 locales, 2 provinciales)
            Local localUno = new Local((float)30, "Avellaneda", "Lanus", (float)2.65);
            Provincial provincialUno = new Provincial("Corrientes", Provincial.Franja.Franja_1, 21, "Sanfa Fe");
            Local localDos = new Local(10, "Puerto Madero", "Quilmes", (float)1.99);
            Provincial provincialDos = new Provincial(Provincial.Franja.Franja_2, provincialUno);

            //Se agregan a la lista de a uno y se muestra la lista
            central += localUno;
            Console.WriteLine("Se agrego primer llamada local\n" + localUno.ToString());
            
            central += provincialUno;
            Console.WriteLine("Se agrego primer llamada provincial\n" + provincialUno.ToString());
            
            central += localDos;
            Console.WriteLine("Se agrego segunda llamada local\n" + localDos.ToString());
            
            central += provincialDos;
            Console.WriteLine("Se agrego segunda llamada provincial\n" + provincialDos.ToString());
            Console.ReadKey();
            Console.Clear();

            //Se intentara agregar la primer llamada nuevamente
            central += localUno;
            
            Console.ReadKey();
            //Se muestra el listado completo
            Console.Clear();
            Console.WriteLine("Listado completo:\n\n" + central.ToString());

            Console.ReadKey();

            //Ordenamiento de la lista
            Console.Clear();
            Console.WriteLine("Se ordenara la lista y mostrara nuevamente ordenada.\n");
            Console.WriteLine("Lista sin ordenar:\n" + central.ToString());
            central.OrdenarLlamadas();
            Console.WriteLine("Lista ordenada:\n" + central.ToString());
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Ganancia Local: " + central.GananciasPorLocal);
            Console.WriteLine("Ganancia Provincial: " + central.GananciasPorProvincia);
            Console.WriteLine("Ganancia Total: " + central.GananciasPorTotal);
            Console.ReadKey();
        }
    }
}
