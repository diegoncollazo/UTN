using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Emisor
    {
        public enum EProducto
        {
            SQLDatabase,
            MonitoringApp,
            AppHosting
        }

        private string mensaje;
        private EProducto producto;

        protected Emisor(string mensaje, EProducto producto)
        {
            this.mensaje = mensaje;
            this.producto = producto;
        }

        public override string ToString()
        {
            string retorno = String.Format("\n.{0}\n.{1}", this.mensaje, this.producto.ToString());
            return retorno;
        }

        public abstract string EnviarMensaje();

        public static bool operator ==(Emisor emisor1, Emisor emisor2)
        {
            bool retorno = false;
            if (emisor1.mensaje == emisor2.mensaje && emisor1.producto == emisor2.producto)
                retorno = true;
            return retorno;
        }

        public static bool operator !=(Emisor emisor1, Emisor emisor2)
        {
            return !(emisor1 == emisor2);
        }
    }
}
