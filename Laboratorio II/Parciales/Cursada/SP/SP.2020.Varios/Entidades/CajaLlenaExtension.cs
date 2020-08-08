using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class CajaLlenaExtension
    {
        public static string InformarNovedad(this CajaLlenaException excepcion)
        {
            return excepcion.Message;
        }
    }
}
