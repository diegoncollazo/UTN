using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_14
{
    public class CalculoDeArea
    {
        public static double CalcularCuadrado(double lado)
        {
            return (Math.Pow(lado, 2));
        }
        public static double CalcularTriangulo(double b, double a)
        {
            return (b * a / 2);
        }
        public static double CalcularCirculo(double radio)
        {
            return (Math.PI * Math.Pow(radio, 2));
        }
    }
}
