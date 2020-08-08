using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Banana : Fruta
    {
        protected string _paisOrigen;

        public string Nombre
        {
            get
            {
                return "Banana";
            }
        }

        public string Pais
        {
            get
            {
                return this._paisOrigen;
            }
            set
            {
                this._paisOrigen = value;
            }
        }

        public override bool TieneCarozo
        {
            get
            {
                return false;
            }
        }

        public Banana() : this(string.Empty, 0, string.Empty)
        {

        }

        public Banana(string color, double peso, string paisOrigen) : base(color, peso)
        {
            this.Pais = paisOrigen;
        }

        protected override string FrutaToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(this.Nombre);
            retorno.Append(base.FrutaToString());
            retorno.AppendLine("Pais de origen: " + this._paisOrigen);
            retorno.AppendLine("Tiene carozo: " + this.TieneCarozo);

            return retorno.ToString();
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }
    }
}
