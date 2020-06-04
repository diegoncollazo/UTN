using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Deposito
    {
        public List<Producto> productos;

        public Deposito(int cantidad)
        {
            this.productos = new List<Producto>(cantidad);
        }

        public Deposito() : this(3)
        {

        }

        public static bool operator ==(Deposito deposito, Producto producto)
        {
            bool retorno = false;
            foreach (Producto item in deposito.productos)
                if (item == producto)
                    retorno = true;
            return retorno;
        }
        public static bool operator !=(Deposito deposito, Producto producto)
        {
            return !(deposito == producto);
        }

        public static Deposito operator +(Deposito d1, Deposito d2)
        {
            Deposito d3 = new Deposito();

            bool respuesta;
            foreach (Producto item in d1.productos)
            {
                respuesta = BuscarProducto(d3, item, out int indice);
                if (respuesta)
                    d3.productos[indice].stock += item.stock;
                else
                    d3.productos.Add(new Producto(item.nombre, item.stock));
            }

            foreach (Producto item in d2.productos)
            {
                respuesta = BuscarProducto(d3, item, out int indice);
                if (respuesta)
                    d3.productos[indice].stock += item.stock;
                else
                    d3.productos.Add(new Producto (item.nombre, item.stock));
            }

            return d3;
        }

        public static int OrdenarStock(Producto p1, Producto p2)
        {
            return string.Compare(p1.stock.ToString(), p2.stock.ToString());

        }
        public static int OrdenarNombre(Producto p1, Producto p2)
        {
            return string.Compare(p1.nombre, p2.nombre);
        }

        private static bool BuscarProducto(Deposito d, Producto p, out int indice)
        {
            bool retorno = false;
            indice = -1;
            for(int i=0; i< d.productos.Count; i++)
            {
                if (d.productos[i] == p)
                {
                    indice = i;
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

    }
}
