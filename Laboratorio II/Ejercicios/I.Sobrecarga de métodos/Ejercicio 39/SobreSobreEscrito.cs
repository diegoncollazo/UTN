using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_39
{
    public class SobreSobreEscrito : SobreEscrito
    {
        public override string MiAtributo
        {
            get
            {
                return this.miAtributo;
            }
        }

        public override string MiMetodo()
        {
            return MiAtributo;
        }
    }
}
