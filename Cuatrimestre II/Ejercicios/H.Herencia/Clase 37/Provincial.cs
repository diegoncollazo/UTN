using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_37
{
    
    public class Provincial : Llamada
    {
        //Enumerados
        public enum Franja
        {
            Franja_1,
            Franja_2,
            Franja_3
        }
        //Atributos
        protected Franja franja;
        //Propiedades
        public override float CostoLlamada
        {
            get
            {
                return CalcularCosto();
            }
        }
        //Constructores
        public Provincial(Franja franja, Llamada llamada) : this(llamada.NroOrigen, franja, llamada.Duracion, llamada.NroDestino)
        {

        }
        public Provincial(string origen, Franja franja, float duracion, string destino) : base(duracion, destino, origen)
        {
            this.franja = franja;
        }
        //Metodos
        private float CalcularCosto()
        {
            float retorno = new float();
            switch (this.franja)
            {
                case Franja.Franja_1:
                    retorno = (float)(this.Duracion * 0.99);
                    break;
                case Franja.Franja_2:
                    retorno = (float)(this.Duracion * 1.25);
                    break;
                case Franja.Franja_3:
                    retorno = (float)(this.Duracion * 0.66);
                    break;
            }
            return retorno;
        }
        protected override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("*** Llamada provincial ***\n");
            retorno.Append(base.Mostrar());
            retorno.AppendFormat("Costo de la llamada:          {0}\n", this.CostoLlamada);
            retorno.AppendFormat("Franja horaria de la llamada: {0}\n", this.franja.ToString());
            return retorno.ToString();
        }
        public override bool Equals(object obj)
        {
            return (obj is Provincial);
        }
        public override string ToString()
        {
            return Mostrar();
        }

    }
}
