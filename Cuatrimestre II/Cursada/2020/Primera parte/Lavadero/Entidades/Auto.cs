using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculo
    {
        protected int cantidadAsientos;

        public Auto(int asientos, string patente, byte ruedas, EMarcas marca) : base(patente, ruedas, marca)
        {
            this.cantidadAsientos = asientos;
        }

        public string MostrarAuto()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("*****Auto*****");
            retorno.Append(base.Mostrar());
            retorno.AppendFormat("Asientos  : {0}\n", this.cantidadAsientos);
            return retorno.ToString();
        }
    }
}
