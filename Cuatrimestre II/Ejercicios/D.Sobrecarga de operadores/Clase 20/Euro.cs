using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billetes
{
    public class Euro
    {
        private double cantidad;
        private static float cotizRespectoDolar;
        //Constructores
        //Estatico / De Clase
        static Euro()
        {
            cotizRespectoDolar = 1.16f;
        }
        //De instancia
        public Euro(double cantidad)
        {
            this.cantidad = cantidad;
        }
        public Euro(double cantidad, float cotizacion) : this(cantidad)
        {
            Euro.cotizRespectoDolar = cotizacion;
        }
        //Getter Cantidad
        public double GetCantidad()
        {
            return this.cantidad;
        }
        //Getter Estatico Cotizacion
        public static float GetCotizacion()
        {
            return cotizRespectoDolar;
        }
        //Convierto el euros en dolar
        public static explicit operator Dolar(Euro e)
        {
            Dolar retorno = new Dolar((double)e.GetCantidad() * Dolar.GetCotizacion());
            return retorno;
        }
        //Convierto el euro en pesos
        public static explicit operator Pesos(Euro e)
        {
            Pesos retorno = new Pesos((double)e.GetCantidad() * Pesos.GetCotizacion());
            return retorno;
        }
    }
}
