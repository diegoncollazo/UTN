using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public abstract class Producto
    {
        //Atributos
        private Guid codigo;
        private string descripcion;
        private double precio;
        private int stock;
        //Propiedades
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
        }
        public double Precio
        {
            get
            {
                return this.precio;
            }
        }
        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                if (value >= 0)
                    this.stock = value;
            }
        }
        //Constructor
        protected Producto(string descripcion, int stock, double precio)
        {
            this.codigo = Guid.NewGuid();
            this.descripcion = descripcion;
            this.precio = precio;
            this.Stock = stock;
        }
        //Metodos
        //ToString()
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Descripción: {0}\n", this.Descripcion);
            retorno.AppendFormat("Código: {0}\n", this.codigo.ToString());
            retorno.AppendFormat("Precio: $ {0}\n", this.Precio);
            retorno.AppendFormat("Stock: {0} unidad(es)", this.Stock);
            return retorno.ToString();
        }
        //Codigo implicito
        public static explicit operator Guid(Producto p)
        {
            return p.codigo;
        }
    }
}
