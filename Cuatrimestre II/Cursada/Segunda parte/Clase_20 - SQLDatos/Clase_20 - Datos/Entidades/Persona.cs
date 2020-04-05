using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        #region "Atributos"
        public string nombre;
        public string apellido;
        public int edad;
        public int id;
        #endregion

        #region "Constructor"
        public Persona(int id, string nombre, string apellido, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.id = edad;
        }
        #endregion

        #region "ToString"
        public override string ToString()
        { 
            return ("ID: " + this.id + " - Nombre: " + this.nombre + " - Apellido: " + this.apellido + " - Edad: " + this.edad);
        }
        #endregion
    }
}
