using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        protected Fabricante fabricante;
        protected static Random generadorDeVelocidades;
        protected string modelo;
        protected float precio;
        protected int velocidadMaxima;

        public int VelocidadMaxima
        {
            get
            {
                if (this.velocidadMaxima == 0)
                {
                    this.velocidadMaxima = generadorDeVelocidades.Next(100, 280);
                }
                return this.velocidadMaxima;
            }
        }

        static Vehiculo()
        {
            Vehiculo.generadorDeVelocidades = new Random();
        }

        public Vehiculo(float precio, string modelo, Fabricante fabricante)
        {
            this.modelo = modelo;
            this.precio = precio;
            this.fabricante = fabricante;
            this.velocidadMaxima = VelocidadMaxima;
        }

        public Vehiculo(string marca, EPais pais, string modelo, float precio) : this(precio, modelo, new Fabricante(marca, pais))
        {
           
        }

        public static explicit operator string(Vehiculo v)
        {
            return Mostrar(v);
        }

        private static string Mostrar(Vehiculo v)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Modelo: {0}\n", v.modelo);
            retorno.AppendFormat("{0}\n", (string)v.fabricante);
            retorno.AppendFormat("Precio: $ {0}\n", v.precio);
            retorno.AppendFormat("Velocidad máxima: {0} km/h\n", v.velocidadMaxima);
            return retorno.ToString();
        }

        public static bool operator ==(Vehiculo a, Vehiculo b)
        {
            return (a.modelo == b.modelo && a.fabricante == b.fabricante);
        }
        public static bool operator !=(Vehiculo a, Vehiculo b)
        {
            return !(a == b);
        }
    }
}
