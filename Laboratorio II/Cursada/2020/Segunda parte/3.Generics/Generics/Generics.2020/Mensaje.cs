using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics._2020
{
    public class Mensaje<T>
    {
        private T miAtributo;

        public T MiAtributo
        {
            get { return this.miAtributo; }
            set { this.miAtributo = value; }
        }

        public override string ToString()
        {
            return "miAtributo : " + this.miAtributo.ToString();
        }
    }
}
