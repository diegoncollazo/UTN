using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Caballo : Animal
    {
        //Atributos
        private static int _patas;
        private string _nombre;
        //Constructores
        static Caballo()
        {
            Caballo._patas = 4;
        }
        public Caballo(string nombre, int velocidadMaxima) : base(4, velocidadMaxima)
        {
            this._nombre = nombre;
        }
        //Metodos
        public string MostrarCaballo()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nNombre:            {0}", this._nombre);
            retorno.AppendFormat("\nPatas:             {0}", Caballo._patas);
            return retorno.ToString();
        }
        public override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("\n***Caballo***");
            retorno.Append(base.MostrarDatos());
            retorno.Append(this.MostrarCaballo());
            return retorno.ToString();
        }
        //Operadores
        public static bool operator ==(Caballo caballo1, Caballo caballo2)
        {
            bool retorno = false;
            if (caballo1._nombre == caballo2._nombre && caballo1._velocidadMaxima == caballo2._velocidadMaxima)
                retorno = true;
            return retorno;
        }
        public static bool operator !=(Caballo caballo1, Caballo caballo2)
        {
            return !(caballo1 == caballo2);
        }
    }
}
