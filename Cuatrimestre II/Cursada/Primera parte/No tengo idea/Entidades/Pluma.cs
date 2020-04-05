using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pluma
    {
        private string marca;
        private Tinta tinta;
        private int cantidad;

        public Pluma(string miMarca, Tinta miTinta, int miCantidad)
        {
            this.marca = miMarca;
            this.tinta = miTinta;
            this.cantidad = miCantidad;
        }

        public Pluma() : this("Sin marca", null, 0)
        {

        }

        public Pluma(string miMarca) : this(miMarca, null, 0)
        {

        }

        public Pluma(string miMarca, Tinta miTinta) : this(miMarca, miTinta, 0)
        {

        }

        private string Mostrar()
        {
            return this.marca.ToString() + "." + Tinta.Mostrar(this.tinta) + "." + this.cantidad.ToString(); //tengo que mostrar todas las tintas
        }

        public static bool operator ==(Pluma miPluma, Tinta miTinta)
        {
            return miPluma.tinta == miTinta;
        }
        public static bool operator !=(Pluma miPluma, Tinta miTinta)
        {
            return !(miPluma == miTinta);
        }

        public static implicit operator string(Pluma miPluma)//reciben dos parametros
        {
            return miPluma.Mostrar();
        }

        //public static explicit operator string (Pluma miPluma)
        //{
        //    return miPluma.ToString();
        //}
        public static Pluma operator +(Pluma miPluma, Tinta miTinta)
        {
            if(miPluma.tinta == miTinta)
            {
                miPluma.cantidad += 10;
            }
            return miPluma;
        }
    }

}
