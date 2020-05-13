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
                double retorno = 0;
                foreach (Libro libro in this.libros)
                {
                    if (libro is Manual)
                    {
                        retorno += (Single)(Manual)libro;
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
                foreach (Libro libro in this.libros)
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
            retorno.AppendFormat("Total por manuales: {0}\n", b.ObtenerPrecio(ELibro.PrecioDeManuales));
            retorno.AppendFormat("Total por novelas: {0}\n", b.ObtenerPrecio(ELibro.PrecioDeNovelas));
            retorno.AppendFormat("Total: {0}\n", b.ObtenerPrecio(ELibro.PrecioTotal));
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
            if (tipoLibro == ELibro.PrecioDeManuales)
            {
                retorno += PrecioDeManuales;
            }
            else if (tipoLibro == ELibro.PrecioDeNovelas)
            {
                retorno += PrecioDeNovelas;
            }
            else if (tipoLibro == ELibro.PrecioTotal)
            {
            retorno += PrecioTotal;
            }
            return retorno;
        }
        #endregion
    }
}
