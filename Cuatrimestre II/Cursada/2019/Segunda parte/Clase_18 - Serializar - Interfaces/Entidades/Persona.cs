using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona : Humano
    {
        public string apellido;
        public string nombre;

        public Persona() : base()
        {

        }
        public Persona(string apellido, string nombre)
        {
            this.apellido = apellido;
            this.nombre = nombre;
        }
        public override string ToString()
        {
            return base.ToString() + " Nombre: " + this.nombre + " Apellido: " + this.nombre;
        }
    }
}
