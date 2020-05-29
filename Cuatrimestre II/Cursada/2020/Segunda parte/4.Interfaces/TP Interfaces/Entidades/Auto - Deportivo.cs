using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Deportivo : Auto, IAfip
    {
        protected int _caballosFuerza;

        public Deportivo(double precio, string patente, int caballosFuerza) : base(precio, patente)
        {
            this._caballosFuerza = caballosFuerza;
        }

        public double CalcularImpuesto()
        {
            return this._precio * 1.28;
        }
    }
}
