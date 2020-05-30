using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Gestion
    {
        public static double MostrarImpuestoNacional(IAfip bienPunible)
        {
            return bienPunible.CalcularImpuesto();
        }

        public static double MostrarImpuestoProvincial(IArba bienPunible)
        {
            return bienPunible.CalcularImpuesto();
        }
    }
}
