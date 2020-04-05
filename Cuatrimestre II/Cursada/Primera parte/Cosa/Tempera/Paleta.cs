using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tempera
{
    public class Paleta
    {
        private Tempera[] _temperas;//Como un vector
        private int _cantidadMaxima;

        private Paleta(int cantidad)
        {
            this._temperas = new Tempera[cantidad]; //Si es un array tengo que crear un new objecto
            this._cantidadMaxima = cantidad;
        }

        private Paleta() : this(5)//cantidad maxima 5
        {

        }

        //Generar sobrecarga del implicit Paleta

        public static implicit operator Paleta(int entero)
        {
            Paleta objeto = new Paleta(entero);
            return objeto;
        }

        private string Mostrar()
        {
            string aux = "";
            foreach(Tempera auxiliar in this._temperas)
            {
                aux += Tempera.Mostrar(auxiliar);
            }

            return "Cantidad "+this._cantidadMaxima.ToString() + "\n" + aux;
        }

        public static explicit operator string(Paleta miPaleta)
        {
            return miPaleta.Mostrar();
        }

        //public static bool operator ==(Paleta parametro1, Tempera parametro2)
        //{

        //    if()
        //}

        // (+)== (Paleta, Tempera):Bool //Busco si la tempera esta en la paleta.
        // (+) + (Paleta, Tempera):Paleta //Agrego la tempera sino esta en la paleta., invoca al ==, donde la agrego -> 
        //(-) ObtenerIndice():int Obtener el indice primero que este null, entero que me representa el indice
    }
}
