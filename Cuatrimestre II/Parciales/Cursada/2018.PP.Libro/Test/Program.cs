using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Autor estebanRey = new Autor("Esteban", "Rey");
            Autor pepitoRey = new Autor("Pepito", "Rey");

            Manual economia = new Manual("Economia", 25.66f, "Domingo", "Caballo", ETipo.Finanzas);
            Manual c = new Manual("C#", 29.95f, "Joe", "Mayo", ETipo.Tecnico);

            //Manual economia2 = new Manual("Economia", 25.66f, "Domingo", "Caballo", ETipo.Tecnico);

            Novela miseria = new Novela("Miseria", 63.88f, estebanRey, EGenero.Romantica);
            Novela miseria2 = new Novela("Miseria", 203f, estebanRey, EGenero.Accion);
            Novela miseria3 = new Novela("Miseria", 98f, estebanRey, EGenero.CienciaFiccion);

            Biblioteca miBiblioteca = 5;

            miBiblioteca += economia;
            miBiblioteca += economia;//IGUALES
            //miBiblioteca += economia2;
            miBiblioteca += miseria;
            miBiblioteca += c;
            miBiblioteca += miseria2;
            miBiblioteca += miseria3;

            

            //Console.WriteLine("Capacidad de la biblioteca {0}", );
            Console.WriteLine("Total por Manuales: {0:#,###.##}", miBiblioteca.PrecioDeManuales);
            Console.WriteLine("Total por Novelas:  {0:#,###.##}", miBiblioteca.PrecioDeNovelas);
            Console.WriteLine("Total :  {0:#,###.##}", miBiblioteca.PrecioTotal);

            Console.WriteLine("");
            Console.WriteLine(Biblioteca.Mostrar(miBiblioteca));

            Console.ReadKey();
        }
    }
}
