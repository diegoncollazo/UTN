using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cartuchera<T> where T : Utiles
    {

        protected int capacidad;
        protected List<T> elementos;

        public delegate void DelegadoEventoPrecio(object sender, EventArgs e);
        public event DelegadoEventoPrecio EventoPrecio;

        public List<T> Elementos
        {
            get
            {
                return this.elementos;
            }
        }

        public double PrecioTotal
        {
            get
            {
                double precioTotal = 0;

                foreach (T elemento in this.Elementos)
                    precioTotal += elemento.precio;
                return precioTotal;
            }
        }

        public Cartuchera()
        {
            this.elementos = new List<T>();
        }
        public Cartuchera(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Tipo de cartuchera: " + typeof(T).Name);
            retorno.AppendLine("Capacidad: " + this.capacidad);
            retorno.AppendLine("Cantidad de elementos: " + this.Elementos.Count);
            retorno.AppendLine("Precio total: " + this.PrecioTotal);
            retorno.AppendLine("Elementos en la cartuchera: ");
            foreach(Utiles item in this.Elementos)
                retorno.AppendLine(item.ToString());

            return retorno.ToString();
        }

        public static Cartuchera<T> operator +(Cartuchera<T> cartuchera, T t)
        {
            if (cartuchera.capacidad > cartuchera.Elementos.Count)
            {
                cartuchera.Elementos.Add(t);
                if (cartuchera is Cartuchera<Goma>)
                    if (cartuchera.PrecioTotal > 85)
                        cartuchera.EventoPrecio(cartuchera, new EventArgs());
            }
            else
                throw new CartucheraLlenaException();

            return cartuchera;
        }
    }
}
