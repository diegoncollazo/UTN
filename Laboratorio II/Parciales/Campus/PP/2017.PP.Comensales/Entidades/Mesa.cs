using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mesa
    {
        private List<Comensal> comensales;
        private int numero;
        public static int capacidad;

        //Constructores
        static Mesa()
        {
            Mesa.capacidad = 12;
        }

        private Mesa()
        {
            this.comensales = new List<Comensal>();
        }

        public Mesa(int numero)
        {
            this.numero = numero;
        }
        //Propiedades
        public int Numero
        {
            get
            {
                return this.numero;
            }
        }
        public int Cantidad
        {
            get
            {
                return this.comensales.Count;
            }
        }
        public List<Comensal> Comensales
        {
            get
            {
                return this.comensales;
            }
        }

        public static bool operator ==(Mesa a, Mesa b)
        {
            return (a.Numero == b.Numero);
        }
        public static bool operator !=(Mesa a, Mesa b)
        {
            return !(a == b);
        }

        public static Mesa operator +(Mesa a, Mayor b)
        {
            foreach(Comensal item in a.comensales)
            {
                if (item is Mayor && (Mayor)b == (Mayor)item)
                {
                    if (a.comensales.Count < a.Cantidad)
                    {
                        a.comensales.Add(b);
                        break;
                    }
                }
            }
            return a;
        }
        public static Mesa operator +(Mesa a, Menor b)
        {
            foreach (Comensal item in a.comensales)
            {
                if (item is Menor && (Menor)b == (Menor)item)
                {
                    if (a.comensales.Count < a.Cantidad)
                    {
                        a.comensales.Add(b);
                        break;
                    }
                }
            }
            return a;
        }

        public static implicit operator string(Mesa mesa)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Mesa: {0} Comensales {1}\n", mesa.Numero, mesa.Cantidad);
            foreach(Comensal item in mesa.Comensales)
            {
                if (item is Mayor)
                {
                    retorno.AppendLine((string)(Mayor)(item));
                }
                else if (item is Menor)
                {
                    retorno.AppendLine(item.ToString());
                }
            }

            return retorno.ToString();
        }

    }
}
