using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamoDolar : Prestamo
    {
        #region Atributos
        /// <summary>
        /// Atributos de instancia.
        /// </summary>
        private readonly PeriocidadDePagos periocidad;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Interes [sólo lectura]
        /// </summary>
        public float Interes{
            get
            {
                return CalcularInteres();
            }
        }
        /// <summary>
        /// Propiedad Periocidad [sólo lectura]
        /// </summary>
        public PeriocidadDePagos Periocidad
        {
            get
            {
                return this.periocidad;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor con valores de un prestamo.
        /// </summary>
        /// <param name="monto"></param>
        /// <param name="vencimiento"></param>
        /// <param name="periocidad"></param>
        public PrestamoDolar(float monto, DateTime vencimiento, PeriocidadDePagos periocidad) : base(monto, vencimiento)
        {
            this.periocidad = periocidad;
        }
        /// <summary>
        /// Constructor con un préstamo base.
        /// </summary>
        /// <param name="prestamo"></param>
        /// <param name="periocidad"></param>
        public PrestamoDolar(Prestamo prestamo, PeriocidadDePagos periocidad) : this(prestamo.Monto, prestamo.Vencimiento, periocidad)
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
            float retorno = new float();
            switch (this.periocidad)
            {
                case PeriocidadDePagos.Mensual:
                    retorno = (float)(this.monto * 0.25);
                    break;
                case PeriocidadDePagos.Bimestral:
                    retorno = (float)(this.monto * 0.35);
                    break;
                case PeriocidadDePagos.Trimestral:
                    retorno = (float)(this.monto * 0.40);
                    break;
            }
            return retorno;
        }
        /// <summary>
        /// Metodo para extender plazo de vencimiento aplicando interes.
        /// </summary>
        /// <param name="nuevoVencimiento"></param>
        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            TimeSpan diferenciaDeFecha = new TimeSpan();
            diferenciaDeFecha = nuevoVencimiento - this.Vencimiento;
            if (diferenciaDeFecha.Days > 0)
            {
                this.monto += (float)(diferenciaDeFecha.Days * 2.5);
                this.Vencimiento = nuevoVencimiento;
            }
        }
        /// <summary>
        /// Metodo para mostrar datos del prestamo.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("\nPréstamo en dólares:");
            retorno.AppendLine(base.Mostrar());
            retorno.AppendFormat("Periocidad: {0}", this.Periocidad.ToString());
            retorno.AppendFormat("\nInterés: {0}", this.Interes.ToString());
            return retorno.ToString();
        }
        #endregion
    }
}
