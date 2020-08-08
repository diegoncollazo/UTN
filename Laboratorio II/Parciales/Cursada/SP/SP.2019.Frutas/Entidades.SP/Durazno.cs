using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Durazno : Fruta
    {
        protected int _cantPelusa;

        public string Nombre
        {
            get
            {
                return "Durazno";
            }
        }

        public int CantidadPelusa
        {
            get
            {
                return this._cantPelusa;
            }
            set
            {
                this._cantPelusa = value;
            }
        }

        public override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        public Durazno()
            : this("", 0, 0)
        {
        }

        public Durazno(string color, double peso, int cantidadPelusa)
            : base(color, peso)
        {
            this.CantidadPelusa = cantidadPelusa;
        }

        protected override string FrutaToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(this.Nombre);
            datos.Append(base.FrutaToString());
            datos.AppendLine("Cantidad de pelusa: " + this._cantPelusa);
            datos.AppendLine("Tiene carozo: " + this.TieneCarozo);

            return datos.ToString();
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }
    }
}
