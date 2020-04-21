using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camion : Vehiculo
    {
        protected float tara;

        public Camion(float tara, string patente, byte ruedas, EMarcas marca) : base(patente, ruedas, marca)
        {
            this.tara = tara;
        }

        public string MostrarCamion()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("****Camion****");
            retorno.Append(base.Mostrar());
            retorno.AppendFormat("Tara      : {0} tn\n", this.tara);
            return retorno.ToString();
        }
    }
}
