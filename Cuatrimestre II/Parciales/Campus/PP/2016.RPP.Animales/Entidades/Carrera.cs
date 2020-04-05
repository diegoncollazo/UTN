using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carrera
    {
        //Atributos
        private List<Animal> _animales;
        private int _corredoresMax;
        //Constructores
        private Carrera()
        {
            this._animales = new List<Animal>();
        }
        public Carrera(int corredoresMax) : this()
        {
            this._corredoresMax = corredoresMax;
        }
        //Metodos
        public string MostrarCarrera(Carrera c)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Corredores:        {0}\n", this._corredoresMax);
            for (int i = 0; i < c._animales.Count; i++)
            {
                retorno.AppendLine(c._animales[i].MostrarDatos());
            }
            return retorno.ToString();
        }
        //Operadores
        public static bool operator ==(Carrera c, Animal a)
        {
            bool retorno = false;
            foreach(Animal item in c._animales)
            {
                if (item is Caballo && a is Caballo && ((Caballo)item == (Caballo)a))
                {
                    retorno = true;
                    break;
                }
                else if (item is Perro && a is Perro && ((Perro)item == (Perro)a))
                {
                    retorno = true;
                    break;
                }
                else if (item is Humano && a is Humano && ((Humano)item == (Humano)a))
                {
                    retorno = true;
                    break;   
                }
            }
            return retorno;
        }

        public static bool operator !=(Carrera c, Animal a)
        {
            return !(c == a);
        }
        //Operador +
        public static Carrera operator +(Carrera c, Animal a)
        {
            if (c != a && c._animales.Count < c._corredoresMax)
                c._animales.Add(a);

            return c;
        }
    }
}
