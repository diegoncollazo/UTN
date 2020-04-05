using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Galletita : Producto
    {

        protected float _peso;
        protected static bool DeConsumo;
        /// <summary>
        /// 
        /// </summary>
        public override float CalcularCostoDeProducto
        {
            get
            {
                return this._precio * (float) 1.33;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        static Galletita()
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
        public Galletita(int codigoBarra, float precio, EMarcaProducto marca, float peso) : base(codigoBarra, marca, precio)
        {
            this._peso = peso;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string MostrarGalletita()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append((string)this);
            retorno.AppendFormat("\nPeso:              {0}", this._peso);
            retorno.AppendFormat("\nEs de consumo:      {0}", Galletita.DeConsumo);
            return retorno.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarGalletita();
        }

        public override string Consumir()
        {
            return "Comestible";
        }

}
}
