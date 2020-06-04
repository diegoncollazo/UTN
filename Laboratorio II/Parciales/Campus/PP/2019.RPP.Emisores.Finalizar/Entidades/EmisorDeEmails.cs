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

        public EmisorDeEmails(string mensaje, EProducto producto, string email) : base(mensaje, producto)
        {
            this.email = email;
            this.enviado = false;
        }
        //Terminar!!!!
        public static explicit operator string(EmisorDeEmails emisor)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}\n", emisor.enviado);
            sb.AppendFormat("{0}\n", emisor.email);

            return sb.ToString();
        }

        public override string EnviarMensaje()
        {
            StringBuilder sb = new StringBuilder((string)this);
            if (this.enviado == true)
            {   
                sb.AppendLine("\n.Se envia el mensaje.");
            }
            else
            {
                sb.AppendLine("\n.Error, el mensaje ya fue enviado.");
                this.enviado = true;
            }
            return sb.ToString();
        }
    }
}
