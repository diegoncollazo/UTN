using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics._2020
{
    public class Restrictiva<T> where T : MiClase
    {
        public List<T> miLista;

        public Restrictiva()
        {
            this.miLista = new List<T>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in this.miLista)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
