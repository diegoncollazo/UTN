using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Animal
    {
        protected int _cantidadPatas;
        protected int _velocidadMaxima;
        protected static Random _distanciaRecorrida;
        /// <summary>
        /// Propiedad Patas
        /// </summary>
        public int CantidadPatas
        {
            get
            {
                return this._cantidadPatas;
            }
            set
            {
                int retorno = value;
                if (value < 1 || value > 4)
                    retorno = 4;
                this._cantidadPatas = retorno;
            }
        }
        /// <summary>
        /// Propiedad Estática Distancia
        /// </summary>
        public int DistanciaRecorrida
        {
            get
            {
                return _distanciaRecorrida.Next(10, this.VelocidadMaxima); ;
            }
        }
        /// <summary>
        /// Propiedad Velocidad maxima
        /// </summary>
        public int VelocidadMaxima
        {
            get
            {
                return this._velocidadMaxima;
            }
            set
            {
                int retorno = value;
                if (value < 1 || value > 60)
                    retorno = 60;
                this._velocidadMaxima = retorno;
            }
        }
        /// <summary>
        /// Constructor estatico
        /// </summary>
        static Animal()
        {
            _distanciaRecorrida = new Random();
        }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="cantidadPatas"></param>
        /// <param name="velocidadMaxima"></param>
        public Animal(int cantidadPatas, int velocidadMaxima)
        {
            this.CantidadPatas = cantidadPatas;
            this.VelocidadMaxima = velocidadMaxima;
            
        }
        /// <summary>
        /// Muestro los datos del Animal
        /// </summary>
        /// <returns></returns>
        public virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nCantidad de patas: {0}", this.CantidadPatas.ToString());
            retorno.AppendFormat("\nVelocidad máxima:  {0} km/h", this.VelocidadMaxima.ToString());
            retorno.AppendFormat("\nRecorrido:         {0} kms", this.DistanciaRecorrida.ToString());
            return retorno.ToString();
        }
    }
}
