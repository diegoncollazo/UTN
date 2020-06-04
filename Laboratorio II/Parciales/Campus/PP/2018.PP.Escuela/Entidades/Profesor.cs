using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Profesor : Persona
    {
        private DateTime fechaIngreso;

        public int Antiguedad
        {
            get
            {
                TimeSpan diferenciasFechas = DateTime.Now - fechaIngreso;
                int diasDif = diferenciasFechas.Days; 
                return diasDif;
            }
        }

        public override string ExponerDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.ExponerDatos());
            retorno.Append("Fecha Ingreso: ");
            retorno.AppendLine(Convert.ToString(this.fechaIngreso));
            return retorno.ToString();
        }

        public Profesor(string nombre, string apellido, string documento) : base(nombre, apellido, documento)
        {

        }

        public Profesor(string nombre, string apellido, string documento, DateTime fechaIngreso) : this(nombre, apellido, documento)
        {
            this.fechaIngreso = fechaIngreso;
        }

        protected override bool ValidarDocumentacion(string doc)
        {
            bool retorno = false;
            int i;
            for (i = 0; i < doc.Length - 1; i++)
            {             
                if (doc[i] >= '0' && doc[i] <= '9' || doc[i] == '-')
                {
                    if (doc[2] != '-' || doc[7] != '-')
                    {
                        retorno = false;
                        break;
                    }
                }
                retorno = true;
            }
            return retorno;
        }
    }
}
