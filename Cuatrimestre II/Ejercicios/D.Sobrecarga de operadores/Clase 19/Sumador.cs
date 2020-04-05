using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_19
{
    public class Sumador
    {
        //Atributos
        private int cantidadSumas;
        //Constructores
        public Sumador() : this(0)
        {

        }
        public Sumador(int cantidadSumas)
        {
            this.cantidadSumas = cantidadSumas;
        }
        //Explicit INT
        public static explicit operator int(Sumador S)
        {
            return S.cantidadSumas;
        }
        //Pipe
        public static bool operator |(Sumador s1, Sumador s2)
        {
            bool retorno = false;
            if (s1.cantidadSumas == s2.cantidadSumas)
                retorno = true;
            return retorno;
        }
        //Sumador
        public static long operator +(Sumador s1, Sumador s2)
        {
            return s1.cantidadSumas + s2.cantidadSumas;
        }
        //Metodo Sumar con long
        public long Sumar(long a, long b)
        {
            this.cantidadSumas++;
            return (a + b);
        }
        //Metodo Sumar con string
        public string Sumar(string a, string b)
        {
            string resultado = null;
            bool r1 = long.TryParse(a, out long c);
            bool r2 = long.TryParse(b, out long d);
            if (r1 && r2)
                resultado = Sumar(c, d).ToString();
            return resultado;
        }
    }
}
