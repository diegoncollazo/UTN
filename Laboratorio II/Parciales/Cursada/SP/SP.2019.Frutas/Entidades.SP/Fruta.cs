using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades.SP
{
    [XmlInclude(typeof(Manzana))]
    [XmlInclude(typeof(Banana))]
    [XmlInclude(typeof(Durazno))]

    public abstract class Fruta
    {
        protected string _color;
        protected double _peso;

        public string Color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }

        public double Peso
        {
            get
            {
                return this._peso;
            }
            set
            {
                this._peso = value;
            }
        }

        public abstract bool TieneCarozo
        {
            get;
        }

        public Fruta(string color, double peso)
        {
            this.Color = color;
            this.Peso = peso;
        }

        protected virtual string FrutaToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("Color: " + this._color);
            datos.AppendLine("Peso: " + this._peso);

            return datos.ToString();
        }
    }
}
