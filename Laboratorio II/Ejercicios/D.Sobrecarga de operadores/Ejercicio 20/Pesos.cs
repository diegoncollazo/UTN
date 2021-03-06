﻿namespace Ejercicio_20
{
    public class Pesos
    {
        private double cantidad;
        private static float cotizRespectoDolar;
        //Constructores
        //Estatico / De Clase
        static Pesos()
        {
            cotizRespectoDolar = 38.33f;
        }
        //De instancia
        public Pesos(double cantidad)
        {
            this.cantidad = cantidad;
        }
        public Pesos(double cantidad, float cotizacion) : this(cantidad)
        {
            Pesos.cotizRespectoDolar = cotizacion;
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

        public static implicit operator Pesos(double d)
        {
            return GetCotizacion();
        }


    }
}
