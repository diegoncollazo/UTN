using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comerciante
    {
        private string apellido;
        private string nombre;

        public Comerciante(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public static implicit operator string(Comerciante c)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("\nNombre: " + c.nombre);
            retorno.Append("\nApellido: " + c.apellido);
            return retorno.ToString();
        }

        public static bool operator ==(Comerciante a, Comerciante b)
        {
            return (a.nombre == b.nombre && a.apellido == b.apellido);
        }
        public static bool operator !=(Comerciante a, Comerciante b)
        {
            return !(a == b);
        }

    }
}
