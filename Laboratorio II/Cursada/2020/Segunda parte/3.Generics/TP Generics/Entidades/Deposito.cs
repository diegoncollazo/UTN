using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Deposito<T>
    {
        private int _capacidadMaxima;
        private List<T> _lista;

        public Deposito(int capacidad)
        {
            this._lista = new List<T>();
            this._capacidadMaxima = capacidad;
        }

        private int GetIndice(T a)
        {
            int retorno = -1;
            for (int i = 0; i < this._lista.Count; i++)
                if (a.Equals(this._lista[i]))
                    retorno = i;
            return retorno;
        }
        public bool Agregar(T a)
        {
            return this + a;
        }
        public bool Remover(T a)
        {
            return this - a;
        }
        public static bool operator +(Deposito<T> d, T a)
        {
            bool retorno = false;
            if (d._lista.Count < d._capacidadMaxima)
            {
                d._lista.Add(a);
                retorno = true;
            }
            return retorno;
        }
        public static bool operator -(Deposito<T> d, T a)
        {
            bool retorno = false;
            int index = d.GetIndice(a);
            if (index != -1)
            {
                d._lista.RemoveAt(index);
                retorno = true;
            }
            return retorno;
        }
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Capacidad máxima: {0}\n", this._capacidadMaxima);
            retorno.AppendLine("Listado de autos:");
            foreach (T item in this._lista)
                retorno.AppendLine(item.ToString());
            return retorno.ToString();
        }
    }
}
