using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mayor : Comensal
    {
        //Enumerados
        public enum eBebidas
        {
            Agua,
            Cerveza,
            Vino,
            Gaseosa
        }
        
        //Atributos
        private eBebidas bebida;
        
        //Propiedades
        public eBebidas Bebida { get; }
        
        //Constructores
        public Mayor(string nombre, string apellido, eBebidas bebida) : base(nombre, apellido)
        {
            this.bebida = bebida;
        }

        //Metodos
        public static explicit operator string(Mayor a)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(a.Mostrar());
            retorno.AppendLine(a.bebida.ToString());
            return retorno.ToString();
        }

        //Operadores
        public static bool operator ==(Mayor a, Mayor b)
        {
            return (a.Nombre == b.Nombre && a.Apellido == b.Apellido);
        }

        public static bool operator !=(Mayor a, Mayor b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return (string)this;
        }

        public override bool Equals(object obj)
        {
            return (obj is Mayor && this == (Mayor)obj);
        }
    }
}
