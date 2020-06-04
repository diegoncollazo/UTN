using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        private const int cantidadMaximaJugadores = 6;
        private DirectorTecnico directorTecnico;
        private List<Jugador> jugadores;
        private string nombre;

        public DirectorTecnico DirectorTecnico
        {
            set
            {
                if (value.ValidadAptitud())
                    this.directorTecnico = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        private Equipo()
        {
            this.jugadores = new List<Jugador>();
        }
        public Equipo(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public static explicit operator string(Equipo e)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Nombre del equipo: {0}\n",e.Nombre);
            if (e.directorTecnico != null)
                retorno.Append(e.directorTecnico.Mostrar());
            else
                retorno.Append("Sin Director Técnico.\n");
            foreach(Jugador item in e.jugadores)
            {
                retorno.AppendFormat("Jugador {0}\n", item.Mostrar());
            }
            return retorno.ToString();
        }

        public static bool operator ==(Equipo e, Jugador j)
        {
            bool retorno = false;
            foreach (Jugador item in e.jugadores)
                if (item == j)
                    retorno = true;
            return retorno;
        }
        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e == j);
        }

        public static Equipo operator +(Equipo e, Jugador j)
        {
            if (e != j && e.jugadores.Count < cantidadMaximaJugadores && j.ValidadAptitud())
                e.jugadores.Add(j);
            return e;
        }

        public static bool ValidarEquipo(Equipo e)
        {
            int arq = 0, def = 0, cen = 0, del = 0;
            foreach (Jugador item in e.jugadores)
            {
                if (item.Posicion == Posicion.Arquero)
                    arq++;
                else if (item.Posicion == Posicion.Central)
                    cen++;
                else if (item.Posicion == Posicion.Defensor)
                    def++;
                else if (item.Posicion == Posicion.Delantero)
                    del++;
            }
            return (e.directorTecnico != null && e.jugadores.Count == cantidadMaximaJugadores && arq == 1 && cen >= 1 && def >= 1 && del >= 1);
        }
    }
}
