using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Crear, en class library, la clase Cartuchera<T> -> restringir para que sólo lo pueda usar Utiles 
    //o clases que deriven de Utiles.
    //atributos: capacidad:int y elementos:List<T> (TODOS protegidos)        

    //Propiedades:
    //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
    //PrecioTotal:(sólo lectura) retorna el precio total de la cartuchera (la suma de los precios de sus elementos).

    //Constructor
    //Cartuchera(), Cartuchera(int); 
    //El constructor por default es el único que se encargará de inicializar la lista.

    //Métodos:
    //ToString: Mostrará en formato de tipo string: 
    //el tipo de cartuchera, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
    //de todos los elementos contenidos en la misma. Reutilizar código.

    //Sobrecarga de operadores:
    //(+) Será el encargado de agregar elementos a la cartuchera, 
    //siempre y cuando no supere la capacidad máxima de la misma.
    public class Cartuchera<T> where T : Utiles
    {
        public delegate void DelegadoEventoPrecio(object sender, EventArgs e);
        public event DelegadoEventoPrecio EventoPrecio;

        protected int capacidad;
        protected List<T> elementos;
        public List<T> Elementos { get { return this.elementos; } }

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
        public Cartuchera(int capacidad)
            : this()
        {
            this.capacidad = capacidad;
        }
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("Tipo de cartuchera: " + typeof(T).Name);
            retorno.AppendLine("Capacidad: " + this.capacidad);
            retorno.AppendLine("Cantidad de elementos: " + this.Elementos.Count);
            retorno.AppendLine("Precio total: $ " + this.PrecioTotal);
            retorno.AppendLine("\nLista de elementos en la cartuchera:\n");

            foreach (T elemento in this.Elementos)
                retorno.AppendLine(elemento.ToString());
            return retorno.ToString();
        }

        public static Cartuchera<T> operator +(Cartuchera<T> cartuchera, T elemento)
        {
            if (cartuchera.capacidad > cartuchera.Elementos.Count)
            {
                cartuchera.Elementos.Add(elemento);
                if (cartuchera is Cartuchera<Goma> && cartuchera.PrecioTotal > 85)
                    cartuchera.EventoPrecio(cartuchera, new EventArgs());
            }
            else
                throw new CartucheraLlenaException();

            return cartuchera;
        }
    }
}
