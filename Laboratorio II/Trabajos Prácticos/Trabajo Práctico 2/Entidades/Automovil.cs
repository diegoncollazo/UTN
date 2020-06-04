using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        #region Enumerados
        /// <summary>
        /// Enumerados de tipo de auto.
        /// </summary>
        public enum ETipo { 
            Monovolumen, Sedan
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Atributos
        /// </summary>
        private ETipo tipo;
        #endregion

        #region Propiedades
        /// <summary>
        /// Los automoviles son medianos.
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de instancia. Atributo tipo por defecto será Monovolumen.
        /// </summary>
        /// <param name="marca">Marca del auto.</param>
        /// <param name="chasis">Chasis del auto.</param>
        /// <param name="color">Color del auto.</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color) : this(marca, chasis, color, ETipo.Monovolumen)    
        {

        }
        /// <summary>
        /// Constructor de instancia. Atributo tipo a elección.
        /// </summary>
        /// <param name="marca">Marca del auto.</param>
        /// <param name="chasis">Chasis del auto.</param>
        /// <param name="color">Color del auto.</param>
        /// <param name="tipo">Tipo de auto.</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del automovil.
        /// </summary>
        /// <returns>Retorna informacion completa del automovil.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO: " + this.Tamanio.ToString());
            sb.AppendLine("TIPO:   " + this.tipo.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
