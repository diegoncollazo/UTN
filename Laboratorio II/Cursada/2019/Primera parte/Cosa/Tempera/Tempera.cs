using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempera
{
    public class Tempera
    {
        
        private ConsoleColor _color;
        private string _marca;
        private sbyte _cantidad;

        public Tempera(ConsoleColor colorcito, string marquita, sbyte cantidad)
        {
            this._color = colorcito;
            this._marca = marquita;
            this._cantidad = cantidad;
        }

        private string Mostrar()
        {
            return this._cantidad.ToString() + "-" + this._color.ToString() + "-" + this._marca.ToString();
        }

        public static string Mostrar(Tempera cosa) 
        {
             if(Object.Equals(cosa, null))
            {
                return "Es null tempera";
            }
             else
            {
                return cosa.Mostrar();
            }
                //string ret = "";
                // if (cosa != null)
                //      {
                //        ret = cosa.Mostrar();
                //      }

                //  return ret;
                 
            // return cosa.Mostrar();
        }


        public static bool operator ==(Tempera parametro1, Tempera parametro2)
        {
            bool rta = false;
           // if (!((Object.Equals(parametro1, null)) && (Object.Equals(parametro2, null))))
           if((Object.Equals(null, parametro1)) && (Object.Equals(null, parametro2)))
            {
                if(parametro1._marca == parametro2._marca && parametro1._color == parametro2._color)
                {
                    rta = true;
                }
                else
                {
                    rta = true;
                }
            }
                   
            return rta;
        }


        public static bool operator !=(Tempera parametro1, Tempera parametro2)
        {
            return !(parametro1 == parametro2);
        }


        public static Tempera operator +(Tempera cantidad, sbyte cantidadDeNuevo)
        {
            cantidad._cantidad += cantidadDeNuevo;
            return cantidad;
        }


        public static Tempera operator +(Tempera cosa1, Tempera cosa2)
        {
            if(cosa1 == cosa2)
            {
                cosa1 += cosa2._cantidad;
                //cosa1 = cosa1 + cosa2._cantidad; //Es lo mismo que la de arriba
            }
            return cosa1;
        }


        public static implicit operator sbyte(Tempera miTempera)//reciben dos parametros
        {
            return miTempera._cantidad;
        }
    }
}
