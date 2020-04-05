using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region Enumerados
        public enum ETipo
        {
            Entera,
            Descremada
        }
        #endregion

        #region Atributos
        private ETipo tipo;
        #endregion

        #region Propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color) : this(marca, codigo, color, ETipo.Entera)
        {

        }
        /// <summary>
        /// Constructor donde elijo que tipo de leche puede ser.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo) : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Publica todos los datos de Leche sobreescribiendo el metodo padre Producto
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("LECHE");
            sb.AppendLine("TIPO : " + this.tipo.ToString());//Lo dejo aca para que quede mas prolijo
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias.ToString());
            //sb.AppendLine("TIPO : " + this.tipo.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion
    }
}
