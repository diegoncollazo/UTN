using System;

namespace Entidades
{
    public class Autor
    {
        private string nombre;
        private string apellido;

        public Autor(string nombre, string apellido)
        {
            this.apellido = apellido;
            this.nombre = nombre;
        }

        public static bool operator ==(Autor a, Autor b)
        {
            bool retorno = false;

            if(a.nombre == b.nombre && a.apellido == b.apellido)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Autor a, Autor b)
        {
            return !(a == b);
        }

        public static implicit operator string(Autor a)
        {
            return a.nombre + " " + a.apellido;
        }
    }
}
