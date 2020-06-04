using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Libro
    {
        protected Autor _autor;
        protected int _cantidadDePaginas;
        protected static Random _generadorDePaginas;
        protected float _precio;
        protected string _titulo;

        public int CantidadDePaginas
        {
            get
            {
                if (_cantidadDePaginas == 0)
                    this._cantidadDePaginas = _generadorDePaginas.Next(10, 580);
                return this._cantidadDePaginas;
            }
        }

        static Libro()
        {
            Libro._generadorDePaginas = new Random();
        }

        public Libro(string titulo, Autor autor, float precio) 
        {
            this._precio = precio;
            this._titulo = titulo;
            this._autor = autor;
            this._cantidadDePaginas = CantidadDePaginas;   
        }

        public Libro(float precio, string titulo, string nombre, string apellido) : this(titulo, new Autor(nombre, apellido), precio)
        {

        }

        public static explicit operator string(Libro l)
        {
            return Libro.Mostrar(l);
        }

        private static string Mostrar(Libro l)
        {
            return ("TITULO: " + l._titulo + "\nCANTIDAD DE PAGINAS: " + l.CantidadDePaginas + "\nAUTOR: $" + l._autor + "\nPRECIO: " + l._precio);
        }

        public static bool operator ==(Libro a, Libro b)
        {
            bool retorno = false;
            if(a._titulo == b._titulo && a._autor == b._autor)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }
    }
}
