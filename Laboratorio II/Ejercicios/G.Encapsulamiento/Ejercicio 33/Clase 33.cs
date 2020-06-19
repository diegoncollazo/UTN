using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_33
{
    public class Libro
    {
        private List<string> paginas;

        public string this[int i]
        {
            get
            {
                string retorno = "";
                if (i <= this.paginas.Count)
                    retorno = paginas[i];
                return retorno;
            }
        }
        public Libro()
        {
            this.paginas = new List<string>();
        }
    }
}
