using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        private string apellido;
        private string nombre;
        private int edad;
        private int dni;

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
        public int Edad
        {
            get
            {
                return this.edad;
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
        }

        public Persona(string nombre, string apellido, int edad, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.dni = dni;
        }

        public virtual string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Nombre: {0}\n", this.Nombre);
            retorno.AppendFormat("Apellido: {0}\n", this.Apellido);
            retorno.AppendFormat("Edad: {0}\n", this.Edad);
            retorno.AppendFormat("DNI: {0}\n", this.DNI);
            return retorno.ToString();
        }

        public abstract bool ValidadAptitud();
    }
}
