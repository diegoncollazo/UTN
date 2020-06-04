using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carreta : Vehiculo, IArba
    {
        public Carreta(double precio) : base(precio)
        {

        }

        double IArba.CalcularImpuesto()
        {
            return this._precio * .18;
        }
    }
}
