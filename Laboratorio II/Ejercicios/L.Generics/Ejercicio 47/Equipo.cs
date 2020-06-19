using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_47
{
    public abstract class Equipo
    {
        private string nombre;
        private DateTime fechaCreacion;
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
        public DateTime FechaCreacion
        {
            get
            {
                return this.fechaCreacion;
            }
            set
            {
                this.fechaCreacion = value;
            }
        }
        public Equipo(string nombre, DateTime creacion)
        {
            this.Nombre = nombre;
            this.FechaCreacion = creacion;
        }
        public static string Ficha(Equipo equipo)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Nombre del equipo: {0}\n", equipo.Nombre);
            retorno.AppendFormat("Fundado el: {0}\n", equipo.FechaCreacion.ToString());
            return retorno.ToString();
        }
    }
}
