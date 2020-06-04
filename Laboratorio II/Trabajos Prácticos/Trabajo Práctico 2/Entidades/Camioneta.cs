using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        #region Propiedades
        /// <summary>
        /// Las camionetas son grandes.
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Único constructor de instancia.
        /// </summary>
        /// <param name="marca">Marca de la camioneta.</param>
        /// <param name="codigo">Chasis de la camioneta.</param>
        /// <param name="color">Color de la camioneta.</param>
        public Camioneta(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {

        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos de la camioneta.
        /// </summary>
        /// <returns>Retorna informacion completa de la camioneta.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO: " + this.Tamanio.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
