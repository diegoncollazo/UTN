using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_35;

namespace Clase_29
{
    public class Jugador : Persona
    {
        //private int dni;
        //private string nombre;
        private int partidosJugados;
        private int totalGoles;
        //public int DNI
        //{
        //    get
        //    {
        //        return this.dni;
        //    }
        //    set
        //    {
        //        this.dni = value;
        //    }
        //}
        //public string Nombre
        //{
        //    get
        //    {
        //        return this.nombre;
        //    }
        //    set
        //    {
        //        this.nombre = value;
        //    }
        //}
        public int PartidosJugados
        {
            get
            {
                return this.partidosJugados;
            }
        }
        public float PromedioGoles
        {
            get
            {
                return (float)(this.totalGoles) / (float)(this.partidosJugados);
            }
        }
        public int TotalGoles
        {
            get
            {
                return this.totalGoles;
            }
        }

        //private Jugador()
        //{
        //    this.partidosJugados = 0;
        //    this.totalGoles = 0;
        //}
        public Jugador(int dni, string nombre) : base(dni, nombre)
        {

        }
        public Jugador(int dni, string nombre, int totalGoles, int partidosJugados) : this(dni, nombre)
        {
            this.totalGoles = totalGoles;
            this.partidosJugados = partidosJugados;
        }

        public override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.MostrarDatos());
            retorno.AppendFormat("Partidos jugados:    {0}", this.PartidosJugados);
            retorno.AppendFormat("Goles:               {0}", this.TotalGoles);
            retorno.AppendFormat("Promedio de gol:     {0}", this.PromedioGoles);
            return retorno.ToString();
        }

        public static bool operator ==(Jugador j1, Jugador j2)
        {
            return j1.DNI == j2.DNI;
        }
        public static bool operator !=(Jugador j1, Jugador j2)
        {
            return !(j1 == j2);
        }


    }
}
