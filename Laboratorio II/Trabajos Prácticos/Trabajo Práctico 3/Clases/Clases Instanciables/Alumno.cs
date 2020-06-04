using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Alumno : Universitario
    {
        #region Enumerados
        /// <summary>
        /// Enumerado de estado de cuenta.
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Atributos de la clase Alumno.
        /// </summary>
        private EEstadoCuenta estadoCuenta;
        private Universidad.EClases claseQueToma;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase Alumno.
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Alumno.
        /// </summary>
        /// <param name="id">ID del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">DNI del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        /// <param name="claseQueToma">Materia que cursa el alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Alumno.
        /// </summary>
        /// <param name="id">ID del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">DNI del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        /// <param name="claseQueToma">Materia que cursa el alumno.</param>
        /// <param name="estadoCuenta">Estado de la cuenta a del alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Polimorfismo
        /// <summary>
        /// Muestra los datos cargados de la clase Alumno.
        /// </summary>
        /// <returns>Retorna un string con todos los datos de la clase.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder(base.MostrarDatos());
            string estadoCuenta;
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    estadoCuenta = "Cuota al día.";
                    break;
                case EEstadoCuenta.Becado:
                    estadoCuenta = "Está becado.";
                    break;
                case EEstadoCuenta.Deudor:
                    estadoCuenta = "Deudor.";
                    break;
                default:
                    estadoCuenta = null;
                    break;
            }
            retorno.AppendFormat("\nESTADO DE CUENTA: {0}", estadoCuenta);
            return retorno.ToString();
        }
        /// <summary>
        /// Muestra la clase de la materia que cursa.
        /// </summary>
        /// <returns>Devuelve un string de la clase que toma el alumno.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nTOMA CLASE DE: {0}\n", this.claseQueToma);
            retorno.AppendLine("<------------------------------------------------>");
            return retorno.ToString();
        }
        /// <summary>
        /// Convierte el valor de la instancia en un objeto string.
        /// </summary>
        /// <returns>Cadena cuyo valor es el mismo que el de la instancia.</returns>
        public override string ToString()
        {
            return ("ALUMNOS: \n" + this.MostrarDatos() + this.ParticiparEnClase());
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Compara si un Alumno cursa determinada materia.
        /// </summary>
        /// <param name="alumno">Instancia de Alumno.</param>
        /// <param name="clase">Instancia de clase.</param>
        /// <returns>Retornara TRUE si un alumno toma esa clase y su estado de cuenta es distinto a deudor, 
        /// FALSE caso contrario.</returns>
        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {
            return alumno.estadoCuenta != EEstadoCuenta.Deudor && alumno.claseQueToma == clase;
        }
        /// <summary>
        /// Compara si un Alumno no cursa determinada materia.
        /// </summary>
        /// <param name="alumno">Instancia de Alumno.</param>
        /// <param name="clase">Instancia de clase.</param>
        /// <returns>Retornara TRUE si un alumno no toma esa clase, FALSE caso contrario.</returns>
        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {
            return alumno.claseQueToma != clase;
        }
        #endregion
    }
}
