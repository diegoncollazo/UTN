using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_14
{
    public class ErrorParserException : Exception
    {
        public ErrorParserException(string message, Exception exception) : base (message, exception)
        {
            Console.WriteLine("El string no podrá ser convertido" + message);
        }
    }
}
