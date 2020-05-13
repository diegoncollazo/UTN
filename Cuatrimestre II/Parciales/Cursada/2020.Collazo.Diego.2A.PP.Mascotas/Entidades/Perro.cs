using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perro : Mascota
    {
        private int edad;
        private bool esAlfa;

        public Perro(string nombre, string raza) : this(nombre, raza, 0, false)
        {

        }        
        public Perro(string nombre, string raza, int edad, bool esAlfa) : base(nombre, raza)
        {
            this.edad = edad;
            this.esAlfa = esAlfa;
        }
        protected override string Ficha()
        {
            string retorno = null;
            if (this.esAlfa)
                retorno = "perro - " + base.DatosCompletos() + ", es alfa de la manada, edad " + this.edad;
            else
                retorno = "perro - " + base.DatosCompletos() + ", edad " + this.edad;
            return retorno;
        }
        public static bool operator ==(Perro m1, Perro m2)
        {
            return (Mascota)m1 == (Mascota)m2 && (int)m1 == (int)m2;
        }
        public static bool operator !=(Perro m1, Perro m2)
        {
            return !(m1 == m2);
        }
        public static explicit operator int(Perro perro)
        {
            return perro.edad;
        }
        public override string ToString()
        {
            return this.Ficha();
        }
        public override bool Equals(object obj)
        {
            return obj is Perro && (Perro)obj == this;
        }
    }
}
