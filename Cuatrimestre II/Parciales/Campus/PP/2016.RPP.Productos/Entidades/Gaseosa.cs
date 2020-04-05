using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Gaseosa : Producto
    {

        protected float _litros;
        protected static bool DeConsumo;
        /// <summary>
        /// 
        /// </summary>
        public override float CalcularCostoDeProducto
        {
            get
            {
                return this._precio * (float) 1.42;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        static Gaseosa()
        {
            DeConsumo = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="sabor"></param>
        public Gaseosa(int codigoBarra, float precio, EMarcaProducto marca, float litros) : base(codigoBarra, marca, precio)
        {
            this._litros = litros;
        }

        public Gaseosa(Producto producto, float litros) : this(producto.CodigoDeBarra, producto.Precio, producto.Marca, litros)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string MostrarGaseosa()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append((string)this);
            retorno.AppendFormat("\nLitros:              {0}", this._litros);
            retorno.AppendFormat("\nEs de consumo:      {0}", Gaseosa.DeConsumo);
            return retorno.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarGaseosa();
        }

        public override string Consumir()
        {
            return "Bebible";
        }

}
}
