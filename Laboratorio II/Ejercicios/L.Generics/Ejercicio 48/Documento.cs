using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_48
{
    public abstract class Documento
    {
        private int numero;
        public int Numero
        {
            get
            {
                return this.numero;
            }
        }
        public Documento(int numero)
        {
            this.numero = numero;
        }
    }
}
