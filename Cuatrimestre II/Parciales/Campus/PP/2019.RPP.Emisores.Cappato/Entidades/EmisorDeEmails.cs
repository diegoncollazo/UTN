using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmisorDeEmails : Emisor
    {
        private string email;
        private bool enviado;

        public EmisorDeEmails(string mensaje, EProducto producto, string email) : base (mensaje, producto)
        {
            this.email = email;
            this.enviado = false;
        }
        public override string EnviarMensaje()
        {
            string s = "";
            if(enviado == false)
            {
               
                s = "\n Se envia el mensaje";
            }
            else
            {
                s = "\n Error, el mensaje ya estaba enviado";
            }
            return s;
        }
        public static explicit operator string(EmisorDeEmails emisor)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Email: \r\n" + emisor.email);
            sb.AppendLine("Enviado: \r\n" + emisor.enviado.ToString());
            
            return sb.ToString();
        }
    }
}
