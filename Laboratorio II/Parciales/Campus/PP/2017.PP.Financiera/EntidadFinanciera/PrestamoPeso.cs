using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamoPesos : Prestamo
    {
        #region Atributos
        /// <summary>
        /// Atributos
        /// </summary>
        private float porcentajeInteres;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que calular interés del prestamo.
        /// </summary>
        public float Interes
        {
            get
            {
                return CalcularInteres();
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor con valores de un prestamo.
        /// </summary>
        /// <param name="monto"></param>
        /// <param name="vencimiento"></param>
        /// <param name="interes"></param>
        public PrestamoPesos(float monto, DateTime vencimiento, float interes) : base(monto, vencimiento)
        {
            this.porcentajeInteres = interes;
        }
        /// <summary>
        /// Constructor con un préstamo base.
        /// </summary>
        /// <param name="prestamo"></param>
        /// <param name="porcentajeInteres"></param>
        public PrestamoPesos(Prestamo prestamo, float porcentajeInteres) : this(prestamo.Monto, prestamo.Vencimiento, porcentajeInteres)
        {

        }
        #endregion

        #region Métodos
        /// <summary>
        /// Calculo el interes total del Prestamo.
        /// </summary>
        /// <returns></returns>
        private float CalcularInteres()
        {
            return this.monto * this.porcentajeInteres / 100;
        }
        /// <summary>
        /// Metodo para mostrar datos del prestamo.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("\nPréstamo en pesos:");
            retorno.AppendLine(base.Mostrar());
            retorno.AppendFormat("Porcentaje de interés: {0}", this.porcentajeInteres.ToString());
            retorno.AppendFormat("\nIntereses: $ {0}", this.Interes.ToString());
            return retorno.ToString();
        }
        /// <summary>
        /// Metodo para extender plazo de vencimiento aplicando modificando el interes.
        /// </summary>
        /// <param name="nuevoVencimiento"></param>
        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            TimeSpan diferenciaDeFecha = new TimeSpan();
            diferenciaDeFecha = nuevoVencimiento - this.Vencimiento;
            if (diferenciaDeFecha.Days > 0)
            {
                this.porcentajeInteres += (float)(0.25 * diferenciaDeFecha.Days);
                this.Vencimiento = nuevoVencimiento;
            }
        }
        #endregion
    }
}
