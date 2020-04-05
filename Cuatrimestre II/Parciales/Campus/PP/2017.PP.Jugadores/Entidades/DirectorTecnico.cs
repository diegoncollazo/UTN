using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DirectorTecnico : Persona
    {
        public override string ToString()
        {
            return FichaTecnica();
        }

        protected override string FichaTecnica()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.NombreCompleto());
            return retorno.ToString();
        }

        public DirectorTecnico(string nombre, string apellido) : base(nombre, apellido)
        {

        }
    }
}
