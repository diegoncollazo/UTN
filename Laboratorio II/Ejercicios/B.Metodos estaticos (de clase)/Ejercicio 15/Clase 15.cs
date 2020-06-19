using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_15
{
    public class Calculadora
    {
        public static double Calcular(double numero1, double numero2, char operacion)
        {
            double resultado = 0;
            switch (operacion)
            {
                case '+':
                    resultado = numero1 + numero2;
                    break;
                case '-':
                    resultado = numero1 - numero2;
                    break;
                case '/':
                    if (Validar(numero2))
                        resultado = numero1 / numero2;
                    break;
                case '*':
                    resultado = numero1 * numero2;
                    break;
            }
            return resultado;
        }

        private static bool Validar(double numero)
        {
            return (numero != 0);
        }
    }
}
