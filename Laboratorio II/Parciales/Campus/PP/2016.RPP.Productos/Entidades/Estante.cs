using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estante
    {
        protected sbyte capacidad;
        protected List<Producto> productos;

        private Estante()
        {
            this.productos = new List<Producto>();
        }
        public Estante(sbyte capacidad) : this()
        {
            this.capacidad = capacidad;
        }
        //Propiedad de solo lectura
        public float ValorEstanteTotal
        {
            get
            {
                return GetValorEstante();
            }
        }
        public List<Producto> GetProductos()
        {
            return this.productos;
        }
        public float GetValorEstante()
        {
            return GetValorEstante(Producto.ETipoProducto.Todos);
        }

        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float retorno = 0;
            foreach(Producto item in this.productos)
            { 
                switch (tipo)
                {
                    case Producto.ETipoProducto.Galletita:
                        if (item is Galletita)
                            retorno += ((Galletita)(item)).Precio;
                        break;
                    case Producto.ETipoProducto.Gaseosa:
                        if (item is Gaseosa)
                            retorno += ((Gaseosa)(item)).Precio;
                        break;
                    case Producto.ETipoProducto.Harina:
                        if (item is Harina)
                            retorno += ((Harina)(item)).Precio;
                        break;
                    case Producto.ETipoProducto.Jugo:
                        if (item is Jugo)
                            retorno += ((Jugo)(item)).Precio;
                        break;
                    case Producto.ETipoProducto.Todos:
                        retorno += item.Precio;
                        break;
                }
            }
            return retorno;
        }
        //Muestro info completa estante
        public static string MostrarEstante(Estante e)
        {
            StringBuilder retorno = new StringBuilder();
            foreach(Producto item in e.productos)
            {
                if (item is Galletita)
                    retorno.AppendLine(((Galletita)(item)).ToString());
                else if (item is Gaseosa)
                    retorno.AppendLine(((Gaseosa)(item)).ToString());
                else if (item is Harina)
                    retorno.AppendLine(((Harina)(item)).ToString());
                else if (item is Jugo)
                    retorno.AppendLine(((Jugo)(item)).ToString());
            }
            return retorno.ToString();
        }

        public static bool operator ==(Estante estante, Producto producto)
        {
            bool retorno = false;
            foreach (Producto item in estante.productos)
            {
                if (item == producto)
                {
                    if (item is Galletita)
                        retorno = true;
                    else if (item is Gaseosa)
                        retorno = true;
                    else if (item is Harina)
                        retorno = true;
                    else if (item is Jugo)
                        retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Estante estante, Producto producto)
        {
            return !(estante == producto);
        }

        public static bool operator +(Estante e, Producto p)
        {
            bool retorno = false;
            if (e.productos.Count < e.capacidad && e != p)
            {
                e.productos.Add(p);
                retorno = true;
            }
            return retorno;
        }

        public static Estante operator -(Estante e, Producto p)
        {
            if (e == p)
                e.productos.Remove(p);
            return e;
        }
        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {
            if (tipo == Producto.ETipoProducto.Todos)
            {
                e.productos.Clear();
            }
            else
            { 
                for (int i = 0; i < e.productos.Count; i++)
                {
                    if (tipo == Producto.ETipoProducto.Galletita && e.productos[i] is Galletita)
                    {
                        e.productos.RemoveAt(i);
                        i--;
                    }
                    else if (tipo == Producto.ETipoProducto.Gaseosa && e.productos[i] is Gaseosa)
                    {
                        e.productos.RemoveAt(i);
                        i--;
                    }
                    else if (tipo == Producto.ETipoProducto.Harina && e.productos[i] is Harina)
                    {
                        e.productos.RemoveAt(i);
                        i--;
                    }
                    else if (tipo == Producto.ETipoProducto.Jugo && e.productos[i] is Jugo)
                    {
                        e.productos.RemoveAt(i);
                        i--;
                    }
                }
            }
            return e;
        }
    }
}
