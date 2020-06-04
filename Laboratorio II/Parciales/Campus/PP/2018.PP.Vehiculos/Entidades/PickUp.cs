using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PickUp : Vehiculo
    {
        private string modelo;
        private static int valorHora;

        static PickUp()
        {
            valorHora = 70;
        }
        public PickUp(string patente, string modelo) : base(patente)
        {
            this.modelo = modelo;
        }
        public PickUp(string patente, string modelo, int valorHora) : this(patente, modelo)
        {
            PickUp.valorHora = valorHora;
        }

        public override string ImprimirTicket()
        {
            TimeSpan horas = DateTime.Now.Subtract(this.ingreso);
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("PickUp:\n");
            retorno.Append(base.ImprimirTicket());
            retorno.AppendFormat("Costo de la estadía: {0}\n", (PickUp.valorHora * (int)horas.TotalHours).ToString());
            return retorno.ToString();
        }

        public override string ConsultarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(this.ImprimirTicket());
            retorno.AppendFormat("Modelo: {0}\n", this.modelo);
            return retorno.ToString();
        }

        public override bool Equals(object obj)
        {
            return (obj is PickUp);
        }
    }
}
