using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad sólo escritura con validación.
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que recibe un [string].
        /// Constructor por defecto.
        /// </summary>
        /// <param name="strNumero">Recibo un numero para inicializar el objeto.</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Constructor que recibe un [double].
        /// </summary>
        /// <param name="dbNumero">Recibo un numero para inicializar el objeto.</param>
        public Numero(double dbNumero) : this(dbNumero.ToString())
        {

        }
        /// <summary>
        /// Constructor sin parametro inicializa en cero [string].
        /// </summary>
        public Numero() : this(0)
        {

        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método para validar numero, sino se inicializa en cero (0). 
        /// </summary>
        /// <param name="strNumero">Numero a validar.</param>
        /// <returns>Retorno número validado.</returns>
        private static double ValidarNumero(string strNumero)
        {
            //Con TryPaser sino lo puede convertir devuelve 0
            double.TryParse(strNumero, out double dbNumero);
            return dbNumero;
        }
        /// <summary>
        /// Método para conversión de binario a decimal.
        /// </summary>
        /// <param name="strResultado">Numero a convertir.</param>
        /// <returns>Retorno el numero convertido en decimal.</returns>
        public static string BinarioADecimal(string strResultado)
        {
            Numero dbNumero = new Numero(strResultado);
            char[] arrResultado = strResultado.ToCharArray();
            //Se invierte el array porque los valores van de derecha a izquierda
            Array.Reverse(arrResultado);
            double suma = 0;
            if (dbNumero.numero > 0)
            {
                for (int i = 0; i < arrResultado.Length; i++)
                {
                    if (arrResultado[i] == '1')//Si es uno, sumo
                        suma += (int)Math.Pow(2, i);
                }
                strResultado = suma.ToString();
            }
            else if (dbNumero.numero == 0)
                strResultado = "0";
            else
                strResultado = "Valor inválido";            
            return strResultado;
        }
        /// <summary>
        /// Método para convertir a decimal a binario [string]
        /// </summary>
        /// <param name="strResultado">Numero a convertir.</param>
        /// <returns>Retorno el numero convertido en binario (sólo parte entera).</returns>
        public static string DecimalABinario(string strResultado)
        {
            /* Creo una instancia de Numero con el parametro strResultado.
             * Dejo solo la parte entera del numero
            */
            Numero auxiliar = new Numero(strResultado);
            double dbNumero = Math.Floor(auxiliar.numero);
            //Reutilizamos variables
            strResultado = "";
            if (dbNumero > 0)
            {
                while (dbNumero > 0)
                {
                    if (dbNumero % 2 == 0)
                     strResultado = "0" + strResultado;
                    else
                        strResultado = "1" + strResultado;
                    dbNumero = (int)(dbNumero / 2);
                }
            }
            else if (dbNumero == 0)
                strResultado = "0";
            else
                strResultado = "Valor inválido";
            return strResultado;
        }
        /// <summary>
        /// Método para convertir a decimal a binario [double]
        /// </summary>
        /// <param name="strResultado">Numero a convertir.</param>
        /// <returns>Retorno el numero convertido en binario (sólo parte entera).</returns>
        public static string DecimalABinario(double dbResultado)
        {
            return DecimalABinario(dbResultado.ToString());
        }
        #endregion

        #region Operaciones
        /// <summary>
        /// Operación suma [+]
        /// </summary>
        /// <param name="numero1">Operador para la suma.</param>
        /// <param name="numero2">Operador para la suma.</param>
        /// <returns>Retorno resultado de la suma.</returns>
        public static double operator +(Numero numero1, Numero numero2)
        {
            double resultado = numero1.numero + numero2.numero;
            return resultado;
        }
        /// <summary>
        /// Operación resta [-]
        /// </summary>
        /// <param name="numero1">Operador para la división.</param>
        /// <param name="numero2">Operador para la división.</param>
        /// <returns>Retorno resultado de la </returns>        
        public static double operator -(Numero numero1, Numero numero2)
        {
            double resultado = numero1.numero - numero2.numero;
            return resultado;
        }
        /// <summary>
        /// Operación división [/]
        /// </summary>
        /// <param name="numero1">Operador para la división.</param>
        /// <param name="numero2">Operador para la división.</param>
        /// <returns>Retorno resultado de la división.</returns>
        public static double operator /(Numero numero1, Numero numero2)
        {
            double resultado;
            if (numero2.numero == 0)
                resultado = double.MinValue;
            else
                resultado = numero1.numero / numero2.numero;
            return resultado;
        }
        /// <summary>
        /// Operación multiplicación [*]
        /// </summary>
        /// <param name="numero1">Operador para la multiplicación.</param>
        /// <param name="numero2">Operador para la multiplicación.</param>
        /// <returns>Retorno resultado de la multiplicación.</returns>
        public static double operator *(Numero numero1, Numero numero2)
        {
            double resultado = numero1.numero * numero2.numero;
            return resultado;
        }
        #endregion
    }
}
