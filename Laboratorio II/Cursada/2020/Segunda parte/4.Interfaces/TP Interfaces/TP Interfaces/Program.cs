using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace TP_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Privado privado = new Privado(100, 500, 300);
            Console.WriteLine("Avión privado:");
            privado.MostrarPrecio();
            Console.WriteLine("Impuesto AFIP: {0}", privado.CalcularImpuesto());
            Console.WriteLine("Impuesto ARBA: {0}", ((IArba)privado).CalcularImpuesto());

            Console.WriteLine("");

            Comercial comercial = new Comercial(1000, 900, 200);
            Console.WriteLine("Avión comercial:");
            comercial.MostrarPrecio();
            Console.WriteLine("Impuesto AFIP: {0}", Gestion.MostrarImpuestoNacional(comercial));
            //Console.WriteLine("Impuesto ARBA: {0}", Gestion.MostrarImpuestoProvincial(comercial));
            Console.WriteLine($"Impuesto ARBA: {Gestion.MostrarImpuestoProvincial(comercial)}");

            Console.WriteLine("");

            Carreta carreta = new Carreta(5);
            Console.WriteLine("Carreta:");
            carreta.MostrarPrecio();
            Console.WriteLine("Impuesto ARBA: {0}", Gestion.MostrarImpuestoProvincial(carreta));

            Console.WriteLine("");

            Deportivo deportivo = new Deportivo(50, "ASD123", 800);
            Console.WriteLine("Auto deportivo:");
            deportivo.MostrarPatente();
            deportivo.MostrarPrecio();
            Console.WriteLine("Impuesto AFIP: {0}", Gestion.MostrarImpuestoNacional(deportivo));
            Console.WriteLine("Impuesto ARBA: {0}", Gestion.MostrarImpuestoProvincial(deportivo));

            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
