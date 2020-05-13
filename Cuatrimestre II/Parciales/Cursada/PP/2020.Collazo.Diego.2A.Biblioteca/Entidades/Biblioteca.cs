using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Biblioteca
    {
        #region Atributos
        private int capacidad;
        private List<Libro> libros;
        #endregion

        #region Propiedades
        public double PrecioDeManuales
        {
            get
            {
                return ObtenerPrecio(ELibro.PrecioDeManuales);
            }
        }
        public double PrecioDeNovelas
        {
            get
            {
                return ObtenerPrecio(ELibro.PrecioDeNovelas);
            }
        }
        public double PrecioTotal
        {
            get
            {
                return ObtenerPrecio(ELibro.PrecioTotal);
            }
        }
        #endregion

        #region Constructores
        private Biblioteca()
        {
            this.libros = new List<Libro>();
        }

        private Biblioteca(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }
        #endregion

        #region Metodos
        public static implicit operator Biblioteca(int capacidad)
        {
            Biblioteca biblioteca = new Biblioteca(capacidad);
            return biblioteca;
        }
        public static string Mostrar(Biblioteca b)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nCapacidad: {0}\n", b.capacidad);
            retorno.AppendFormat("Total por manuales: {0}\n", b.PrecioDeManuales);
            retorno.AppendFormat("Total por novelas: {0}\n", b.PrecioDeNovelas);
            retorno.AppendFormat("Total: {0}\n", b.PrecioTotal);
            retorno.AppendLine("**********************************************");
            retorno.AppendLine("Listado de libros");
            retorno.AppendLine("**********************************************");
            foreach (Libro libro in b.libros)
            {
                if (libro is Manual)
                    retorno.Append(((Manual)libro).ToString());
                if (libro is Novela)
                    retorno.Append(((Novela)libro).ToString());
                retorno.Append("\n");

            }
            return retorno.ToString();
        }
        public static bool operator ==(Biblioteca b, Libro l)
        {
            bool retorno = false;
            foreach (Libro item in b.libros)
            {
                if (item == l)
                {
                    if (l is Manual && (Manual)l == (Manual)item)
                    {
                        retorno = true;
                        break;
                    }  
                    if (l is Novela && (Novela)l == (Novela)item)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        public static bool operator !=(Biblioteca b, Libro l)
        {
            return !(b == l);
        }
        public static Biblioteca operator +(Biblioteca b, Libro l)
        {
            if (b == l)
            {
                Console.WriteLine("El libro ya esta en la biblioteca!!!\n");
            }
            else if (b.libros.Count < b.capacidad)
            {
                b.libros.Add(l);
            }
            else if (b.libros.Count == b.capacidad)
            {
                Console.WriteLine("No hay mas lugar en la biblioteca!!!\n");
            }
            return b;
        }
        private double ObtenerPrecio(ELibro tipoLibro)
        {
            double retorno = 0;
            foreach (Libro libro in this.libros)
                if (libro is Manual && tipoLibro == ELibro.PrecioDeManuales)
                     retorno += (Single)(Manual)libro;
                else if (libro is Novela && tipoLibro == ELibro.PrecioDeNovelas)
                    retorno += (Novela)libro;
                else if (tipoLibro == ELibro.PrecioTotal)
                    if (libro is Manual)
                        retorno += (Single)(Manual)libro;
                    else if (libro is Novela)
                        retorno += (Novela)libro;
            return retorno;
        }
        #endregion
    }
}
