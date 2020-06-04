using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comercial : Avion, IArba
    {
        protected int _cantidadPasajeros;

        public Comercial(double precio, double velMax, int pasajeros) : base(precio, velMax)
        {
            this._cantidadPasajeros = pasajeros;
        }
        double IArba.CalcularImpuesto()
        {
            return this._precio * .25;
        }
    }
}
