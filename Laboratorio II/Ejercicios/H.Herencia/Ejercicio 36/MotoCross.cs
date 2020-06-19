using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_36
{   
    public class MotoCross : VehiculoDeCarrera
    {
        private short cilindrada;
        public short Cilindrada
        {
            get
            {
                return this.cilindrada;
            }
            set
            {
                this.cilindrada = value;
            }
        }
        public MotoCross(short numero, string escuderia) : base(numero, escuderia)
        {

        }
        public MotoCross(short numero, string escuderia, short cilindrada) : this(numero, escuderia)
        {
            this.cilindrada = cilindrada;
        }
        public override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("*****MotoCross*****\n");
            retorno.AppendFormat("{0}", base.MostrarDatos());
            retorno.AppendFormat("Cilindrada: {0}\n", this.Cilindrada);

            return retorno.ToString();
        }
        public static bool operator ==(MotoCross m1, MotoCross m2)
        {
            return (VehiculoDeCarrera)m1 == (VehiculoDeCarrera)m2 && m1.Cilindrada == m2.Cilindrada;
        }
        public static bool operator !=(MotoCross m1, MotoCross m2)
        {
            return !(m1 == m2);
        }
    }
}
