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
            Privado privado = new Privado(10000, 500, 300);

            privado.MostrarPrecio();

            Console.WriteLine("Valor total del avión: {0}", privado.CalcularImpuesto());

            Console.ReadKey();
        }
    }
}
