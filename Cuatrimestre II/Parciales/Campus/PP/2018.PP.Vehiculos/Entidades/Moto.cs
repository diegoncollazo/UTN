using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        private int cilindrada;
        private short ruedas;
        private static int valorHora;

        static Moto()
        {
            Moto.valorHora = 30;
        }

        public Moto(string patente, int cilindrada) : this(patente, cilindrada, 2)
        {

        }
        public Moto(string patente, int cilindrada, short ruedas) : base(patente)
        {
            this.cilindrada = cilindrada;
            this.ruedas = ruedas;
        }
        public Moto(string patente, int cilindrada, short ruedas, int valorHora) : this(patente, cilindrada, ruedas)
        {
            Moto.valorHora = valorHora;
        }

        public override string ImprimirTicket()
        {
            TimeSpan horas = DateTime.Now.Subtract(this.ingreso);
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Moto:\n");
            retorno.Append(base.ImprimirTicket());
            retorno.AppendFormat("Costo de la estadía: {0}\n", (Moto.valorHora * (int)horas.TotalHours).ToString());
            return retorno.ToString();
        }

        public override string ConsultarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(this.ImprimirTicket());
            retorno.AppendFormat("Cilindrada: {0}\n", this.cilindrada);
            retorno.AppendFormat("Ruedas: {0}\n", this.ruedas);
            return retorno.ToString();
        }

        public override bool Equals(object obj)
        {
            return (obj is Moto);
        }
        
    }
}
