using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Novela : Libro
    {
        public EGenero genero;

        public Novela(string titulo, float precio, Autor autor, EGenero genero) : base(titulo, autor, precio)
        {
            this.genero = genero;
        }

        public string Mostrar()
        {
            return (string)this + "\nGENERO: " + this.genero;
        }

        public static implicit operator double(Novela n)
        {
            return n._precio;
        }

        public static bool operator ==(Novela a, Novela b)
        {
            bool retorno = false;
            if (a._autor == b._autor && a._titulo == b._titulo && a.genero == b.genero)
                retorno = true;
            return retorno;
        }

        public static bool operator !=(Novela a, Novela b)
        {
            return !(a == b);
        }
    }
}
