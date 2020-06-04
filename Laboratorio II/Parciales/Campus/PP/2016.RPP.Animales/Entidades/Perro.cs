using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perro : Animal
    {
        //Nested types
        public enum Razas
        {
            Galgo,
            OvejeroAleman
        }
        //Atributos
        private static int _patas;
        private Razas _raza;
        //Constructores
        static Perro()
        {
            Perro._patas = 4;
        }
        public Perro(int velocidadMaxima) : base(4, velocidadMaxima)
        {

        }
        public Perro(Razas raza, int velocidadMaxima) : this(velocidadMaxima)
        {
            this._raza = raza;
        }
        //Metodos
        public string MostrarPerro()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nRaza:              {0}", this._raza);
            retorno.AppendFormat("\nPatas:             {0}", Perro._patas);
            return retorno.ToString();   
        }
        public override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("\n***Perro***");
            retorno.Append(base.MostrarDatos());
            retorno.Append(this.MostrarPerro());
            return retorno.ToString();
        }
        //Operadores
        public static bool operator ==(Perro perro1, Perro perro2)
        {
            bool retorno = false;
            if (perro1._raza == perro2._raza && perro1._velocidadMaxima == perro2._velocidadMaxima)
                retorno = true;
            return retorno;
        }
        public static bool operator !=(Perro perro1, Perro perro2)
        {
            return !(perro1 == perro2);
        }
    }
}
