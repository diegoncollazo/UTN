using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ManejadorDeEmisores
    {
        //Atributos
        private List<Emisor> emisores;
        private string region;
        //Constructores
        private ManejadorDeEmisores()
        {
            this.emisores = new List<Emisor>();
        }
        public ManejadorDeEmisores(string region) : this()
        {
            this.region = region;
        }
        //Metodos
        public static bool operator ==(ManejadorDeEmisores manejador, Emisor emisor)
        {
            bool retorno = false;
            foreach (Emisor e in manejador.emisores)
            {
                if (e == emisor)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(ManejadorDeEmisores manejador, Emisor emisor)
        {
            return !(manejador == emisor);
        }

        public static bool operator +(ManejadorDeEmisores manejador, Emisor emisor)
        {
            bool retorno = false;
            if (manejador != emisor)
            {
                manejador.emisores.Add(emisor);
                retorno = true;
            }
            return retorno;
        }

        public static bool operator -(ManejadorDeEmisores manejador, Emisor emisor)
        {
            bool retorno = false;
            if (manejador == emisor)
            {
                manejador.emisores.Remove(emisor);
                retorno = true;
            }
            return retorno;
        }

        public string EnviarMensajes()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Emisor item in emisores)
            {
                if (item is EmisorDeEmails)
                    sb.AppendLine(((EmisorDeEmails)(item)).ToString());
                if (item is EmisorDeWhatsapp)
                    sb.AppendLine(((EmisorDeWhatsapp)(item)).ToString());
            }
            return sb.ToString();
        }
    }
}
