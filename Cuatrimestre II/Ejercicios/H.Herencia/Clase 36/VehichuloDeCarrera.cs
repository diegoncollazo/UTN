using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_36
{
    public class VehichuloDeCarrera
    {
        private short cantidadCombustible;
        private bool enCompetencia;
        private string escuderia;
        private short numero;
        private short vueltasRestantes;
        public short CantidadCumbustible
        {
            get
            {
                return this.cantidadCombustible;
            }
            set
            {
                this.cantidadCombustible = value;
            }
        }
        public bool EnCompetencia
        {
            get
            {
                return this.enCompetencia;
            }
            set
            {
                this.enCompetencia = value;
            }
        }
        public string Escuderia
        {
            get
            {
                return this.escuderia;
            }
            set
            {
                this.escuderia = value;
            }
        }
        public short Numero
        {
            get
            {
                return this.numero;
            }
            set
            {
                this.numero = value;
            }
        }
        public short VueltasRestantes
        {
            get
            {
                return this.vueltasRestantes;
            }
            set
            {
                this.vueltasRestantes = value;
            }
        }
        public VehichuloDeCarrera(short numero, string escuderia)
        {
            this.Numero = numero;
            this.Escuderia = escuderia;
        }
        public virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("Numero: {0}\n", this.Numero);
            retorno.AppendFormat("Escuderia: {0}\n", this.Escuderia);
            retorno.AppendFormat("En competencia: {0}\n", this.EnCompetencia);
            retorno.AppendFormat("Vueltas restantes: {0}\n", this.VueltasRestantes);
            retorno.AppendFormat("Cantidad de combustible: {0}\n", this.CantidadCumbustible);

            return retorno.ToString();
        }
        public static bool operator ==(VehichuloDeCarrera v1, VehichuloDeCarrera v2)
        {
            return v1.Numero == v2.Numero && v1.Escuderia == v2.Escuderia;
        }
        public static bool operator !=(VehichuloDeCarrera v1, VehichuloDeCarrera v2)
        {
            return !(v1 == v2);
        }
    }
}
