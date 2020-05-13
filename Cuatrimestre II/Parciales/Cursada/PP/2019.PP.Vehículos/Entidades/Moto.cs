using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        public ECilindrada cilindrada;

        public Moto(string marca, EPais pais, string modelo, float precio, ECilindrada cilindrada) : base(marca, pais, modelo, precio)
        {
            this.cilindrada = cilindrada;
        }

        public static bool operator ==(Moto a, Moto b)
        {
            return ((Vehiculo)a == (Vehiculo)b && a.cilindrada == b.cilindrada);
        }

        public static bool operator !=(Moto a, Moto b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return((Moto)obj == this);
        }

        public static implicit operator Single(Moto a)
        {
            return a.precio;
        }

        public override string ToString()
        {
            return (string)(Vehiculo)this + "Cilindrada: " + this.cilindrada.ToString() + "\n";
        }
    }
}
