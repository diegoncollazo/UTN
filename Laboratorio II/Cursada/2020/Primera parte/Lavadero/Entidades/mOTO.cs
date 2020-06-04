using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        protected float cilindrada;

        public Moto(float cilindrada, string patente, byte ruedas, EMarcas marca) : base(patente, ruedas, marca)
        {
            this.cilindrada = cilindrada;
        }

        public string MostrarMoto()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("*****Moto*****");
            retorno.Append(base.Mostrar());
            retorno.AppendFormat("Cilindrada: {0} cc\n", this.cilindrada);
            return retorno.ToString();
        }
    }
}
