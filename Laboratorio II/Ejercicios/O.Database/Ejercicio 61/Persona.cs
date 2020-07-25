using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_61
{
    public class Persona
    {
		private int id;
		private string apellido;
		private string nombre;

		public string Apellido
		{
			get { return apellido; }
			set { apellido = value; }
		}

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public int ID
		{
			get { return id; }
			set { id = value; }
		}
		public Persona(int id, string apellido, string nombre) : this(apellido, nombre)
		{
			this.ID = id;
		}
		public Persona(string nombre, string apellido)
		{
			this.Apellido = apellido;
			this.Nombre = nombre;
		}

		public override string ToString()
		{
			StringBuilder retorno = new StringBuilder();
			retorno.Append(this.ID.ToString());
			retorno.Append(" - " + this.Apellido);
			retorno.AppendLine(", " + this.Nombre);
			return retorno.ToString();
		}
	}
}
