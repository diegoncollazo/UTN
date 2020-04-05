using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        private string patente;
        protected DateTime ingreso;

        public string Patente{
            get
            {
                return this.patente;
            }
            set
            {
                if (value.Length == 6)
                {
                    this.patente = value;
                }
            }
        }

        public Vehiculo(string patente)
        {
            this.Patente = patente;
            ingreso = DateTime.Now.AddHours(-3);
        }

        public virtual string ImprimirTicket()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(this.ToString());
            retorno.AppendFormat("Ingreso: {0}\n", this.ingreso);
            return retorno.ToString();
        }

        public override string ToString()
        {
            return String.Format("Patente: {0}", this.Patente);
        }

        public abstract string ConsultarDatos();

        //Operadores
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.patente == v2.patente && v1.Equals(v1) && v2.Equals(v2));
        }

        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        //public override bool Equals(object obj)
        //{
        //    return (obj is Vehiculo && this is Vehiculo);
        //}
    }
}
