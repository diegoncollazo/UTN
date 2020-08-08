using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sacapunta : Utiles
    {
        public bool deMetal;

        public override bool PreciosCuidados
        {
            get
            {
                return false;
            }
        }

        public Sacapunta(bool deMetal, double precio, string marca) : base(marca, precio)
        {
            this.deMetal = deMetal;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append(base.ToString());
            retorno.AppendLine("De metal: " + this.deMetal);
            retorno.AppendLine("Precios Cuidados: " + this.PreciosCuidados);

            return retorno.ToString();
        }
    }
}
