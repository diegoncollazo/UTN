using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmisorDeWhatsapp : Emisor
    {
        //Atributos
        private bool numeroCargado;
        private int numeroTelefono;
        //Constructor
        public EmisorDeWhatsapp(string mensaje, EProducto producto) : base(mensaje, producto)
        {

        }
        //Propiedades
        public int NumeroTelefono
        {
            get
            {
                return this.numeroTelefono;
            }
            set
            {
                if (value >= 1500000000 && value <= 1599999999)
                {
                    this.numeroTelefono = value;
                    this.numeroCargado = true;
                }
            }
        }
        public static explicit operator string(EmisorDeWhatsapp emisor)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}",emisor);
            if (emisor.numeroCargado == true)
            {
                sb.AppendFormat("\n{0}", emisor.numeroTelefono);
            }
            else
            {
                sb.AppendLine("\n.No cargado");
            }
            return sb.ToString();
        }

        public override string EnviarMensaje()
        {
            StringBuilder sb = new StringBuilder((string)this);
            if (this.numeroCargado == true)
            {
                sb.AppendLine("Enviando mensaje.");
            }
            else
            {
                sb.AppendLine("No se pudo enviar el mensaje.");
            }
            return sb.ToString();
        }
    }
}
