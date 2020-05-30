using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Deportivo : Auto, IAfip, IArba
    {
        protected int _caballosFuerza;

        public Deportivo(double precio, string patente, int caballosFuerza) : base(precio, patente)
        {
            this._caballosFuerza = caballosFuerza;
        }

        double IAfip.CalcularImpuesto()
        {
            return this._precio * .23;
        }

        double IArba.CalcularImpuesto()
        {
            return this._precio * .27;
        }
    }
}
