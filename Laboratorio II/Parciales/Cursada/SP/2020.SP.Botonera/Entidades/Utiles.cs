using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Utiles-> marca:string y precio:double (públicos); PreciosCuidados:bool (prop. s/l, abstracta);
    public abstract class Utiles
    {
        public string marca;
        public double precio;
        public abstract bool PreciosCuidados { get; }

        public Utiles(string marca, double precio)
        {
            this.marca = marca;
            this.precio = precio;
        }

        protected virtual string UtilesToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("Marca: " + this.marca);
            retorno.AppendLine("Precio: " + this.precio);

            return retorno.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
