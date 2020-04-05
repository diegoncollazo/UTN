using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    public abstract class Vehiculo
    {
        protected string _patente;
        protected EMarca _marca;
        protected byte _cantidadRuedas;
        //Constructor
        public Vehiculo(string patente, EMarca marca, byte ruedas)
        {
            this._patente = patente;
            this._cantidadRuedas = ruedas;
            this._marca = marca;
        }

        //Getter Patente
        public string GetPatente => this._patente;
        //Getter Marca
        public string GetMarca => this._marca.ToString();

        //Mostrar() vehiculo adaptable a clases hijos.
        protected virtual string MostrarVehiculo()
        {
            return "Marca: " + this._marca.ToString() + " / Patente: " + this._patente + " / Ruedas: " + this._cantidadRuedas.ToString();
        }

        public override string ToString()
        {
            return "Marca: " + this._marca.ToString() + " / Patente: " + this._patente + " / Ruedas: " + this._cantidadRuedas.ToString();
        }
        /// <summary>
        /// Compara si dos vehiculos son iguales atraves, de sus atributos Patente y Marca.
        /// </summary>
        /// <param name="vehiculo1"></param>
        /// <param name="vehiculo2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            bool retorno = false; 
            if (vehiculo1.GetPatente == vehiculo2.GetPatente && vehiculo1.GetMarca == vehiculo2.GetMarca)
                retorno = true;
            return retorno;
        }
        /// <summary>
        /// Compara si dos vehiculos son distintos atraves, de sus atributos Patente y Marca.
        /// </summary>
        /// <param name="vehiculo1"></param>
        /// <param name="vehiculo2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return !(vehiculo1 == vehiculo2);
        }
        //Ejemplo de propiedad abstracta.
        //public abstract double Precio -> Con abstract se debe implementar en las clases "hijo"
        public virtual double GetPrecio
        {
            get; set;
        }
        //Clase abstracta padre.
        public abstract double CalcularPrecioConIVA();

    }
}
