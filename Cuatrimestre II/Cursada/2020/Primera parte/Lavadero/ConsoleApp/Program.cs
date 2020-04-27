using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Lavadero lavadero = new Lavadero(500000, 150000, 2000000);
            Auto auto = new Auto(5, "DWR191", 4, Vehiculo.EMarcas.Honda);
            Moto moto = new Moto(300, "A036PKH", 2, Vehiculo.EMarcas.Honda);
            Camion camion = new Camion(2, "DNC117", 6, Vehiculo.EMarcas.Iveco);

            lavadero += auto; 
            lavadero += camion; 
            lavadero += moto;
            lavadero += auto; 
            lavadero += auto;

            Console.WriteLine(lavadero.Info);

            Console.ReadKey();
        }
    }
}
