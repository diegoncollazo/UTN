using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vehiculo
    {
        public enum EMarcas
        {
            Honda, Ford, Zanella, Scania, Iveco, Fiat
        }
        protected string patente;
        protected byte ruedas;
        protected EMarcas marca;

        public string Patente
        {
            get
            {
                return this.patente;
            }
        }
        public string Marca
        {
            get
            {
                return this.marca.ToString();
            }
        }

        public Vehiculo(string patente, byte ruedas, EMarcas marca)
        {
            this.patente = patente;
            this.ruedas = ruedas;
            this.marca = marca;
        }

        protected string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Marca     : {0}\n", this.Marca);
            retorno.AppendFormat("Patente   : {0}\n", this.Patente);
            retorno.AppendFormat("Ruedas    : {0}\n", this.ruedas);
            return retorno.ToString();
        }

        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.Marca == v2.Marca && v1.Patente == v2.Patente;
        }
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

    }
}
