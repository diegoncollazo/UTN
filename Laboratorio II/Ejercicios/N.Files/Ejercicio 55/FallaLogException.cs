using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_55
{
    public class FallaLogException : Exception
    {
        public FallaLogException() : base()
        {

        }

        public FallaLogException(string mensaje) : base(mensaje) 
        {

        }
    }
}
