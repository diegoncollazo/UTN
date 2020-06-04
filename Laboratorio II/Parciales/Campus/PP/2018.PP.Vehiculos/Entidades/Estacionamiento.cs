using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estacionamiento
    {
        private readonly int espacioDisponible;
        private string nombre;
        private List<Vehiculo> vehiculos;

        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        public Estacionamiento(string nombre, int espacioDisponible) : this()
        {
            this.nombre = nombre;
            this.espacioDisponible = espacioDisponible;
        }

        public static explicit operator string(Estacionamiento e)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Nombre del estacionamiento: {0}\n", e.nombre);
            foreach(Vehiculo item in e.vehiculos)
            {
                if (item is Automovil)
                    retorno.AppendLine(((Automovil)item).ConsultarDatos());
                else if (item is Moto)
                    retorno.AppendLine(((Moto)item).ConsultarDatos());
                else if (item is PickUp)
                    retorno.AppendLine(((PickUp)item).ConsultarDatos());
            }
            return retorno.ToString();
        }

        public static bool operator ==(Estacionamiento e, Vehiculo v)
        {
            bool retorno = false;
            foreach(Vehiculo item in e.vehiculos)
                if (item == v)
                    retorno = true;
            return retorno;
        }
        public static bool operator !=(Estacionamiento e, Vehiculo v)
        {
            return !(e == v);
        }

        public static Estacionamiento operator +(Estacionamiento e, Vehiculo v)
        {
            if (e != v && v.Patente != null && e.vehiculos.Count < e.espacioDisponible)
                e.vehiculos.Add(v);
            return e;
        }

        public static string operator -(Estacionamiento e, Vehiculo v)
        {
            string retorno;
            if (e == v)
            {
                e.vehiculos.Remove(v);
                retorno = v.ImprimirTicket();
            }
            else
                retorno = "El vehículo no es parte del estacionamiento.\n";
            return retorno;
        }
    }
}
