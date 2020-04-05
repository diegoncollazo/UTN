using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Harina : Producto
    {
        public enum ETipoHarina
        {
            CuatroCeros,
            TresCeros,
            Integral
        }

        protected ETipoHarina _tipo;
        protected static bool DeConsumo;
        /// <summary>
        /// 
        /// </summary>
        public override float CalcularCostoDeProducto
        {
            get
            {
                return this._precio * (float) 1.60;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        static Harina()
        {
            DeConsumo = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="tipo"></param>
        public Harina(int codigoBarra, float precio, EMarcaProducto marca, ETipoHarina tipo) : base(codigoBarra, marca, precio)
        {
            this._tipo = tipo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string MostrarHarina()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append((string)this);
            retorno.AppendFormat("\nTipo:              {0}", this._tipo);
            retorno.AppendFormat("\nEs de consumo:      {0}", Harina.DeConsumo);
            return retorno.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarHarina();
        }
    }
}
