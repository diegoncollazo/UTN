using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculo
    {
        public ETipo tipo;

        public Auto(string modelo, float precio, Fabricante fabri, ETipo tipo) : base(precio, modelo, fabri)
        {
            this.tipo = tipo;
        }

        public static bool operator ==(Auto a, Auto b)
        {
            return ((Vehiculo)a == (Vehiculo)b && a.tipo == b.tipo);
        }

        public static bool operator !=(Auto a, Auto b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return ((Auto)obj == this);
        }

        public static explicit operator Single(Auto a)
        {
            return a.precio;
        }

        public override string ToString()
        {
            return (string)(Vehiculo)this + "Tipo: " + this.tipo.ToString() + "\n";
        }
    }
}
