using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    public class Producto
    {
        public string nombre;
        public int stock;

        public Producto(string nombre, int stock)
        {
            this.nombre = nombre;
            this.stock = stock;
        }

        public static bool operator ==(Producto producto1, Producto producto2)
        {
            return (producto1.nombre == producto2.nombre);
        }
        public static bool operator !=(Producto producto1, Producto producto2)
        {
            return !(producto1 == producto2);
        }
    }
}
