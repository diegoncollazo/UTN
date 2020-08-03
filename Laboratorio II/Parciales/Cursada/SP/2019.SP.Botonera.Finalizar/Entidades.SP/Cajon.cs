using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades.SP
{
    public class Cajon<T> : ISerializar where T : Fruta
    {
        //atributos: _capacidad:int, _elementos:List<T> y _precioUnitario:double (todos protegidos)        
        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total del cajón (precio * cantidad de elementos).
        //Constructor
        //Cajon(), Cajon(int), Cajon(double, int); 
        //El por default: es el único que se encargará de inicializar la lista.
        //Métodos

        //Si el precio total del cajon supera los 55 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cajon. 
        //Crear el manejador necesario para que se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.

        public delegate void delegado(string texto);


        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;

        public event delegado EventoPrecio;

        public double PrecioTotal
        {
            get
            {
                double aux = 0;
                aux += this._precioUnitario * (this._elementos.Count);
                if (aux > 55)
                {
                    //EventoPrecio();
                }
                return aux;
            }
        }

        public List<T> Elementos
        {
            get { return this._elementos; }
        }

        public Cajon()
        {
            this._elementos = new List<T>();
        }

        public Cajon(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(double precio, int capacidad) : this(capacidad)
        {
            this._precioUnitario = precio;
        }

        //ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total
        //y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Capacidad: {0} ", this._capacidad);
            retorno.AppendFormat("Cantidad total de elementos: {0} ", this.Elementos.Count);
            retorno.AppendFormat("Precio Total: {0} ", this.PrecioTotal);
            foreach (T item in this._elementos)
                retorno.Append(item);

            return retorno.ToString();
        }

        public bool Xml(string archivo)
        {
            bool retorno = false;
            
            try
            {
                XmlSerializer aux = new XmlSerializer(typeof(T));

            }
            catch(Exception e)
            {
                MessageBox.Show()
            }         

            return retorno;
        }

        public static Cajon<T> operator +(Cajon<T> cajonAux, T elemento)
        {
            if (cajonAux.Elementos.Count < cajonAux._capacidad)
            {
                cajonAux.Elementos.Add(elemento);
            }

            return cajonAux;
        }
    }
}
