using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ManejadorDeEmisores
    {
        private List<Emisor> emisores;
        private string region;

        public string EnviarMensajes()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Emisor item in emisores)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }


        #region Constructores

        private ManejadorDeEmisores()
        {
            this.emisores = new List<Emisor>();
        }
        public ManejadorDeEmisores(string region) : this()
        {
            this.region = region;
        }

        #endregion

        #region Sobrecargas

        public static bool operator ==(ManejadorDeEmisores manejador, Emisor emisor)
        {
            bool indice = false;
            foreach (Emisor item in manejador.emisores)
            {
                if (item == emisor)
                {
                    indice = true;
                    break;
                }
            }
            return indice;
        }
        public static bool operator !=(ManejadorDeEmisores manejador, Emisor emisor)
        {
            return !(manejador == emisor);
        }
        public static bool operator +(ManejadorDeEmisores manejador, Emisor emisor)
        {
            bool indice = false;

            if (manejador != emisor)
            {
                manejador.emisores.Add(emisor);
                indice = true;
            }

            return indice;
        }
        public static bool operator -(ManejadorDeEmisores manejador, Emisor emisor)
        {
            bool indice = false;

            if (manejador == emisor)
            {
                manejador.emisores.Remove(emisor);
                indice = true;
            }
            return indice;
        } 

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.region);

            sb.AppendLine(emisores.ToString());
           
            return sb.ToString();
        }

        #region Equals y GetHashCode

        public override bool Equals(object obj)
        {
            return obj is ManejadorDeEmisores && this == (ManejadorDeEmisores)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        } 

        #endregion
    }
}
