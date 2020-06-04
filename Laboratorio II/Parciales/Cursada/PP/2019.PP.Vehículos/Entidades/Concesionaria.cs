using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{


    public class Concesionaria
    {
        private int capacidad;
        private List<Vehiculo> vehiculos;

        private Concesionaria() 
        {
            this.vehiculos = new List<Vehiculo>();
        }

        private Concesionaria(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }

        public double PrecioDeAutos
        {
            get
            {
                return ObtenerPrecio(EVehiculo.PrecioDeAutos);
            }
        }
        public double PrecioDeMotos
        {
            get
            {
                return ObtenerPrecio(EVehiculo.PrecioDeMotos);
            }
        }
        public double PrecioTotal
        {
            get
            {
                return ObtenerPrecio(EVehiculo.PrecioTotal);
            }
        }
        public static implicit operator Concesionaria(int capacidad)
        {
            Concesionaria retorno = new Concesionaria(capacidad);
            return retorno;
        }

        public static Concesionaria operator +(Concesionaria c, Vehiculo v)
        {
            if (c.capacidad > c.vehiculos.Count)
            {
                if (c != v)
                    c.vehiculos.Add(v);
                else
                    Console.WriteLine("¡El vehículo ya se encuentra en el concesionario!");
            }
            else
                Console.WriteLine("¡No hay mas lugar en el concesionario!");
            return c;
        }

        public static bool operator ==(Concesionaria c, Vehiculo v)
        {
            bool retorno = false;
            foreach (Vehiculo item in c.vehiculos)
            {
                if (item is Auto && v is Auto && ((Auto)item == (Auto)v))
                {
                    retorno = true;
                    break;
                }
                else if (item is Moto && v is Moto && ((Moto)item == (Moto)v))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Concesionaria c, Vehiculo v)
        {
            return !(c == v);
        }

        public static string Mostrar(Concesionaria c)
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("Precio de autos: $ {0}\n", c.PrecioDeAutos);
            retorno.AppendFormat("Precio de motos: $ {0}\n", c.PrecioDeMotos);
            retorno.AppendFormat("Precio de total: $ {0}\n", c.PrecioTotal);
            retorno.AppendLine("******************************************************************");
            retorno.AppendLine("Listado de vehiculos:");
            retorno.AppendLine("******************************************************************");
            foreach (Vehiculo item in c.vehiculos)
            {
                if (item is Auto)
                {
                    retorno.AppendLine(((Auto)(item)).ToString());
                }
                else if (item is Moto)
                {
                    retorno.AppendLine(((Moto)(item)).ToString());
                }
            }
            return retorno.ToString();
        }

        public double ObtenerPrecio(EVehiculo tipoVehiculo)
        {
            float retorno = 0;
            foreach (Vehiculo item in this.vehiculos)
            {
                switch (tipoVehiculo)
                {
                    case EVehiculo.PrecioDeAutos:
                        if (item is Auto)
                            retorno += (Single)((Auto)(item));
                        break;
                    case EVehiculo.PrecioDeMotos:
                        if (item is Moto)
                            retorno += (Single)((Moto)(item));
                        break;
                    case EVehiculo.PrecioTotal:
                        if (item is Auto)
                            retorno += (Single)((Auto)(item));
                        else if (item is Moto)
                            retorno += (Single)((Moto)(item));
                        break;
                }
            }
            return retorno;
        }
    }
}
