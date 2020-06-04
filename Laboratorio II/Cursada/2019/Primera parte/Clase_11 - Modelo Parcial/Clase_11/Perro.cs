using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_11
{
    public class Perro : Mascota
    {
        private int _edad;
        private bool _esAlfa;

        #region Construtores

        public Perro(string nombre, string raza, int edad, bool esAlfa) : base(nombre, raza)
        {
            this._edad = edad;
            this._esAlfa = esAlfa;
        }

        public Perro(string nombre, string raza) : this (nombre, raza, 0, false)
        {

        }

        #endregion

        #region Metodos Abstract - Polimorfismo

        protected override string Ficha()
        {
            string retorno = "";

            if (this._esAlfa == true)
            {
                retorno = this.DatosCompletos() + " - Alfa de la manada " + "- Edad: " + this._edad; 
            }

            else
            {
                retorno = this.DatosCompletos() + " - Edad: " + this._edad;
            }

            return retorno;
        }

        #endregion

        #region Sobrecarga de Operadores

        public static bool operator ==(Perro perro1, Perro perro2)
        {
            bool retorno = false;

            if(perro1.Nombre == perro2.Nombre && perro1.Raza == perro2.Raza && perro1._edad == perro2._edad)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Perro perro1, Perro perro2)
        {
            return !(perro1 == perro2);
        }

        public static explicit operator int(Perro perro)
        {
            return perro._edad;
        }

        #endregion

        #region Sobreescribir

        public override string ToString()
        {
            return this.Ficha();
        }

        //METODO EQUALS
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if(obj is Perro)
            {
                if((Perro)obj == this)
                {
                    retorno = true;
                }

            }

            return retorno;
        }

        #endregion


    }
}
