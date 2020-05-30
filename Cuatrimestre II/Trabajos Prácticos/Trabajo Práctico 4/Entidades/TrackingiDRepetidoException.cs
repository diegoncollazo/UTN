using System;

namespace Entidades
{
    public class TrackingiDRepetidoException:Exception
    {
        public TrackingiDRepetidoException(string mensaje) : base(mensaje)
        {

        }
        public TrackingiDRepetidoException(string mensaje, Exception innerException) : base(mensaje,innerException)
        {

        }
    }
}
