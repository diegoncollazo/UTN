using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Shopping
    {
        private int _capacidad;
        private List<Comercio> _comercios;

        public double PrecioDeExportadores
        {
            get
            {
                return ObtenerPrecio(EComercio.Exportador);
            }
        }

        public double PrecioDeImportadores
        {
            get
            {
                return ObtenerPrecio(EComercio.Importador);
            }
        }

        public double PrecioTotal
        {
            get
            {
                return ObtenerPrecio(EComercio.Ambos);
            }
        }

        //Lista de Comercios
        private Shopping()
        {
            this._comercios = new List<Comercio>(_capacidad);
        }
        //Capacidad Shopping
        private Shopping(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public static implicit operator Shopping(int capacidad)
        {
            Shopping shopping = new Shopping(capacidad);
            return shopping;
        }

        public static string Mostrar(Shopping s)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Capacidad total de comercios: {0}\n", s._capacidad);
            retorno.AppendFormat("Total por Importaciones: $ {0}\n", s.PrecioDeImportadores);
            retorno.AppendFormat("Total por Exportaciones: $ {0}\n", s.PrecioDeExportadores);
            retorno.AppendFormat("Total: $ {0}\n", s.PrecioTotal);
            foreach (Comercio item in s._comercios)
            {
                if (item is Importador)
                    retorno.AppendLine(((Importador)(item)).Mostrar());
                else if (item is Exportador)
                    retorno.AppendLine(((Exportador)(item)).Mostrar());
            }
            return retorno.ToString();
        }

        public static Shopping operator +(Shopping s, Comercio c)
        {
            if (s._comercios.Count < s._capacidad)
            {
                if (s != c)
                    s._comercios.Add(c);
                else
                    Console.WriteLine("No se puede agregar el comercio.");
            }
            else
            {
                Console.WriteLine("Shopping lleno.");
            }
            return s;
        }

        public static bool operator ==(Shopping s, Comercio c)
        {
            bool retorno = false;
            foreach (Comercio item in s._comercios)
            {
                if (item == c)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Shopping s, Comercio c)
        {
            return !(s == c);
        }

        private double ObtenerPrecio(EComercio tipoComercio)
        {
            double retorno = new double();
            foreach(Comercio item in this._comercios)
            {
                if (tipoComercio == EComercio.Ambos && item is Exportador) 
                    retorno += (Exportador)item;
                if (tipoComercio == EComercio.Ambos && item is Importador)
                    retorno += (Importador)item;
                if (tipoComercio == EComercio.Exportador && item is Exportador)
                    retorno += (Exportador)item;
                if (tipoComercio == EComercio.Importador && item is Importador)
                    retorno += (Importador)item;
            }
            return retorno;
        }
    }
}
