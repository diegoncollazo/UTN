using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Remedio : Objetos
    {
        //Remedio-> tipo:string (público); marca:string; (público); precio:float (público); 
        //ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).


        public Remedio(string tipo, string marca, float precio) : base(tipo, marca, precio)
        {
            
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append(base.ToString());

            return retorno.ToString();
        }
    }
}
