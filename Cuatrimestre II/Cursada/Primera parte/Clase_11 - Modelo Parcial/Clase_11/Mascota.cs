using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_11
{
    public abstract class Mascota
    {
        private string _nombre;
        private string _raza;

        #region Get

        public string Nombre
        {
            get
            {
                return this._nombre;
            } 
        }

        public string Raza
        {
            get
            {
                return this._raza;
            }
        }

        #endregion

        #region Construtor

        public Mascota(string nombre, string raza)
        {
            this._nombre = nombre;
            this._raza = raza;
        }

        #endregion

        #region Metodos Abstact - Polimorfismo

        protected abstract string Ficha();

        protected virtual string DatosCompletos()
        {
            return this.Nombre + " " + this.Raza;
        }

        #endregion
    }
}
