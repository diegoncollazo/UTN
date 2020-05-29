using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics._2020
{
    public class Mensajero<T, U>
    {
        public T miAtr1;
        public U miAtr2;
        private Dictionary<T, U> miDiccionario;

        public Mensajero()
        {
            this.miAtr1 = default;
            this.miAtr2 = default(U);
            this.miDiccionario = new Dictionary<T, U>();
        }

        public override string ToString()
        {
            return this.miAtr1.ToString() + " - " + this.miAtr2.ToString() + " - " + this.miDiccionario.Count.ToString();
        }
    }
}
