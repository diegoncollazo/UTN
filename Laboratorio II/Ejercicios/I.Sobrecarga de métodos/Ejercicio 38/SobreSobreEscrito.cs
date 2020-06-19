using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_38
{
    public class SobreSobreEscrito : SobreEscrito
    {
        public string MiMetodo()
        {
            return MiAtributo;
        }
    }
}
