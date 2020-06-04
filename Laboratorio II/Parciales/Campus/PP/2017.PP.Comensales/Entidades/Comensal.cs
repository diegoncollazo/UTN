using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Comensal
    {
        private string apellido;
        private string nombre;

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

        public Comensal(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public virtual string Mostrar()
        {
            return string.Format("Nombre: {0} Apellido {1}", Nombre, Apellido);
        }
    }
}
