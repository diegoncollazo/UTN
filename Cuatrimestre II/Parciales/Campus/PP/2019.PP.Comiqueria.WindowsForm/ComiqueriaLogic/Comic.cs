using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    
    public class Comic : Producto
    {
        public enum TipoComic
        {
            Occidental,
            Oriental
        }
        //Atributos
        private TipoComic tipoComic;
        private string autor;
        //Constructores
        public Comic(string descripcion, int stock, double precio, string autor, TipoComic tipoComic) : base(descripcion, stock, precio)
        {
            this.tipoComic = tipoComic;
            this.autor = autor;
        }
        //Metodos
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.ToString());
            retorno.AppendFormat("\nAutor: {0}\n", this.autor);
            retorno.AppendFormat("Tipo de cómic: {0}\n", this.tipoComic.ToString());
            return retorno.ToString();
        }
    }
}
