using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestamosPersonales;


namespace EntidadFinanciera
{
    public class Financiera
    {
        #region Atributos
        /// <summary>
        /// Atributos
        /// </summary>
        private List<Prestamo> listaDePrestamos;
        private string razonSocial;
        #endregion

        #region Propiedades
        /// <summary>
        /// Retorna el interés total ganado de la financiera [dólares]
        /// </summary>
        public float IntereseEnDolares
        {
            get
            {
                return CalcularInteresGanado(TipoDePrestamo.Dolares); 
            }
        }
        /// <summary>
        /// Retorna el interés total ganado de la financiera [pesos]
        /// </summary>
        public float IntereseEnPesos
        {
            get
            {
                return CalcularInteresGanado(TipoDePrestamo.Pesos);
            }
        }
        /// <summary>
        /// Retorna el interés total ganado de la financiera [todos]
        /// </summary>
        public float IntereseTotales
        {
            get
            {
                return CalcularInteresGanado(TipoDePrestamo.Todos);
            }
        }
        /// <summary>
        /// Retorna la lista completa de prestamos de la financiera.
        /// </summary>
        public List<Prestamo> ListaDePrestamos
        {
            get
            {
                return this.listaDePrestamos;
            }
        }
        /// <summary>
        /// Retorna la razón social de la financiera.
        /// </summary>
        public string RazonSocial
        {
            get
            {
                return this.razonSocial;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor privado que inicializa la lista de prestamos.
        /// </summary>
        private Financiera()
        {
            listaDePrestamos = new List<Prestamo>();
        }
        /// <summary>
        /// Constructor público que inicializa la financiera.
        /// </summary>
        /// <param name="razonSocial"></param>
        public Financiera(string razonSocial) : this()
        {
            this.razonSocial = razonSocial;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Calcula el interés de los diferentes prestamos.
        /// </summary>
        /// <param name="tipoDePrestamo">Tipo de préstamo a calcular</param>
        /// <returns></returns>
        private float CalcularInteresGanado(TipoDePrestamo tipoDePrestamo)
        {
            float retorno = new float();
            retorno = 0;
            foreach (Prestamo prestamo in this.ListaDePrestamos)
            {
                if (tipoDePrestamo is TipoDePrestamo.Pesos && prestamo is PrestamoPesos)
                    retorno += ((PrestamoPesos)(prestamo)).Interes;
                if (tipoDePrestamo is TipoDePrestamo.Dolares && prestamo is PrestamoDolar)
                    retorno += ((PrestamoDolar)(prestamo)).Interes;
                if (tipoDePrestamo is TipoDePrestamo.Todos)
                {
                    if (prestamo is PrestamoPesos)
                        retorno += ((PrestamoPesos)(prestamo)).Interes;
                    if (prestamo is PrestamoDolar)
                        retorno += ((PrestamoDolar)(prestamo)).Interes;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Método para mostrar todos los préstamos de la financiera.
        /// </summary>
        /// <param name="financiera"></param>
        /// <returns></returns>
        public static string Mostrar(Financiera financiera)
        {
            StringBuilder retorno = new StringBuilder();
            float pesos, dolares = new float();
            pesos = 0;
            dolares = 0;
            retorno.AppendFormat("\nRazón social: {0}\n", financiera.RazonSocial);
            foreach (Prestamo prestamo in financiera.ListaDePrestamos)
            {
                if (prestamo is PrestamoDolar)
                {
                    retorno.AppendLine(((PrestamoDolar)(prestamo)).Mostrar());
                    dolares += prestamo.Monto;
                }
                if (prestamo is PrestamoPesos)
                {
                    retorno.AppendLine(((PrestamoPesos)(prestamo)).Mostrar());
                    pesos += prestamo.Monto;
                }
            }
            retorno.AppendFormat("\nTotal de préstamos en dólares: u$s {0}", dolares);
            retorno.AppendFormat("\nTotal de intereses en dólares: u$s {0}", financiera.CalcularInteresGanado(TipoDePrestamo.Dolares).ToString());
            retorno.AppendFormat("\nTotal de préstamos en pesos: $ {0}", pesos);
            retorno.AppendFormat("\nTotal de intereses en pesos: $ {0}", financiera.CalcularInteresGanado(TipoDePrestamo.Pesos).ToString());
            return retorno.ToString();
        }
        /// <summary>
        /// Ordena la lista de prestamos por fecha.
        /// </summary>
        public void OrdenarPrestamos()
        {
            this.listaDePrestamos.Sort(Prestamo.OrdenarPorFecha);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Operador explicito string para mostrar todos los préstamos de la financiera.
        /// </summary>
        /// <param name="financiera"></param>
        /// <returns></returns>
        public static explicit operator string(Financiera financiera)
        {
            return Mostrar(financiera);
        }
        /// <summary>
        /// Operador [==] para verificar si el préstamo ya se encuentra cargado en la financiera.
        /// </summary>
        /// <param name="financiera"></param>
        /// <param name="prestamo"></param>
        /// <returns></returns>
        public static bool operator ==(Financiera financiera, Prestamo prestamo)
        {
            bool retorno = new bool();
            retorno = false;
            foreach(Prestamo item in financiera.ListaDePrestamos)
            {
                if (prestamo == item)
                    retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Operador [==] para verificar si el préstamo no se encuentra cargado en la financiera.
        /// </summary>
        /// <param name="financiera"></param>
        /// <param name="prestamo"></param>
        /// <returns></returns>
        public static bool operator !=(Financiera financiera, Prestamo prestamo)
        {
            return !(financiera == prestamo);
        }
        /// <summary>
        /// Operador [+] agrega el préstamo a la financiera. Verifica que no se encuentre cargado.
        /// </summary>
        /// <param name="financiera"></param>
        /// <param name="prestamo"></param>
        /// <returns></returns>
        public static Financiera operator +(Financiera financiera, Prestamo prestamo)
        {
            if (financiera != prestamo)
            {
                financiera.listaDePrestamos.Add(prestamo);
            }
            return financiera;
        }
        #endregion
    }
}
