using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Biblioteca
    {
        private int _capacidad;
        private List<Libro> _libros;

        private Biblioteca()
        {
            this._libros = new List<Libro>();
        }

        private Biblioteca(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public double PrecioDeManuales
        {
            get
            {
                double retorno = 0;
                foreach (Libro libro in this._libros)
                {
                    if (libro is Manual)
                    {
                        retorno += (Manual)libro;
                    }
                }
                return retorno;
            }
        }
        public double PrecioDeNovelas
        {
            get
            {
                double retorno = 0;
                foreach (Libro libro in this._libros)
                {
                    if (libro is Novela)
                    {
                        retorno += (Novela)libro;
                    }
                }
                return retorno;
            }
        }
        public double PrecioTotal
        {
            get
            {
                return PrecioDeManuales + PrecioDeNovelas;
            }
        }

        public static string Mostrar(Biblioteca e)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("**********************************************");
            retorno.AppendLine("Listado de libros");
            retorno.AppendLine("**********************************************");
            foreach (Libro libro in e._libros)
            {
                retorno.AppendLine((string)libro);
                retorno.Append("\n");
            }
            return retorno.ToString();
        }

        public double ObtenerPrecio(ELibro tipoLibro)
        {
            double retorno = 0;
            foreach (Libro libro in this._libros)
            {
                if (tipoLibro == ELibro.Manual && libro is Manual)
                {
                    retorno += (Manual)libro;
                }
                else if (tipoLibro == ELibro.Novela && libro is Novela)
                {
                    retorno += (Novela)libro;
                }
                else if (tipoLibro == ELibro.Ambos)
                {
                    if (libro is Novela)
                    {
                        retorno += (Novela)libro;
                    }
                    else if (libro is Manual)
                    {
                        retorno += (Manual)libro;
                    }
                }
            }
            return retorno;
        }

        public static Biblioteca operator +(Biblioteca e, Libro l)
        {
            bool bandera = true;

            if (e == l)
            {
                bandera = false;
                Console.WriteLine("¡El libro ya esta en la biblioteca!\n");
            }
            if (bandera == true && e._libros.Count < e._capacidad)
            {
                e._libros.Add(l);
            }
            if (bandera == true && e._libros.Count == e._capacidad)
            {
                Console.WriteLine("Atención: No hay mas lugar en la biblioteca.\n");
            }
            return e;
        }
        
        public static bool operator ==(Biblioteca e, Libro l)
        {
            bool retorno = false;
            foreach (Libro item in e._libros)
            {
                if (item == l)
                {
                    if (l is Manual && (Manual)l == (Manual)item)
                        retorno = true;
                    if (l is Novela && (Novela)l == (Novela)item)
                        retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Biblioteca e, Libro l)
        {
            return !(e == l);
        }

        public static implicit  operator Biblioteca(int capacidad)
        {
            Biblioteca biblioteca = new Biblioteca(capacidad);
            return biblioteca;
        }
    }
}
