using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Tinta tinta1 = new Tinta();
            Tinta tinta2 = new Tinta(ConsoleColor.Red, ETipoTinta.China);
            Tinta tinta3 = new Tinta(ConsoleColor.Red, ETipoTinta.China);
            Tinta tinta4 = new Tinta();
            Pluma unaPluma = new Pluma("Bic", tinta3, 20);
            //Console.WriteLine(Tinta.Mostrar(tinta1));
            //Console.WriteLine(Tinta.Mostrar(tinta2));
            //Console.WriteLine(Tinta.Mostrar(tinta3));
            //Console.WriteLine(Tinta.Mostrar(tinta4));

            //Tinta tinta5 = tinta1;

            //if (tinta1.Equals(tinta4))//Cuando las dos apuntan a la misma direccion del tipo son iguales, por mas que tengan los mismos valores no son iguales
            //{
            //    Console.WriteLine("Son giles.");
            //}
            //else
            //    Console.WriteLine("No son giles.");
            //if(tinta1.Equals(tinta5))
            //{
            //    Console.WriteLine("Son giles.");
            //}
            //else
            //    Console.WriteLine("No son giles.");


            //if(tinta1 == tinta4)
            //{
            //    Console.WriteLine("Son re feos"); //ahora si son iguales
            //}



            //string s =unaPluma;

            Console.WriteLine(unaPluma);

            unaPluma += tinta2;

            //Console.WriteLine(s);

            Console.ReadKey();
        }
    }
}
