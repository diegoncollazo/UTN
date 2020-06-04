using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    public class Camion : Vehiculo
    {
        protected float _tara;

        public Camion(string patente, EMarca marca, byte ruedas, float tara) : base(patente, marca, ruedas)
        {
            this._tara = tara;
        }

        public override string ToString()
        {
            return base.ToString() + " / Tara: " + this._tara.ToString() + " Kgrs" ;
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
