using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        #region Propiedades
        /// <summary>
        /// Las motos son chicas.
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Único constructor de instancia.
        /// </summary>
        /// <param name="marca">Marca de la moto.</param>
        /// <param name="codigo">Chasis de la moto.</param>
        /// <param name="color">Color de la moto.</param>
        public Moto(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {

        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos de la moto.
        /// </summary>
        /// <returns>Retorna informacion completa de la moto.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO: " + this.Tamanio.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
