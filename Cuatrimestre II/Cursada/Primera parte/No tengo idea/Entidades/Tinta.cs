using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tinta
    {
        private ConsoleColor color; // = ConsoleColor.Black;
        private ETipoTinta tipoTinta; // = ETipoTinta.Comun;

        public Tinta() : this(ConsoleColor.Black, ETipoTinta.Comun)
        {

        }

        public Tinta(ConsoleColor color, ETipoTinta tinta)
        {
            this.tipoTinta = tinta;
            this.color = color;
        }

        public Tinta(ConsoleColor color) : this(color, ETipoTinta.Comun)//Yo no tengo que llamar a la tinta, porque por default es comun
        {

        }

        private string Mostrar()
        {
            return this.color.ToString() + "-" + this.tipoTinta.ToString();
        }

        public static string Mostrar(Tinta algo)
        {
            return algo.Mostrar();
        }

        public static bool operator ==(Tinta parametro1, Tinta parametro2) //puedo cambiar el nombre o el tipo
        {
            //Boolean rta = false
            bool rta = (parametro1.color == parametro2.color && parametro1.tipoTinta == parametro2.tipoTinta);
            return rta;
        }

        public static bool operator !=(Tinta parametro1, Tinta parametro2)
        {
            return !(parametro1 == parametro2);
        }




    }
}
