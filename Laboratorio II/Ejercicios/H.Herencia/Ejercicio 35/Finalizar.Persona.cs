using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_35
{
    public class Persona
    {
        private long dni;
        private string nombre;
        public long DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public Persona(long dni, string nombre) : this(nombre)
        {
            this.DNI = dni;
        }
        public Persona(string nombre)
        {
            this.Nombre = nombre;
        }
        public virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Nombre completo:     {0}", this.Nombre);
            retorno.AppendFormat("DNI:                 {0}", this.DNI);
            return retorno.ToString();
        }
    }
}
