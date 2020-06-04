using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cocina
    {
        private int _codigo;
        private bool _industrial;
        private double _precio;

        public int Codigo
        {
            get
            {
                return this._codigo;
            }
        }
        public bool EsIndustrial
        {
            get
            {
                return this._industrial;
            }
        }        
        public double Precio
        {
            get
            {
                return this._precio;
            }
        }

        public Cocina(int codigo, double precio, bool industrial)
        {
            this._codigo = codigo;
            this._precio = precio;
            this._industrial = industrial;
        }

        public override bool Equals(object obj)
        {
            return obj is Cocina && this == (Cocina)obj;
        }
        public override string ToString()
        {
            return "Codigo: " + this.Codigo + ", precio: " +this.Precio + ", es industrial [" + this.EsIndustrial.ToString() + "]";
        }

        public static bool operator ==(Cocina a, Cocina b)
        {
            return a.Codigo == b.Codigo;
        }
        public static bool operator !=(Cocina a, Cocina b)
        {
            return !(a == b);
        }
    }
}
