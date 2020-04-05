using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        #region Enumerados
        public enum EMarcaProducto
        {
            Manaos,
            Pitusas,
            Naranjú,
            Diversión,
            Swift,
            Favorita
        }
        public enum ETipoProducto
        {
            Galletita,
            Gaseosa,
            Harina,
            Jugo,
            Todos
        }
        #endregion

        #region Atributos
        protected int _codigoBarra;
        protected EMarcaProducto _marca;
        protected float _precio;
        #endregion

        #region Propiedades
        public abstract float CalcularCostoDeProducto{ get; }

        public EMarcaProducto Marca
        {
            get
            {
                return this._marca;
            }
        }
        public int CodigoDeBarra
        {
            get
            {
                return this._codigoBarra;
            }
        }
        public float Precio
        {
            get
            {
                return this._precio;
            }
        }
        #endregion

        #region Constructores
        public Producto(int codigoBarra, EMarcaProducto marca, float precio)
        {
            this._codigoBarra = codigoBarra;
            this._marca = marca;
            this._precio = precio;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string Consumir()
        {
            return "Parte de una mezcla.";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static string MostrarProducto(Producto p)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nCódigo de barra:    {0}", p._codigoBarra);
            retorno.AppendFormat("\nMarca:              {0}", p.Marca);
            retorno.AppendFormat("\nPrecio:             {0}", p.Precio);
            return retorno.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobreescribo el método Equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Producto && (Producto)obj == this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="producto1"></param>
        /// <param name="producto2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto producto1, Producto producto2)
        {
            bool retorno = new bool();
            retorno = false;
            if (producto1._marca == producto2._marca && producto1._codigoBarra == producto2._codigoBarra)
                retorno = true;
            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="producto1"></param>
        /// <param name="producto2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto producto1, Producto producto2)
        {
            return !(producto1 == producto2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="producto1"></param>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static bool operator ==(Producto producto1, EMarcaProducto marca)
        {
            bool retorno = new bool();
            if (producto1._marca == marca)
                retorno = true;
            retorno = false;
            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="producto1"></param>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static bool operator !=(Producto producto1, EMarcaProducto marca)
        {
            return !(producto1 == marca);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator int(Producto p)
        {
            return p._codigoBarra;
        }

        public static implicit operator string(Producto p)
        {
            return MostrarProducto(p);
        }


        #endregion
        }
}
