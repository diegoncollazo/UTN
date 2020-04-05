using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase06
{
    public class Tempera
    {
        private ConsoleColor _color;
        private string _marca;
        private sbyte _cantidad;

        public Tempera(ConsoleColor color, string marca, sbyte cantidad)
        {
            this._color = color;
            this._marca = marca;
            this._cantidad = cantidad;
        }

        private string Mostrar()
        {
            return this._cantidad.ToString() + " - " + this._color.ToString() + " - " + this._marca;
        }
        public static string Mostrar(Tempera tempera)
        {
            string retorno = "";
            if (tempera != null) //Si la tempera pasada es null (no tiene nada)
            {
                retorno = tempera.Mostrar(); //Nos retornara la string cargada de mostrar
            }
            return retorno;
        }
        //Sobrecarga de operadores.
        //Operador Igual [==]
        //Compara dos temperas / Si son nulas o si tienen los mismos valores en sus atributos.
        public static bool operator ==(Tempera tempera1, Tempera tempera2)
        {
            bool retorno = false;
            if ((Object.Equals(tempera1, null)) && (Object.Equals(tempera2, null)))
            {//Si tempera 1 y tempera 2 son nulas, por lo tanto son iguales.
                retorno = true;
            }
            else if (Object.Equals(tempera1, null) || (Object.Equals(tempera2, null)))
            {//Si alguna de las temperas son null, por lo tanto, distintas.
                retorno = false;
            }
            else
            {
                if (tempera2._color == tempera1._color && tempera2._marca == tempera1._marca)
                {//Si los atributos son iguales, por lo tanto iguales.
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            return retorno;
        }
        //Operador Distinto [Inversa de ==]
        public static bool operator !=(Tempera tempera1, Tempera tempera2)
        {
            return !(tempera1 == tempera2);
        }
        //Operador Suma [+]
        //Sumo en el atributo cantidad
        public static Tempera operator +(Tempera tempera, sbyte cantidad)
        {
            tempera._cantidad += cantidad;
            return tempera;
        }
        //Operador Suma [+]
        //Sumo en el atributo cantidad [sumo la cantidad que viene en la segunda tempera]
        public static Tempera operator +(Tempera tempera1, Tempera tempera2)
        {
            if (tempera1 == tempera2)
            {
                tempera1 += tempera2._cantidad;
            }
            return tempera1;
        }
        //Devuelve la cantidad de la tempera.
        public static implicit operator sbyte(Tempera tempera)
        {
            return tempera._cantidad;
        }
        //Devuelve el color.
        public static implicit operator ConsoleColor(Tempera tempera)
        {
            return tempera._color;
        }
        //Devuelve la marca.
        public static implicit operator string(Tempera tempera)
        {
            return tempera._marca;
        }
    }
}
