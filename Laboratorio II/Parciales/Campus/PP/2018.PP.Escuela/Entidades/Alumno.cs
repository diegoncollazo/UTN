using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno : Persona
    {
        private short anio;
        private Divisiones division;

        public string AnioDivision
        {
            get
            {
                StringBuilder retorno = new StringBuilder();
                retorno.AppendFormat(this.anio + "º" + this.division);
                return retorno.ToString();
            }
        }

        public Alumno(string nombre, string apellido, string documento, short anio, Divisiones division) : base(nombre, apellido, documento)
        {
            this.anio = anio;
            this.division = division;
        }

        public override string ExponerDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.ExponerDatos());
            retorno.Append("año: ");
            retorno.AppendLine(Convert.ToString(this.anio));
            retorno.Append("division: ");
            retorno.AppendLine(Convert.ToString(this.division));
            return retorno.ToString();
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
