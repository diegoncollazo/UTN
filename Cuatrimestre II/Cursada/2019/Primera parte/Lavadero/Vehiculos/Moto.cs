using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    public class Moto : Vehiculo
    {
        protected double _cilindrada;

        public Moto(string patente, EMarca marca, byte ruedas, double cilindrada) : base(patente, marca, ruedas)
        {
            this._cilindrada = cilindrada;
        }

        public override string ToString()
        {
            return base.ToString() + " / Cilindrada: " + this._cilindrada.ToString() + " cc";
        }
        /// <summary>
        /// Calcula precio del auto con IVA (21%)
        /// Utilizo el atributo Precio de la clase padre [Vehiculo]
        /// </summary>
        /// <returns>Prefio con IVA</returns>
        public override double CalcularPrecioConIVA()
        {
            double precioFinal = this.GetPrecio * 1.21;
            return precioFinal;
        }
    }
}
