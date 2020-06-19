using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_49
{
    public class AutoF1 : VehiculoDeCarrera
    {
        private short caballosFuerza;
        public short CaballosFuerza
        {
            get
            {
                return this.caballosFuerza;
            }
            set
            {
                this.caballosFuerza = value;
            }
        }
        public AutoF1(short numero, string escuderia) : base(numero, escuderia)
        {

        }
        public AutoF1(short numero, string escuderia, short caballosFuerza) : this(numero, escuderia)
        {
            this.caballosFuerza = caballosFuerza;
        }
        public override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("*****F1*****\n");
            retorno.AppendFormat("{0}", base.MostrarDatos());
            retorno.AppendFormat("Caballos de fuerza: {0}\n", this.CaballosFuerza);

            return retorno.ToString();
        }
        public static bool operator ==(AutoF1 a1, AutoF1 a2)
        {

            return (VehiculoDeCarrera)a1 == (VehiculoDeCarrera)a2 && a1.CaballosFuerza == a2.CaballosFuerza;
        }
        public static bool operator !=(AutoF1 a1, AutoF1 a2)
        {
            return !(a1 == a2);
        }
    }
}
