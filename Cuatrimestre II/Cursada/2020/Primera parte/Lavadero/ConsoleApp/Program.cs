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
            Auto auto = new Auto(5, "DWR191", 4, Vehiculo.EMarcas.Honda);
            Moto moto = new Moto(300, "A036PKH", 2, Vehiculo.EMarcas.Honda);
            Camion camion = new Camion(2, "DNC117", 6, Vehiculo.EMarcas.Iveco);

            Console.WriteLine(auto.MostrarAuto());
            Console.WriteLine(moto.MostrarMoto());
            Console.WriteLine(camion.MostrarCamion());

            Console.ReadKey();
        }
    }
}
