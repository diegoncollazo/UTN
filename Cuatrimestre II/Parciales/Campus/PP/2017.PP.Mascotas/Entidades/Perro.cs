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

        public int Edad
        {
            get
            {
                return this.edad;
            }
            set
            {
                this.edad = value;
            }
        }

        public bool EsAlfa
        {
            get
            {
                return this.esAlfa;
            }
            set
            {
                this.esAlfa = value;
            }
        }

        public Perro(string nombre, string raza) : this(nombre, raza, 0, false)
        {

        }

        public Perro(string nombre, string raza, int edad, bool alfa) : base(nombre, raza)
        {
            this.Edad = edad;
            this.EsAlfa = alfa;
        }

        protected override string Ficha()
        {
            string retorno;
            if (this.EsAlfa)
                retorno = String.Format("{0}, alfa de la manada, edad {1}", this.DatosCompletos(), this.Edad);
            else
                retorno = String.Format("{0}, edad {1}", this.DatosCompletos(), this.Edad);
            return retorno;
        }

        public static bool operator ==(Perro perro1, Perro perro2)
        {
            return (perro1.Nombre == perro2.Nombre && perro1.Raza == perro2.Raza && perro1.Edad == perro2.Edad);
        }
        public static bool operator !=(Perro perro1, Perro perro2)
        {
            return !(perro1 == perro2);
        }

        public static explicit operator int(Perro perro)
        {
            return perro.Edad;
        }

        public override string ToString()
        {
            return this.Ficha();
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Perro)
            {
                if ((Perro)obj == this)
                    retorno = true;
                else
                    retorno = false;
            }
            return retorno;
        }
    }
}
