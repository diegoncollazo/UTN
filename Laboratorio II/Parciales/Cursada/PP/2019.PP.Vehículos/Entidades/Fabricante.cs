using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabricante
    {
        private string marca;
        private EPais pais;

        public Fabricante(string marca, EPais pais)
        {
            this.marca = marca;
            this.pais = pais;
        }

        public static implicit operator string(Fabricante f)
        {
            return "Marca: " + f.marca + " - Origen: " + f.pais;
        }

        public static bool operator ==(Fabricante a, Fabricante b)
        {
            return (a.marca == b.marca && a.pais == b.pais);
        }
        public static bool operator !=(Fabricante a, Fabricante b)
        {
            return !(a == b);
        }

    }
}
