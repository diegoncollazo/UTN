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
            return base.DatosCompletos();
        }

        public static bool operator ==(Gato gato1, Gato gato2)
        {
            return (gato1.Nombre == gato2.Nombre && gato1.Raza == gato2.Raza);
        }
        public static bool operator !=(Gato gato1, Gato gato2)
        {
            return !(gato1 == gato2);
        }

        public override string ToString()
        {
            return this.Ficha();
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Gato)
            {
                if ((Gato)obj == this)
                    retorno = true;
                else
                    retorno = false;
            }
            return retorno;
        }
    }
}
