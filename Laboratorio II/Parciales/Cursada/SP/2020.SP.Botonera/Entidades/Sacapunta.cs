using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Sacapunta-> deMetal:bool(público); 
    //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
    public class Sacapunta : Utiles
    {

        public bool deMetal;
        //Asigno el valor TRUE a PreciosCuidados
        public override bool PreciosCuidados { get { return false; } }

        public Sacapunta(bool deMetal, double precio, string marca)
            : base(marca, precio)
        {
            this.deMetal = deMetal;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append(base.ToString());
            retorno.AppendLine("De metal: " + this.deMetal.ToString());

            return retorno.ToString();
        }
    }
}
