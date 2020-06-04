using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * AUTO
 * patente: string
 * marca: Emarca
 * cantidadRuedas: int
 * cantidadAsientos: int
 * MostrarAuto(): string
 */

namespace Clase_09
{
    public class Auto : Vehiculo
    {

        protected int _cantidadAsientos;

        #region Metodos

        //CONSTRUCTOR
        public Auto(string patente, EMarca marca, int cantidadRuedas, int cantidadAsientos) : base(patente, marca, cantidadRuedas)
        {
            this._cantidadAsientos = cantidadAsientos;
        }

        #endregion

        #region Polimorfismo/Abstract

        public override string Mostrar()
        {
            return base.Mostrar() + " - Cantidad de asientos: " + this._cantidadAsientos;
        }

        public override double Precio{ get; set; }

        public override double CalcularPrecioConIVA()
        {
            double precioFinal = this.Precio;

            precioFinal = precioFinal * 1.21;

            return precioFinal;
        }

        #endregion
    }
}
