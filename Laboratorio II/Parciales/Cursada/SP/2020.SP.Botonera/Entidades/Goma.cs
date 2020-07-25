using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Goma-> soloLapiz:bool(público); PreciosCuidados->true; 
    //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
    public class Goma : Utiles
    {

        public bool soloLapiz;
        //Asigno el valor TRUE a PreciosCuidados
        public override bool PreciosCuidados { get { return true; } }
        public Goma(bool soloLapiz, string marca, double precio )
            : base(marca, precio)
        {
            this.soloLapiz = soloLapiz;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append(base.ToString());
            retorno.AppendLine("Solo lapiz: " + this.soloLapiz.ToString());

            return retorno.ToString();
        }
    }
}
