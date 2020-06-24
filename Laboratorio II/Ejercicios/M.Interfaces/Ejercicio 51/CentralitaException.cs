using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_51
{
    public class CentralitaException : Exception
    {
        //Atributos
        private string nombreClase;
        private string nombreMetodo;
        //Propiedades
        public string NombreClase
        {
            get
            {
                return this.nombreClase;
            }
        }
        public string NombreMetodo
        {
            get
            {
                return this.nombreMetodo;
            }
        }
        //Constructores
        public CentralitaException(string mensaje, string clase, string metodo) : base(mensaje)
        {
            this.nombreClase = clase;
            this.nombreMetodo = metodo;
        }
        public CentralitaException(string mensaje, string clase, string metodo, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
