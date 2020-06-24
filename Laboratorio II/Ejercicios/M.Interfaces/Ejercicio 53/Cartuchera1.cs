using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_53
{
    public class Cartuchera1
    {
        private List<IAcciones> acciones;

        public bool ProbarElementos()
        {
            bool retorno = true;
            foreach (IAcciones item in this.acciones)
            {
                if (item.UnidadesDeEscritura > 0)
                {
                    item.UnidadesDeEscritura -= 1;
                }
                else
                {
                    item.UnidadesDeEscritura += 1;
                    retorno = false;
                }
            }
            return retorno;
        }
    }
}
