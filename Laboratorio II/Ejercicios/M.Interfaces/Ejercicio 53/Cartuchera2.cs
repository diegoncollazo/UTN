using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_53
{
    public class Cartuchera2
    {
        private List<Boligrafo> boligrafos;
        private List<Lapiz> lapices;
        public bool ProbarElementos()
        {
            bool retorno = true;

            foreach (Boligrafo item in this.boligrafos)
            {
                if (item.UnidadesDeEscritura >= 1)
                {
                    item.UnidadesDeEscritura -= 1;
                }
                else
                {
                    item.UnidadesDeEscritura += 1;
                    retorno = false;
                }
            }
            foreach (Lapiz item in this.lapices)
            {
                if (((IAcciones)item).UnidadesDeEscritura >= 1)
                {
                    ((IAcciones)item).UnidadesDeEscritura -= 1;
                }
                else
                {
                    ((IAcciones)item).UnidadesDeEscritura += 1;
                    retorno = false;
                }
            }
            return retorno;
        }
    }
}
