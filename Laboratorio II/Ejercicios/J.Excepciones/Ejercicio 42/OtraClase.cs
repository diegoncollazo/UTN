using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_42
{
    public class OtraClase
    {
        public void MetodoDeInstancia()
        {
            try
            {
                MiClase miClase = new MiClase("");
            }
            catch (UnaExcepcion e)
            {
                MiExcepcion ex = new MiExcepcion("Esta es Mi Exception: MiExcepcion Estoy en OtraClase", e);
                throw ex;
            }
        }
    }
}
