using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Métodos
        /// <summary>
        /// Método privado para validar operador.
        /// <param name="operador">Operador a validar.</param>
        /// <returns>Retorno operador validado.</returns>
        private static string ValidarOperador(string operador)
        {
            switch (operador)
            {
                case "+"://Suma
                    //Lo dejo como viene y lo devuelvo con su valor original
                    break;
                case "-"://Resta
                    //Lo dejo como viene y lo devuelvo con su valor original
                    break;
                case "/"://Division
                    //Lo dejo como viene y lo devuelvo con su valor original
                    break;
                case "*"://Multiplicacion
                    //Lo dejo como viene y lo devuelvo con su valor original
                    break;
                default://Convierto a Suma
                    operador = "+";
                    break;
            }
            return operador;
        }
        /// <summary>
        /// Método estático para realizar operaciones.
        /// </summary>
        /// <param name="num1">Primero numero para operación</param>
        /// <param name="num2">Segundo numero para operación</param>
        /// <param name="operador">Tipo de operador</param>
        /// <returns>Retorno resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = new double();
            resultado = 0;
            switch (ValidarOperador(operador))
            {
                case "+"://Suma
                    resultado = num1 + num2;
                    break;
                case "-"://Resta
                    resultado = num1 - num2;
                    break;
                case "/"://Division
                    resultado = num1 / num2;
                    break;
                case "*"://Multiplicacion
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
        #endregion
    }

}
