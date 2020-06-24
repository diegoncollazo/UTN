using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP
{
    public class Durazno:Fruta
    {
        protected int _cantPelusa;

        public Durazno(string color, double peso, int catnPelusa) : base(color, peso)
        {
            this._cantPelusa = catnPelusa;
        }

        protected string Nombre
        {
            get
            {
                return "Durazno";
            }
        }

        protected override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        protected override string FrutaToString()
        {
            return base.FrutaToString() + " " + this.Nombre + " " + this.TieneCarozo;
        }
    }
}
