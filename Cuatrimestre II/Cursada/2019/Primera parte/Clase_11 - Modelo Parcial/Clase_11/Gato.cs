using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_11
{
    public class Gato : Mascota
    {
        #region Constructor

        public Gato(string nombre, string raza) : base (nombre, raza)
        {

        }

        #endregion

        #region Metodos Abstract - Polimorfismo

        protected override string Ficha()
        {
            return base.DatosCompletos();
        }

        #endregion

        #region Sobrecarga de Operadores

        public static bool operator ==(Gato gato1, Gato gato2)
        {
            bool retorno = false;

            if (gato1.Nombre == gato2.Nombre && gato1.Raza == gato2.Raza)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Gato gato1, Gato gato2)
        {
            return !(gato1 == gato2);
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

            if (obj is Gato)
            {
                if ((Gato)obj == this)
                {
                    retorno = true;
                }

                else
                {
                    retorno = false;
                }
            }

            return retorno;
        }

        #endregion
    }
}
