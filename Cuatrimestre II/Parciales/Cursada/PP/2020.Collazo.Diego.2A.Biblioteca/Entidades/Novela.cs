using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Novela : Libro
    {
        #region Atributos
        private EGenero genero;
        #endregion

        #region Constructores
        public Novela(string titulo, float precio, Autor autor, EGenero genero) : base(precio, titulo, autor)
        {
            this.genero = genero;
        }
        #endregion

        #region Metodos
        public static bool operator ==(Novela a, Novela b)
        {
            return (Libro)a == (Libro)b && a.genero == b.genero;
        }
        public static bool operator !=(Novela a, Novela b)
        {
            return !(a == b);
        }
        public static implicit operator Single(Novela n)
        {
            return n.precio;
        }
        public override bool Equals(object obj)
        {
            return obj is Novela && (Novela)obj == this;
        }
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append(((string)(this)));
            retorno.AppendFormat("GENERO: {0}\n", this.genero.ToString());

            return retorno.ToString();
        }
        #endregion
    }
}
