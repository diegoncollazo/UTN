using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador : Persona
    {
        private float altura;
        private float peso;
        private Posicion posicion;

        public float Altura
        {
            get
            {
                return this.altura;
            }
        }
        public float Peso
        {
            get
            {
                return this.peso;
            }
        }
        public Posicion Posicion
        {
            get
            {
                return this.posicion;
            }
        }

        public Jugador(string nombre, string apellido, int edad, int dni, float peso, float altura, Posicion posicion) : base(nombre, apellido, edad, dni)
        {
            this.peso = peso;
            this.altura = altura;
            this.posicion = posicion;
        }

        public override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            //retorno.AppendLine("*** Jugador ***");
            retorno.Append(base.Mostrar());
            retorno.AppendFormat("Peso: {0}\n", this.Peso);
            retorno.AppendFormat("Altura: {0}\n", this.Altura);
            retorno.AppendFormat("Posición: {0}\n", this.Posicion.ToString());
            return retorno.ToString();
        }

        public bool ValidarEstadoFisico()
        {
            double IMC =  this.Peso / Math.Pow(this.Altura, 2);
            return (IMC >= 18.5 || IMC <= 25);
        }

        public override bool ValidadAptitud()
        {
            return (this.Edad < 40 && ValidarEstadoFisico());
        }


    }
}
