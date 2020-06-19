using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_40
{
    //Enumerados
    public enum TipoLlamada
    {
        Local, Provincial, Todas
    }
    public abstract class Llamada
    {
        //Atributos
        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;
        //Propiedades
        public abstract float CostoLlamada { get; }
        public float Duracion
        {
            get
            {
                return this.duracion;
            }
        }
        public string NroDestino
        {
            get
            {
                return this.nroDestino;
            }
        }
        public string NroOrigen
        {
            get
            {
                return this.nroOrigen;
            }
        }
        //Constructores
        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }
        //Metodos
        protected virtual string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("Duración de la llamada:       {0}\n", this.Duracion);
            retorno.AppendFormat("Origen de la llamada:         {0}\n", this.NroOrigen);
            retorno.AppendFormat("Destino de la llamada:        {0}\n", this.NroDestino);

            return retorno.ToString();
        }
        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            int retorno = 0;
            if (llamada1.Duracion > llamada2.Duracion)
                retorno = 1;
            else if (llamada1.Duracion < llamada2.Duracion)
                retorno = -1;
            return retorno;
        }
        //Sobrecargas
        public static bool operator ==(Llamada llamada1, Llamada llamada2)
        {
            return (Llamada.Equals(llamada1, llamada2) && llamada1.NroOrigen == llamada2.NroOrigen && llamada1.NroDestino == llamada2.NroDestino);
        }
        public static bool operator !=(Llamada llamada1, Llamada llamada2)
        {
            return !(llamada1 == llamada2);
        }
    }
}
