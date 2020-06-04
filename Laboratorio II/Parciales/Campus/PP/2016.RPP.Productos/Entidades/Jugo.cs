using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo : Producto
    {
        public enum ESaborJugo
        {
            Asqueroso,
            Pasable,
            Rico
        }
        protected ESaborJugo _sabor;
        protected static bool DeConsumo;
        /// <summary>
        /// 
        /// </summary>
        public override float CalcularCostoDeProducto
        {
            get
            {
                return this._precio * (float) 1.40;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        static Jugo()
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
        public Jugo(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor) : base(codigoBarra, marca, precio)
        {
            this._sabor = sabor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string MostrarJugo()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append((string)this);
            retorno.AppendFormat("\nSabor:              {0}", this._sabor);
            retorno.AppendFormat("\nEs de consumo:      {0}", Jugo.DeConsumo);
            return retorno.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarJugo();
        }

        public override string Consumir()
        {
            return "Bebible";
        }
    }
}
