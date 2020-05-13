using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gato : Mascota
    {

        public Gato(string nombre, string raza) : base(nombre, raza)
        {

        }        

        protected override string Ficha()
        {
            return "gato - " + base.DatosCompletos();
        }
        public static bool operator ==(Gato m1, Gato m2)
        {
            return (Mascota)m1 == (Mascota)m2;
        }
        public static bool operator !=(Gato m1, Gato m2)
        {
            return !(m1 == m2);
        }
        public override string ToString()
        {
            return this.Ficha();
        }
        public override bool Equals(object obj)
        {
            return obj is Gato && (Gato)obj == this;
        }
    }
}
