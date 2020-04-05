using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmisorDeWhatsapp : Emisor
    {
        private bool numeroCargado;
        private int numeroTelefono;

        #region Propiedad

        public int NumeroTelefono
        {
            get
            {
                return numeroTelefono;
            }
            set
            {
                if (numeroTelefono >= 1500000000 && numeroTelefono <= 1599999999)
                {
                    numeroTelefono = value;
                }
                else
                {
                    numeroCargado = false;
                }
            }
        }

        #endregion

        #region Constructor

        public EmisorDeWhatsapp(string mensaje, EProducto producto) : base(mensaje, producto)
        {

        } 

        #endregion

        public static explicit operator string(EmisorDeWhatsapp emisor)
        {
            StringBuilder sb = new StringBuilder();          
            
            if (emisor.numeroCargado == false)
            {
                sb.AppendLine("No cargado \r\n");
            }
            else
            {
                sb.AppendLine("Numero de telefono: \r\n" + emisor.numeroTelefono.ToString());
            }
            return sb.ToString();
        }
        public override string EnviarMensaje()
        {   
                  return "";
        }

    }
}
