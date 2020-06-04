using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        private string codigoDeBarra;
        private string marca;
        private float precio;

        public Producto(string marca, string codigo, float precio)
        {
            this.marca = marca;
            this.codigoDeBarra = codigo;
            this.precio = precio;
        }
        public string GetMarca()
        {
            return this.marca;
        }
        public float GetPrecio()
        {
            return this.precio;
        }
        public static string MostrarProducto(Producto producto)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Marca: {0}\n", producto.marca);
            retorno.AppendFormat("Precio: {0}\n", producto.precio);
            retorno.AppendFormat("Codigo: {0}\n", (string)(producto));
            return retorno.ToString();
        }
        public static explicit operator string(Producto producto)
        {
            return producto.codigoDeBarra;
        }
        public static bool operator ==(Producto p1, Producto p2)
        {
            return !(p2 is null) && p1 == p2.marca && p1.codigoDeBarra == p2.codigoDeBarra;
        }
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
        public static bool operator ==(Producto p, string marca)
        {
            return (!(p is null) && p.marca == marca);
        }
        public static bool operator !=(Producto p, string marca)
        {
            return !(p == marca);
        }
    }

}
