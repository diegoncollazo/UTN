using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public class Figura : Producto
    {
        //Atributos
        private double altura;
        //Constructores
        public Figura(string descripcion, int stock, double precio, double altura) : base(descripcion, stock, precio)
        {
            this.altura = altura;
        }
        public Figura(int stock, double precio, double altura) : this("Figura " + altura + " cm", stock, precio, altura)
        {
            
        }
        //Metodos
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.ToString());
            retorno.AppendFormat("\nAltura: {0}\n", this.altura.ToString());
            return retorno.ToString();
        }
    }
}
