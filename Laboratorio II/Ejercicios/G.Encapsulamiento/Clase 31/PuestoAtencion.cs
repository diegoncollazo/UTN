using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Clase_31
{
    public class PuestoAtencion
    {

        private static int numeroActual;
        private EPuesto puesto;

        public static int NumeroActual
        {
            get
            {
                PuestoAtencion.numeroActual++;
                return PuestoAtencion.numeroActual;
            }
        }
        static PuestoAtencion()
        {
            PuestoAtencion.numeroActual = 0;
        }
        public PuestoAtencion(EPuesto puesto)
        {
            this.puesto = puesto;
        }
        public static bool Atender(Cliente cliente)
        {
            Thread.Sleep(1000);
            return true;
        }

    }
}
