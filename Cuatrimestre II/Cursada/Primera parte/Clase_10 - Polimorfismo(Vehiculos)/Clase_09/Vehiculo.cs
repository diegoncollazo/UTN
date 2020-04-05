using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * (+) publico
 * (-) privado
 * (~) protegido
 */

namespace Clase_09
{
    public abstract class Vehiculo //Hacer abstract la clase
    {
        #region Atributos

        //CLASE PADRE
        protected string _patente;
        protected EMarca _marca;
        protected int _cantidadRuedas;

        #endregion

        #region GET

        public string GetPatente //Patente solo lectura
        {
            get
            {
                return this._patente;
            }
        }

        public EMarca GetMarca //Marca de solo lectura
        {
            get
            {
                return this._marca;
            }
        }

        #endregion

        #region Metodos

        //CONSTRUCTOR
        public Vehiculo(string patente, EMarca marca, int cantidadRuedas)
        {
            this._patente = patente;
            this._marca = marca;
            this._cantidadRuedas = cantidadRuedas;
        }

        #endregion

        #region Polimorfismo/Abstract

        public virtual string Mostrar()
        {
            return " Patente: " + _patente + " - Marca: " + _marca.ToString() + " - Cantidad de ruedas: " + _cantidadRuedas.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public abstract double Precio
        {
            get; set;
        }

        public abstract double CalcularPrecioConIVA();

        #endregion

        #region Sobrecarga

        public static bool operator ==(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            bool retorno = false;
            if (vehiculo1._patente == vehiculo2._patente && vehiculo1._marca == vehiculo2._marca)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return !(vehiculo1 == vehiculo2);
        }

        #endregion
    }
}
