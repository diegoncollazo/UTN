using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_09;

namespace Clase_09_test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ingresa los vehiculos de distintos tipos y marcas al lavaderoa
            Auto auto = new Auto("ZTR", EMarca.Ferrari, 4, 4);
            Camion camion = new Camion("DFR", EMarca.Renault, 4, 48);
            Camion camion2 = new Camion("IOJ", EMarca.Zanella, 4, 48);
            Moto moto = new Moto("ASD", EMarca.Zanella, 2, 8);
            Moto moto2 = new Moto("QWE", EMarca.Ferrari, 2, 8);

            //Creo una nueva lista
            List<Vehiculo> listVehiculos = new List<Vehiculo>();

            listVehiculos.Add(auto);
            listVehiculos.Add(camion);
            listVehiculos.Add(camion2);
            listVehiculos.Add(moto);
            listVehiculos.Add(moto2);

            Console.WriteLine("\n Lista de los vehiculos ingresados al lavadero... \n");

            foreach (Vehiculo vehiculo in listVehiculos)
            {
                Console.WriteLine(vehiculo);
            }

            Console.ReadKey();

            ///------------------------------------------

            //Mostrar vehiculos con los precios

            //Declaro precios para cada vehiculo
            Lavadero lavadero = new Lavadero(2000, 5000, 8000);

            //Los agrego a la lista

            lavadero += auto;
            lavadero += camion;
            lavadero += camion2;
            lavadero += moto;
            lavadero += moto2;

            Console.WriteLine("\n Lista de los vehiculos ingresados al lavadero con precio... ");

            Console.Write(lavadero.MiLavadero);

            Console.ReadKey();

            ///--------------------------------------------------------------------

            //Quitar algun vehiculo

            Console.WriteLine("\n Nueva lista de vehiculos eliminando las motos... ");

            lavadero -= moto;
            lavadero -= moto2;

            Console.WriteLine(lavadero.MiLavadero);

            Console.ReadKey();

            ///--------------------------------------------------------------------

            //Precio total facturado

            Console.WriteLine("\n Motos con precio total facturado.... ");

            Console.WriteLine(lavadero.MostrarTotalFacturado(EVehiculos.Moto));//Total de plata de las motos

            Console.WriteLine("\n Camiones con precio total facturado.... ");

            Console.WriteLine(lavadero.MostrarTotalFacturado(EVehiculos.Camion));//Total de plata de los camiones

            Console.WriteLine("\n Autos con precio total facturado.... ");

            Console.WriteLine(lavadero.MostrarTotalFacturado(EVehiculos.Auto));//Total de plata de los autos

            Console.ReadKey();

            ///--------------------------------------------------
            
            //Ganancias totales 

            Console.WriteLine("\n Ganancias totales...");
            Console.WriteLine(lavadero.MostrarTotalFacturado(lavadero));//Total de todos los vehiculos

            Console.ReadKey();

            ///-----------------------------------------------------

            //Ordenar por patente

            Console.WriteLine("\n Vehiculos ordenador por patente...\n");

            lavadero.Vehiculos.Sort(Lavadero.OrdenarVehiculosPorPatente);

            foreach (Vehiculo vehiculo in lavadero.Vehiculos)
            {
                Console.WriteLine(vehiculo);
            }

            Console.ReadKey();

            ///----------------------------------------------------------

            //Ordennar por marca

            Console.WriteLine("\n Vehiculos ordenador por marca...\n");

            lavadero.Vehiculos.Sort(lavadero.OrdenarVehiculosPorMarca);

            foreach (Vehiculo vehiculo in lavadero.Vehiculos)
            {
                Console.WriteLine(vehiculo);
            }

            Console.ReadKey();
        }
    }
}
