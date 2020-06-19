using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_11
{
    public class Validacion
    {
        public static bool Validar(int valor, int min, int max)
        {
            return (valor >= min && valor <= max);
        }
    }
}
