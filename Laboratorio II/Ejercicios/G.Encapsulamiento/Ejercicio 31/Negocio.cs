using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_31
{
    public class Negocio
    {
        private EPuesto caja;
        //FIFO
        private Queue<Cliente> clientes;
        private string nombre;
        public Cliente Cliente
        {
            get
            {
                return this.clientes.Dequeue();
            }
        }
        public int ClientesPendientes
        {
            get
            {
                return this.clientes.Count;
            }
        }
        private Negocio()
        {
            this.clientes = new Queue<Cliente>();
            this.caja = EPuesto.Caja1;
        }
        public Negocio(string nombre)
        {
            this.nombre = nombre;
        }
        public static bool operator ==(Negocio n, Cliente c)
        {
            bool retorno = false;
            foreach (Cliente item in n.clientes)
            {
                if(item == c)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Negocio n, Cliente c)
        {
            return !(n == c);
        }
        public static bool operator +(Negocio n, Cliente c)
        {
            bool retorno = false;
            if (n != c)
            {
                n.clientes.Enqueue(c);
                retorno = true;
            }
            return retorno;
        }
        public static bool operator ~(Negocio n)
        {
            bool retorno = false;
            if (PuestoAtencion.Atender(n.Cliente))
                retorno = true;
            return retorno;
        }


    }
}
