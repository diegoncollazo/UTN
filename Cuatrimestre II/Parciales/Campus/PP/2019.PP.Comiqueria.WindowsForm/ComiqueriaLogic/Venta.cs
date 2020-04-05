using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public sealed class Venta
    {
        //Atributos
        private static int porcentajeIva;
        private DateTime fecha;
        private double precioFinal;
        private Producto producto;
        //Propiedades
        internal DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
        }
        //Constructores
        static Venta()
        {
            Venta.porcentajeIva = 21;
        }
        internal Venta(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.Vender(cantidad);
        }
        //Metodos
        private void Vender(int cantidad)
        {
            this.producto.Stock -= cantidad;
            this.fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.precioFinal = CalcularPrecioFinal(this.producto.Precio, cantidad);
        }

        public static double CalcularPrecioFinal(double precioUnidad, int cantidad)
        {
            double retorno = precioUnidad * cantidad;
            retorno += retorno * Venta.porcentajeIva / 100;
            return retorno;
        }

        public string ObtenerDescripcionBreve()
        {
            return String.Format("{0} - {1} - ${2:0.00}", this.fecha, this.producto.Descripcion, this.precioFinal);
        }


    }
}
