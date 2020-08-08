using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    public class Cajon<T> : ISerializar 
    {
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;
        
        public delegate void DelegadoEventoPrecio(double precio, Cajon<T> cajon);
        public event DelegadoEventoPrecio EventoPrecio;

        public int Capacidad
        {
            get
            {
                return this._capacidad;
            }
            set
            {
                this._capacidad = value;
            }
        }

        public List<T> Elementos
        {
            get
            {
                return this._elementos;
            }
        }

        public double PrecioUnitario
        {
            get
            {
                return this._precioUnitario;
            }
            set
            {
                this._precioUnitario = value;
            }
        }

        public double PrecioTotal
        {
            get
            {
                double precioTotal = this.PrecioUnitario * this.Elementos.Count;  
                if (precioTotal > 55)
                    this.EventoPrecio(precioTotal, this);
                return precioTotal;
            }
        }

        public Cajon()
        {
            this._elementos = new List<T>();
        }

        public Cajon(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(double precioUnitario, int capacidad) : this(capacidad)
        {
            this._precioUnitario = precioUnitario;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("Capacidad: " + this._capacidad);
            retorno.AppendLine("Cantidad total de frutas: " + this._elementos.Count);
            retorno.AppendLine("Precio total: " + this.PrecioTotal);
            retorno.AppendLine("Frutas en el cajon:\n");
            foreach (T item in this._elementos)
                retorno.AppendLine(item.ToString());

            return retorno.ToString();
        }

        public bool Xml(string datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Cajon<T>));
                using (TextWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + datos))
                {
                    serializador.Serialize(escritor, this);
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error al serializar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retorno;
        }

        public static Cajon<T> operator +(Cajon<T> cajon, T elemento)
        {
            if (cajon._capacidad > cajon._elementos.Count)
                cajon._elementos.Add(elemento);
            else
                throw new CajonLlenoException();
            return cajon;
        }
    }
}
