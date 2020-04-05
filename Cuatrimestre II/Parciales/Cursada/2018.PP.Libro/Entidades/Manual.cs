using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Manual : Libro
    {
        public ETipo tipo;

        public Manual(string titulo, float precio, string nombre, string apellido, ETipo tipo) : base(precio, titulo, nombre, apellido)
        {
            this.tipo = tipo;
        }

        public string Mostrar()
        {
            return (string)this +"\nTIPO: " + this.tipo;
        }

        public static implicit operator double(Manual m)
        {
            return m._precio;
        }

        public static bool operator ==(Manual a, Manual b)
        {
            bool retorno = false;
            if ((Libro)a == (Libro)b && a.tipo == b.tipo)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Manual a, Manual b)
        {
            return !(a == b);
        }

    }
}
