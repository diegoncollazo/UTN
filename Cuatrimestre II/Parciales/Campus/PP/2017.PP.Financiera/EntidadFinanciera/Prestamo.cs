using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    #region Enumerados
    /// <summary>
    /// Tipos de prestamos.
    /// </summary>
    public enum TipoDePrestamo
    {
        Pesos,
        Dolares,
        Todos
    }
    /// <summary>
    /// Periocidad de los pagos.
    /// </summary>
    public enum PeriocidadDePagos
    {
        Mensual,
        Bimestral,
        Trimestral
    }
    #endregion

    public abstract class Prestamo
    {
        #region Atributos
        /// <summary>
        /// Atributos protegidos.
        /// </summary>
        protected float monto;
        protected DateTime vencimiento;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedades
        /// </summary>
        /// Propiedad Monto [get]
        public float Monto
        {
            get
            {
                return this.monto;
            }
        }
        /// Propiedad Vencimiento [get;set]
        /// Propiedad [set] verifica que la fecha sea mayor a la actual.
        public DateTime Vencimiento
        {
            get
            {
                return this.vencimiento;
            }
            set
            {
                if (value > DateTime.Now.Date)
                    this.vencimiento = value;
                else
                    this.vencimiento = DateTime.Now.Date;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Único constructor [por defecto].
        /// </summary>
        /// <param name="monto">Monto del préstamo</param>
        /// <param name="vencimiento">Vencimiento del préstamo</param>
        public Prestamo(float monto, DateTime vencimiento)
        {
            this.monto = monto;
            this.Vencimiento = vencimiento;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método abstracto para extender plazo de vencimiento.
        /// </summary>
        /// <param name="nuevoVencimiento"></param>
        public abstract void ExtenderPlazo(DateTime nuevoVencimiento);
        /// <summary>
        /// Metodo virtual para mostrar datos del prestamo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nMonto a vencer: $ {0}", this.monto.ToString());
            retorno.AppendFormat("\nFecha de vencimiento: {0}", this.vencimiento.ToString());
            return retorno.ToString();
        }
        /// <summary>
        /// Método estático que ordena en la lista Financiera.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static int OrdenarPorFecha(Prestamo p1, Prestamo p2)
        {
            int retorno = 0;
            if (p1.vencimiento > p2.vencimiento)
            {
                retorno = 1;
            }
            else if (p1.vencimiento < p2.vencimiento)
            {
                retorno = -1;
            }
            return retorno;
        }
        #endregion
    }
}
