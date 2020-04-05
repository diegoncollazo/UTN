using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    public class Auto : Vehiculo
    {
        protected int _cantidadAsientos;

        public Auto(string patente, EMarca marca, byte ruedas, int asientos) : base(patente, marca, ruedas)
        {
            this._cantidadAsientos = asientos;
        }

        public override string ToString()
        {
            return base.ToString() + " / Asientos: " + this._cantidadAsientos;
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
