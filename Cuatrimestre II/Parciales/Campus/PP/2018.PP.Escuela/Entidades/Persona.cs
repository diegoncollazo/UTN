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
        private string documento;
        private string nombre;

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
        }

        public string Documento
        {
            get
            {
                return this.documento;
            }

            set
            {
                if (ValidarDocumentacion(value))
                {
                    this.documento = value;
                }
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public Persona(string nombre, string apellido, string documento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            Documento = documento;
        }

        protected abstract bool ValidarDocumentacion(string doc); 

        public virtual string ExponerDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("Nombre: ");
            retorno.AppendLine(this.nombre);
            retorno.Append("Apellido: ");
            retorno.AppendLine(this.apellido);
            retorno.Append("Documento: ");
            retorno.AppendLine(this.documento);
            return retorno.ToString();
        }
    }
}
