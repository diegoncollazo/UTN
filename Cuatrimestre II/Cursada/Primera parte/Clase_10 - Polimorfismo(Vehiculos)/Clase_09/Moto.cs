using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * MOTO
 * patente: string
 * marca: Emarca
 * cantidadRueda: int
 * cilindradra: double
 * MostrarMoto():string
 */

namespace Clase_09
{
    public class Moto : Vehiculo
    {
        protected double _cilindrada;

        public Moto(string patente, EMarca marca, int cantidadRuedas, double cilindrada) : base(patente, marca, cantidadRuedas)
        {
            this._cilindrada = cilindrada;
        }

        #region Abstract

        public override string ToString()
        {
            return base.Mostrar() + " - Cilindrada: " + _cilindrada;
        }

        public override double Precio { get; set; }

        public override double CalcularPrecioConIVA()
        {
            double precioFinal = this.Precio;

            precioFinal = precioFinal * 1.21;

            return precioFinal;
        }

        #endregion
    }
}
