using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comercio
    {
        protected int _cantidadDeEmpleados;
        protected Comerciante _comerciante;
        protected static Random _generadorDeEmpleados;
        protected string _nombre;
        protected float _alquiler;

        public int CantidadDeEmpleados{
            get
            {
                if (this._cantidadDeEmpleados == 0)
                {
                    this._cantidadDeEmpleados = _generadorDeEmpleados.Next(1, 100);
                }
                return this._cantidadDeEmpleados;
            }
        }

        static Comercio()//Constructor de clase
        {
            _generadorDeEmpleados = new Random();//Atributo static
        }

        //Constructores de instancia
        // Con este constructor creo un nuevo Comerciante
        public Comercio(float precioAlquiler, string nombreComercio, string nombre, string apellido) : this(nombreComercio, new Comerciante(nombre, apellido), precioAlquiler)
        {

        }
        //Con este constructor recibe un Comerciante
        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler)
        {
            this._nombre = nombre;//Nombre del comercio
            this._comerciante = comerciante;
            this._alquiler = precioAlquiler;
            this._cantidadDeEmpleados = CantidadDeEmpleados;
        }

        public static explicit operator string(Comercio c)
        {
            return Mostrar(c);
        }
        //Funciona
        private static string Mostrar(Comercio c)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nNombre del comercio: {0}", c._nombre);
            retorno.AppendLine(c._comerciante);
            retorno.AppendFormat("Alquiler: {0}", c._alquiler.ToString());
            retorno.AppendFormat("\nEmpleados: {0}", c._cantidadDeEmpleados.ToString());
            return retorno.ToString();
        }

        public static bool operator ==(Comercio a, Comercio b)
        {
            return (a._comerciante == b._comerciante && a._nombre == b._nombre);
        }
        public static bool operator !=(Comercio a, Comercio b)
        {
            return !(a == b);
        }
    }
}
