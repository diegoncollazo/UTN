namespace Ejercicio_20
{
    public class Dolar
    {
        private double cantidad;
        private static float cotizRespectoDolar;
        //Constructores
        //Estatico / De Clase
        static Dolar()
        {
            cotizRespectoDolar = 1;
        }
        //De instancia
        public Dolar(double cantidad)
        {
            this.cantidad = cantidad;
        }
        public Dolar(double cantidad, float cotizacion) : this(cantidad)
        {
            Dolar.cotizRespectoDolar = cotizacion;
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
        //Convierto el dolar en euros
        public static explicit operator Euro(Dolar d)
        {
            Euro euro = new Euro((double)d.GetCantidad() * Euro.GetCotizacion());
            return euro;
        }
        //Convierto el dolar en pesos
        public static explicit operator Pesos(Dolar d)
        {
            Pesos pesos = new Pesos((double)d.GetCantidad() * Pesos.GetCotizacion());
            return pesos;
        }

        public static implicit operator Dolar(double d)
        {
            Dolar dolar = new Dolar(d);
            return dolar;
        }

        public static bool operator ==(Dolar dolar1, Dolar dolar2)
        {
            return dolar1.cantidad == dolar2.cantidad;
        }

        public static bool operator !=(Dolar dolar1, Dolar dolar2)
        {
            return !(dolar1 == dolar2);
        }

        public static bool operator ==(Dolar dolar, Euro euro)
        {
            return dolar == (Dolar)euro;
        }

        public static bool operator !=(Dolar dolar, Euro euro)
        {
            return !(dolar == euro);
        }


    }
}
