using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Importador : Comercio
    {
        private EPaises paisOrigen;

        public Importador(string nombreComercio, float precioAlquiler, Comerciante comerciante, EPaises paisOrigen) : base(nombreComercio, comerciante, precioAlquiler)
        {
            this.paisOrigen = paisOrigen;
        }

        public static implicit operator double(Importador n)
        {
            return n._alquiler;
        }

        public string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine((string)(this));
            retorno.AppendFormat("País de origen: {0} ", this.paisOrigen.ToString());
            return retorno.ToString();
        }

        public static bool operator ==(Importador a, Importador b)
        {
            return (a._comerciante == b._comerciante && a.paisOrigen == b.paisOrigen);
        }
        public static bool operator !=(Importador a, Importador b)
        {
            return !(a == b);
        }
    }


}
