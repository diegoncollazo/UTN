using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Emisor
    {
        private string mensaje;
        private EProducto producto;

        #region Constructor

        protected Emisor(string mensaje, EProducto producto)
        {
            this.mensaje = mensaje;
            this.producto = producto;
        } 

        #endregion

        public abstract string EnviarMensaje();       

        public override string ToString()
        {
            String s = String.Format("\n.{0} \n.{1}", producto, mensaje);

            return s;
        }

        #region Sobrecargas

        public static bool operator ==(Emisor emisor, Emisor emisorDos)
        {
            return ((emisor.producto == emisorDos.producto) && (emisor.mensaje == emisorDos.mensaje));
        }

        public static bool operator !=(Emisor emisor, Emisor emisorDos)
        {
            return !((emisor.producto == emisorDos.producto) && (emisor.mensaje == emisorDos.mensaje));
        }

        public override bool Equals(object obj)
        {
            return obj is Emisor;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Enumerado

        public enum EProducto
        {
            SQLDatabase,
            MonitoringApp,
            AppHosting
        }

        #endregion
    }
}
