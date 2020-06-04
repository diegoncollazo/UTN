using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Menor : Comensal
    {
        //Enumerados
        public enum eMenu
        {
            Milanesa,
            Hamburguesa
        }
        
        //Atributos
        private eMenu menu;
        
        //Propiedades
        public eMenu Menu { get; set; }
        
        //Constructores
        private Menor(string nombre, string apellido) : base(nombre, apellido)
        {

        }
        public Menor(string nombre, string apellido, eMenu menu) : this(nombre, apellido)
        {
            this.Menu = menu;
        }

        //Metodos
        public override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.Mostrar());
            retorno.AppendLine(this.Menu.ToString());
            return retorno.ToString();
        }

        //Operadores
        /* == */
        public static bool operator ==(Menor a, Menor b)
        {
            return (a.Nombre == b.Nombre && a.Apellido == b.Apellido && a.Menu == b.Menu);
        }
        /* != */
        public static bool operator !=(Menor a, Menor b)
        {
            return !(a == b);
        }
        //ToString
        public override string ToString()
        {
            return Mostrar();
        }
        //Equals
        public override bool Equals(object obj)
        {
            return (obj is Menor && this == (Menor)obj);
        }

    }
}
