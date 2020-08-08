using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Caja<T> where T : Objetos
    {
        //Crear, en class library, la clase Caja<T> 
        //atributos: capacidad:int y elementos:List<T> (TODOS protegidos)        
        //Propiedades:
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total de la caja (la suma de los precios de sus elementos).
        //Constructor
        //Caja(), Caja(int); 
        //El constructor por default es el único que se encargará de inicializar la lista.
        //Métodos:
        //ToString: Mostrará en formato de tipo string: 
        //el tipo de caja, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        //de todos los elementos contenidos en la misma. Reutilizar código.
        //Sobrecarga de operadores:
        //(+) Será el encargado de agregar elementos a la caja, 
        //siempre y cuando no supere la capacidad máxima de la misma.
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

        public Caja()
        {
            this.elementos = new List<T>();
        }
        public Caja(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Tipo de Caja: " + typeof(T).Name);
            retorno.AppendLine("Capacidad: " + this.capacidad);
            retorno.AppendLine("Cantidad de elementos: " + this.Elementos.Count);
            retorno.AppendLine("Precio total: " + this.PrecioTotal);
            retorno.AppendLine("Elementos en la Caja: ");
            foreach (Objetos item in this.Elementos)
                retorno.AppendLine(item.ToString());

            return retorno.ToString();
        }

        public static Caja<T> operator +(Caja<T> Caja, T t)
        {
            if (Caja.capacidad > Caja.Elementos.Count)
            {
                try
                {
                    Caja.Elementos.Add(t);
                    if (Caja is Caja<Fosforo>)
                    if (Caja.PrecioTotal > 120)
                        Caja.EventoPrecio(Caja, new EventArgs());

                }
                catch
                {
                    throw new CajaLlenaException();
                }
                        
            }
            else
                throw new CajaLlenaException();

            return Caja;
        }
    }
}
