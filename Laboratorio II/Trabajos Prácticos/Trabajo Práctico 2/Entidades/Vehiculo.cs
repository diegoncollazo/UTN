using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Enumerados
        /// <summary>
        /// Enumerados de Marca
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        /// <summary>
        /// 
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Atributos de instancia privados
        /// </summary>
        private string chasis;
        private ConsoleColor color;
        private EMarca marca;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de solo lectura :Retornará el tamaño
        /// </summary>
        public abstract ETamanio Tamanio { get; }
        #endregion

        #region Constructores
        /// <summary>
        /// Único constructor de instancia.
        /// </summary>
        /// <param name="chasis">Chasis del vehículo</param>
        /// <param name="marca">Marca del vehículo</param>
        /// <param name="color">Color del vehículo</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del vehículo.
        /// </summary>
        /// <returns>Retorna informacion completa del vehículo.</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        /// <summary>
        /// Publica todos los datos del vehículo con conversión explicita.
        /// </summary>
        /// <param name="p">Vehículo a informar.</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis.
        /// </summary>
        /// <param name="v1">Primer vehículo a comparar.</param>
        /// <param name="v2">Segundo vehículo a comparar.</param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto.
        /// </summary>
        /// <param name="v1">Primer vehículo a comparar.</param>
        /// <param name="v2">Segundo vehículo a comparar.</param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}
