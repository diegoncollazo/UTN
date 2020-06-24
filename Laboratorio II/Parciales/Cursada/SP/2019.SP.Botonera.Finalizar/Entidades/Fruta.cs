using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP
{
    public abstract class Fruta : Cajon<Fruta>
    {
        ////Crear la siguiente jerarquía de clases:
        //Fruta-> _color:string y _peso:double (protegidos); TieneCarozo:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y FrutaToString():string (protegido y virtual, retorna los valores de la fruta)
        protected string _color;
        protected double _peso;

        protected abstract bool TieneCarozo
        {
            get;
        }

        public Fruta(string color, double peso)
        {
            this._color = color;
            this._peso = peso;
        }

        protected virtual string FrutaToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Peso: {0} Color: {1}", this._peso, this._color);
            return sb.ToString();

        }
    }
}
