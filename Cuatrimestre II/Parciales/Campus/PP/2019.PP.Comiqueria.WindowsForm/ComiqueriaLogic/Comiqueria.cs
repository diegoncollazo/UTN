using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public class Comiqueria
    {
        private List<Producto> productos;
        private List<Venta> ventas;

        public Producto this[Guid codigo]
        {
            get
            {
                for(int i=0; i<this.productos.Count; i++)
                    if((Guid)this.productos[i] == codigo)
                        return this.productos[i];
                return null;
            }
        }

        public Comiqueria()
        {
            this.productos = new List<Producto>();
            this.ventas = new List<Venta>();
        }

        public Dictionary<Guid, string> ListarProductos()
        {
            Dictionary<Guid, string> retorno = new Dictionary<Guid, string>();
            foreach(Producto item in this.productos)
            {
                retorno.Add((Guid)item, item.Descripcion);
                //if (item is Comic)
                //    retorno.Add((Guid)item, ((Comic)(item)).ToString());
                //else if (item is Figura)
                //    retorno.Add((Guid)item, ((Figura)(item)).ToString());
            }
            return retorno;
        }
        public string ListarVentas()
        {
            //Falta ordenar por fecha +reciente
            this.ventas.OrderByDescending(x => x.Fecha).ToList(); //Ordena de mayor a menor

            StringBuilder retorno = new StringBuilder();
            foreach (Venta item in this.ventas)
                retorno.AppendLine(item.ObtenerDescripcionBreve());
            return retorno.ToString();
        }

        public void Vender(Producto producto)
        {
            Vender(producto, 1);
        }

        public void Vender(Producto producto, int cantidad)
        {
            this.ventas.Add(new Venta(producto, cantidad));
        }

        public static bool operator ==(Comiqueria comiqueria, Producto producto)
        {
            bool retorno = false;
            foreach (Producto item in comiqueria.productos)
                if (item.Descripcion == producto.Descripcion)
                    retorno = true;
            return retorno;
        }

        public static bool operator !=(Comiqueria comiqueria, Producto producto)
        {
            return !(comiqueria == producto);
        }

        public static Comiqueria operator +(Comiqueria comiqueria, Producto producto)
        {
            if (comiqueria != producto)
                comiqueria.productos.Add(producto);
            return comiqueria;
        }
    }
}
