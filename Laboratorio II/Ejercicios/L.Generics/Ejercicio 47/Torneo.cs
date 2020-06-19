using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_47
{
    public class Torneo<T> where T : Equipo
    {
        private List<T> equipos;
        private string nombre;
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        private Torneo()
        {
            this.equipos = new List<T>();
        }
        public Torneo(string nombre) : this()
        {
            this.Nombre = nombre;
        }

        public static bool operator ==(Torneo<T> torneo, T equipo)
        {
            bool retorno = false;
            foreach (Equipo item in torneo.equipos)
                if (item.Nombre == equipo.Nombre && item.FechaCreacion == equipo.FechaCreacion)
                {
                    retorno = true;
                    break;
                }
            return retorno;
        }
        public static bool operator !=(Torneo<T> torneo, T equipo)
        {
            return !(torneo == equipo);
        }
        public static bool operator +(Torneo<T> torneo, T equipo)
        {
            bool retorno = false;
            if (torneo != equipo)
            {
                torneo.equipos.Add(equipo);
                retorno = true;
            }
            return retorno;
        }

        public string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Torneo: {0}\n", this.Nombre);
            retorno.AppendFormat("Equipos inscriptos: {0}\n", this.equipos.Count);
            retorno.Append("************************************\n");
            foreach (Equipo item in this.equipos)
                retorno.AppendLine(Equipo.Ficha(item));
            return retorno.ToString();
        }

        private string CalculaPartido(T a, T b)
        {
            Random goles = new Random();
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("{0}:\t {1} goles - {2}:\t {3} goles."
                , a.Nombre, goles.Next(0, 10), b.Nombre, goles.Next(0, 10));
            return retorno.ToString();
        }
        public string JugarPartido()
        {
            int a = new Random().Next(0, equipos.Count);
            int b = new Random().Next(0, equipos.Count);
            // Con la concidicion del While se asegura que no se repitan los equipos.
            while (a == b)
                b = new Random().Next(0, equipos.Count);
            return CalculaPartido(this.equipos[a], this.equipos[b]);
        }
    }
}
