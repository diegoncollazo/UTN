using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Libro
    {
        #region Atributos
        protected Autor autor;
        protected int cantidadDePaginas;
        protected static Random generadorDePaginas;
        protected float precio;
        protected string titulo;
        #endregion

        #region Propiedades
        public int CantidadDePaginas
        {
            get
            {
                if (cantidadDePaginas == 0)
                    this.cantidadDePaginas = generadorDePaginas.Next(10, 570);
                return this.cantidadDePaginas;
            }
        }
        #endregion

        #region Constructores
        static Libro()
        {
            Libro.generadorDePaginas = new Random();
        }

        public Libro(float precio, string titulo, Autor autor)
        {
            this.precio = precio;
            this.titulo = titulo;
            this.autor = autor;
            this.cantidadDePaginas = CantidadDePaginas;
        }

        public Libro(string titulo, string nombre, string apellido, float precio) : this(precio, titulo, new Autor(nombre, apellido))
        {

        }
        #endregion

        #region Metodos
        private static string Mostrar(Libro l)
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append((string)l.autor);
            retorno.AppendFormat("TITULO: {0}\n", l.titulo);
            retorno.AppendFormat("CANTIDAD DE PAGINAS: {0}\n", l.CantidadDePaginas);
            retorno.AppendFormat("PRECIO: {0}\n", l.precio);

            return retorno.ToString();
        }

        public static bool operator ==(Libro a, Libro b)
        {
            return a.titulo == b.titulo && (Autor)a.autor == (Autor)b.autor;
        }
        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }

        public static explicit operator string(Libro l)
        {
            return Libro.Mostrar(l);
        }
        #endregion
    }
}
