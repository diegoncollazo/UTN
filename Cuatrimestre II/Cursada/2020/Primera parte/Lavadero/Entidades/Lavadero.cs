using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lavadero
    {
        public enum EVehiculos
        {
            Auto, Moto, Camion
        }

        private List<Vehiculo> vehiculos;
        private float precioAuto;
        private float precioMoto;
        private float precioCamion;

        public string Info
        {
            get
            {
                StringBuilder retorno = new StringBuilder();
                foreach (Vehiculo item in this.Vehiculos)
                {
                    if (item is Auto)
                        retorno.AppendLine(((Auto)(item)).MostrarAuto());
                    else if (item is Camion)
                        retorno.AppendLine(((Camion)(item)).MostrarCamion());
                    else
                        retorno.AppendLine(((Moto)(item)).MostrarMoto());
                }
                return retorno.ToString();
            }
        }
        public List<Vehiculo> Vehiculos
        {
            get
            {
                return this.vehiculos;
            }
        }

        private Lavadero()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Lavadero(float precioAuto, float precioMoto, float precioCamion)
        {
            this.precioAuto = precioAuto;
            this.precioCamion = precioCamion;
            this.precioMoto = precioMoto;
        }

        public double MostrarTotalFacturado()
        {
            double retorno = 0;
            retorno = MostrarTotalFacturado(EVehiculos.Auto) + MostrarTotalFacturado(EVehiculos.Camion) + MostrarTotalFacturado(EVehiculos.Moto);
            return retorno;
        }
        public double MostrarTotalFacturado(EVehiculos vehiculo)
        {
            double retorno = 0;
            foreach (Vehiculo item in this.Vehiculos)
            {
                switch (vehiculo)
                {
                    case EVehiculos.Auto:
                        retorno += this.precioAuto;
                        break;
                    case EVehiculos.Camion:
                        retorno += this.precioCamion;
                        break;
                    case EVehiculos.Moto:
                        retorno += this.precioMoto;
                        break;
                }
            }
            return retorno;
        }

        public static bool operator ==(Lavadero lavadero, Vehiculo vehiculo)
        {
            bool retorno = false;
            foreach (Vehiculo item in lavadero.Vehiculos)
            {
                if (item == vehiculo)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Lavadero lavadero, Vehiculo vehiculo)
        {
            return !(lavadero == vehiculo);
        }

    }
}
