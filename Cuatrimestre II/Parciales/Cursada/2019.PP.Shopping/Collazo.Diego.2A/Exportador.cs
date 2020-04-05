using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Exportador : Comercio
    {
        private ETipoProducto tipo;

        public Exportador(string nombreComercio, float precioAlquiler, string nombre, string apellido, ETipoProducto tipo) : base(precioAlquiler, nombreComercio, nombre, apellido)
        {
            this.tipo = tipo;
        }

        public static implicit operator double(Exportador m)
        {
            return m._alquiler;
        }

        public string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine((string)(this));
            retorno.AppendFormat("Tipo de producto: {0}", this.tipo);
            return retorno.ToString();
        }

        public static bool operator ==(Exportador a, Exportador b)
        {
            return (a._comerciante == b._comerciante && a.tipo == b.tipo);
        }

        public static bool operator !=(Exportador a, Exportador b)
        {
            return !(a == b);
        }
    }
}
