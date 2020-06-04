using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Avion : Vehiculo, IAfip, IArba
    {
        protected double _velocidadMaxima;

        public Avion(double precio, double velMax) : base(precio)
        {
            this._velocidadMaxima = velMax;
        }
        //Lo dejo publico para utilizar el casteo en el Main
        public double CalcularImpuesto()
        {
            return this._precio * .33;
        }

        double IArba.CalcularImpuesto()
        {
            return this._precio * .27;
        }
    }
}
