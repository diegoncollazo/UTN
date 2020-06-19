using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_35
{
    public class DirectorTecnico : Persona
    {
        private DateTime fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get
            {
                return this.fechaNacimiento;
            }
            set
            {
                this.fechaNacimiento = value;
            }
        }
        private DirectorTecnico(string nombre) : base(nombre)
        {

        }
        public DirectorTecnico(string nombre, DateTime nacimiento) : this(nombre)
        {
            this.fechaNacimiento = nacimiento;
        }

        public static bool operator ==(DirectorTecnico d1, DirectorTecnico d2)
        {
            return d1.FechaNacimiento == d2.FechaNacimiento && d1.Nombre == d2.Nombre;
        }
        public static bool operator !=(DirectorTecnico d1, DirectorTecnico d2)
        {
            return !(d1 == d2);
        }

        public override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.MostrarDatos());
            retorno.AppendFormat("Fecha de nacimiento: {0}", this.FechaNacimiento);
            return retorno.ToString();
        }
    }
}
