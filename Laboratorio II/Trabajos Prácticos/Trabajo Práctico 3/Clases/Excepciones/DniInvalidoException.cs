﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private const string mensaje = "Error de formato en el DNI.";

        public DniInvalidoException() : this(mensaje, null)
        {

        }
        public DniInvalidoException(Exception e) : this(mensaje, e)
        {

        }
        public DniInvalidoException(string message) : this(message, null)
        {

        }
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
    }
}
