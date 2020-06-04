using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DirectorTecnico : Persona
    {
        private int añosExperiencia;

        public int AñosExperiencia { get; set; }

        public DirectorTecnico(string nombre, string apellido, int edad, int dni, int añosExperiencia) : base(nombre, apellido, edad, dni)
        {
            this.AñosExperiencia = añosExperiencia;
        }

        public override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("*** Director Técnico ***");
            retorno.Append(base.Mostrar());
            retorno.AppendFormat("Años de experiencia: {0}\n", this.AñosExperiencia);
            return retorno.ToString();
        }

        public override bool ValidadAptitud()
        {
            return (this.AñosExperiencia >= 2 && this.Edad < 65);
        }
    }
}
