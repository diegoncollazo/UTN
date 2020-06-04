using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estante
    {
        private Producto[] productos;
        private int ubicacionEstante;

        private Estante(int capacidad)
        {
            this.productos = new Producto[capacidad];
        }
        public Estante(int capacidad, int ubicacion) : this(capacidad)
        {
            this.ubicacionEstante = ubicacion;
        }

        public Producto[] GetProductos()
        {
            return this.productos;
        }
        public static string MostrarEstante(Estante estante)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Estante n°: {0}\n", estante.ubicacionEstante);
            retorno.AppendLine("Productos en el estante:");
            for (int i = 0; i < estante.productos.Length; i++)
            {
                retorno.AppendLine(Producto.MostrarProducto(estante.productos[i]));
            }
            return retorno.ToString();
        }
        public static bool operator ==(Estante e, Producto p)
        {
            bool retorno = false;
            for (int i = 0; i < e.productos.Length; i++)
                if (e.productos[i] == p)
                    retorno = true;
            return retorno;
        }
        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }
        public static bool operator +(Estante e, Producto p)
        {
            bool retorno = false;
            if (e != p)
            {
                Producto[] productosAux = e.GetProductos();
                for (int i = 0; i < e.GetProductos().Length; i++)
                {
                    if (productosAux[i] is null)
                    {
                        productosAux[i] = p;
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        public static bool operator -(Estante e, Producto p)
        {
            bool retorno = false;
            if (e == p)
            {
                Producto[] productosAux = e.GetProductos();
                for (int i = 0; i < e.GetProductos().Length; i++)
                {
                    if (productosAux[i] == p)
                    {
                        productosAux[i] = null;
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
    }
}
