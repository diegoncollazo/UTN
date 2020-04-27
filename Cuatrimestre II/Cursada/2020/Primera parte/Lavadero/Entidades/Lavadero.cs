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
                    {
                        retorno.AppendLine(((Auto)(item)).MostrarAuto());
                        retorno.AppendFormat("Precio lavado: $ {0}\n\n", this.precioAuto);
                    }
                    else if (item is Camion)
                    {
                        retorno.AppendLine(((Camion)(item)).MostrarCamion());
                        retorno.AppendFormat("Precio lavado: $ {0}\n\n", this.precioCamion);
                    }
                    else
                    {
                        retorno.AppendLine(((Moto)(item)).MostrarMoto());
                        retorno.AppendFormat("Precio lavado: $ {0}\n\n", this.precioMoto);
                    }
                }
                retorno.AppendLine("*******Facturacion del mes*******");
                retorno.AppendFormat("\nTotal facturado: $ {0}\n", this.MostrarTotalFacturado());
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
        public Lavadero(float precioAuto, float precioMoto, float precioCamion) : this()
        {
            this.precioAuto = precioAuto;
            this.precioCamion = precioCamion;
            this.precioMoto = precioMoto;
        }

        private double MostrarTotalFacturado()
        {
            return MostrarTotalFacturado(EVehiculos.Auto) + MostrarTotalFacturado(EVehiculos.Camion) + MostrarTotalFacturado(EVehiculos.Moto);
        }
        private double MostrarTotalFacturado(EVehiculos vehiculo)
        {
            double retorno = 0;
            if (this.Vehiculos.Count > 0)
                foreach (Vehiculo item in this.Vehiculos)
                {
                    switch (vehiculo)
                    {
                        case EVehiculos.Auto:
                            if (item is Auto)
                                retorno += this.precioAuto;
                            break;
                        case EVehiculos.Camion:
                            if (item is Camion)
                                retorno += this.precioCamion;
                            break;
                        case EVehiculos.Moto:
                            if (item is Moto)
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
        public static Lavadero operator +(Lavadero lavadero, Vehiculo vehiculo)
        {
            if (lavadero != vehiculo)
                lavadero.Vehiculos.Add(vehiculo);
            return lavadero;
        }        
        public static Lavadero operator -(Lavadero lavadero, Vehiculo vehiculo)
        {
            if (lavadero == vehiculo)
                lavadero.Vehiculos.Remove(vehiculo);
            return lavadero;
        }
        public static int OrdenarVehiculosPorPatente(Vehiculo v1, Vehiculo v2)
        {
            return String.Compare(v1.Patente, v2.Patente);
        }
        public static int OrdenarVehiculosPorMarca(Vehiculo v1, Vehiculo v2)
        {
            return String.Compare(v1.Marca.ToString(), v2.Marca.ToString());
        }
    }
}
