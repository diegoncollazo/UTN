using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
     public class Automovil : Vehiculo
    {
        private ConsoleColor color;
        private static int valorHora;

        static Automovil()
        {
            valorHora = 50;
        }
        public Automovil(string patente, ConsoleColor color) : base(patente)
        {
            this.color = color;
        }
        public Automovil(string patente, ConsoleColor color, int valorHora) : this(patente, color)
        {
            Automovil.valorHora = valorHora;
        }
        public override string ImprimirTicket()
        {
            TimeSpan horas = DateTime.Now.Subtract(this.ingreso);
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Automovil:\n");
            retorno.Append(base.ImprimirTicket());
            retorno.AppendFormat("Costo de la estadía: {0}\n", (Automovil.valorHora * (int)horas.TotalHours).ToString());
            return retorno.ToString();
        }

        public override string ConsultarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(this.ImprimirTicket());
            retorno.AppendFormat("Color: {0}\n", this.color.ToString());
            return retorno.ToString();
        }

        public override bool Equals(object obj)
        {
            return (obj is Automovil);
        }

    }
}
