using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Humano : Animal
    {
        //Atributos
        private string _apellido;
        private string _nombre;
        private static int _piernas;
        //Constructores
        static Humano()
        {
            Humano._piernas = new int();
            Humano._piernas = 2;
        }
        public Humano(int velocidadMaxima) : base(2, velocidadMaxima)
        {

        }
        public Humano(string apellido, string nombre, int velocidadMaxima) : this(velocidadMaxima)
        {
            this._apellido = apellido;
            this._nombre = nombre;
        }
        //Metodos
        public string MostrarHumano()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nApellido:          {0}", this._apellido);
            retorno.AppendFormat("\nNombre:            {0}", this._nombre);
            retorno.AppendFormat("\nPiernas:           {0}", Humano._piernas);
            return retorno.ToString();
        }
        public override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("\n***Humano***");
            retorno.Append(base.MostrarDatos());
            retorno.Append(this.MostrarHumano());
            return retorno.ToString();
        }
        //Operadores
        public static bool operator ==(Humano humano1, Humano humano2)
        {
            bool retorno = false;
            if (humano1._nombre == humano2._nombre && humano1._apellido == humano2._nombre)
                retorno = true;
            return retorno;
        }
        public static bool operator !=(Humano humano1, Humano humano2)
        {
            return !(humano1 == humano2);
        }
    }
}
