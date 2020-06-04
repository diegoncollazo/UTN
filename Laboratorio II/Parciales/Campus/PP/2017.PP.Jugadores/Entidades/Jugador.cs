using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador : Persona
    {
        private int numero;
        private bool esCapitan;

        public bool EsCapitan
        {
            get
            {
                return this.esCapitan;
            }

            set
            {
                this.esCapitan = value;
            }
        }

        public int Numero
        {
            get
            {
                return this.numero;
            }

            set
            {
                this.numero = value;
            }
        }

        public Jugador(string nombre, string apellido) : base (nombre, apellido)
        {
            this.numero = 0;
            this.esCapitan = false;
        }

        public Jugador(string nombre, string apellido, bool esCapitan, int numero) : this(nombre, apellido)
        {
            this.esCapitan = esCapitan;
            this.numero = numero;
        }

        protected override string FichaTecnica()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.NombreCompleto());

            if(EsCapitan)
            {
                retorno.AppendFormat(", Capitán del equipo,", Numero);
            }

            retorno.AppendFormat(" Camiseta número: {0}", Numero);

            return retorno.ToString();
        }

        public static bool operator ==(Jugador j1, Jugador j2)
        {
            bool retorno = false;

            if (j1.Nombre == j2.Nombre && j1.Apellido == j2.Apellido && j1.Numero == j2.Numero)
            {
                retorno = true;
            }

            return retorno;

        }

        public static bool operator !=(Jugador j1, Jugador j2)
        {
            return !(j1 == j1);
        }

        public static explicit operator int(Jugador jugador)
        {
            return jugador.Numero;
        }

        public override string ToString()
        {
            return this.FichaTecnica();
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if ((Jugador)obj == this)
            {
                retorno = true;
            }
            return retorno;
        }

    }
}
