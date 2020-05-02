using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_39
{
    public abstract class SobreEscrito
    {
        protected string miAtributo;
        public SobreEscrito()
        {
            this.miAtributo = "Probar abstractos";
        }
        public abstract string MiAtributo {
            get;
        }

        public abstract string MiMetodo();
        public override string ToString()
        {
            return "Este es mi metodo ToString SobreEscrito";
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return 1142510187;
        }
    }
}
