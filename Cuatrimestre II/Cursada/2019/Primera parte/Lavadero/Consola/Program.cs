using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehiculos;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Lavadero CarWash = new Lavadero(150, 80, 400);
            Auto auto1 = new Auto("DRW191", EMarca.Iveco, 4, 5);
            Auto auto2 = new Auto("PFA911", EMarca.Chevrolet, 4, 3);
            Camion camion1 = new Camion("ASD117", EMarca.Scania, 8, 3000);
            Camion camion2 = new Camion("VSC110", EMarca.Iveco, 8, 4000);
            Moto moto1 = new Moto("A036PKH", EMarca.Honda, 2, 125);
            Moto moto2 = new Moto("A048DNC", EMarca.Yamaha, 2, 125);

            //Console.WriteLine(auto1);
            //Console.WriteLine(camion1);
            //Console.WriteLine(moto1);

            CarWash += auto1;
            CarWash += auto2;
            CarWash += camion1;
            CarWash += camion2;
            CarWash += moto1;
            CarWash += moto2;

            //CarWash -= moto1;
            //Console.WriteLine(CarWash.MiLavadero);

            auto1.GetPrecio = 450000;
            auto2.GetPrecio = 450000;
            camion1.GetPrecio = 1250000;
            camion2.GetPrecio = 1250000;
            moto1.GetPrecio = 35000;
            moto2.GetPrecio = 35000;

            //Console.WriteLine(auto1.CalcularPrecioConIVA().ToString());
            Console.WriteLine("Total facturado es: $ {0}", CarWash.MostrarTotalFacturado());
            Console.WriteLine("Total facturado de autos: $ {0}", CarWash.MostrarTotalFacturado(EVehiculos.Auto));
            Console.WriteLine("Total facturado de camiones: $ {0}", CarWash.MostrarTotalFacturado(EVehiculos.Camion));
            Console.WriteLine("Total facturado de motos: $ {0}", CarWash.MostrarTotalFacturado(EVehiculos.Moto));

            CarWash._Vehiculos.Sort(Lavadero.OrdenarVehiculosPorMarca);
            Console.WriteLine(CarWash.MiLavadero);
            CarWash._Vehiculos.Sort(Lavadero.OrdenarVehiculosPorPatente);
            Console.WriteLine(CarWash.MiLavadero);
            Console.ReadKey();
        }
    }
}
