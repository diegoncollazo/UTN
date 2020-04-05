using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmpleadoMejorado
    {
        //Atributos
        private string _nombre;
        private int _legajo;
        private float _sueldo;

        public event DelSueldo _limiteSueldo;
        //Propiedades
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }
        public int Legajo
        {
            get
            {
                return this._legajo;
            }
            set
            {
                this._legajo = value;
            }
        }
        public float Sueldo
        {
            get
            {
                return this._sueldo;
            }
            set
            {
                if (value > 12000)
                {
                    EmpleadoSueldoArs sueldoArs = new EmpleadoSueldoArs();

                    this._limiteSueldo(this, sueldoArs);
                }
                else
                    this._sueldo = value;
            }
        }
        //ToString
        public override string ToString()
        {
            return "Nombre: " + this._nombre + " con legajo " + this._legajo.ToString() + " y sueldo de: $" + this._sueldo.ToString();
        }

    }
}
