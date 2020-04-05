using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *CAMION
 * patente: string
 * marca: Emarca
 * cantidadRuedas: int
 * tara: double
 * MostrarCamion(): string
 */

namespace Clase_09
{
    public class Camion : Vehiculo
    {
            
        protected double _tara;

        #region Metodos

        //CONSTRUCTOR
        public Camion(string patente, EMarca marca, int cantidadRuedas, double tara) : base(patente, marca, cantidadRuedas)
        {
            this._tara = tara;
        }

        #endregion


        #region Polimorfismo

        public override string ToString()
        {
            return base.Mostrar() + " - Tara: " + this._tara;
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
