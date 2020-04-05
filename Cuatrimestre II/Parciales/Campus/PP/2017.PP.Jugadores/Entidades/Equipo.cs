using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        private static EDeportes deportes;
        private DirectorTecnico directorTecnico;
        private List<Jugador> jugadores;
        private string nombre;

        public EDeportes Deporte
        {
            set
            {
                deportes = value;
            }
        }

        private Equipo()//Inicializa la lista
        {
            this.jugadores = new List<Jugador>();
        }

        static Equipo()//Inicializa el deporte como futbol
        {
            deportes = EDeportes.Futbol;
        }

        public Equipo(string nombre, DirectorTecnico directorTecnico) : this()
        {
            this.nombre = nombre;
            this.directorTecnico = directorTecnico;
        }

        public Equipo(string nombre, DirectorTecnico directorTecnico, EDeportes deporte) : this(nombre, directorTecnico)
        {
            deportes = deporte;
        }

        public static bool operator ==(Equipo e, Jugador j)
        {
            bool retorno = false;

            foreach (Jugador jug in e.jugadores)
            {
                if (jug == j)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e == j);
        }

        public static Equipo operator +(Equipo e, Jugador j)
        {
            if (e != j)
            {
                e.jugadores.Add(j);
            }

            return e;
        }

        public static Equipo operator -(Equipo e, Jugador j)
        {
            if (e == j)
            {
                e.jugadores.Remove(j);
            }
            return e;
        }

        public static implicit operator string(Equipo e)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("**{0} {1}**\n", e.nombre, deportes);
            retorno.AppendLine("Nomina de jugadores: ");

            foreach (Jugador jugador in e.jugadores)
            {
                retorno.AppendLine(jugador.ToString());
            }

            retorno.AppendFormat("Dirigido por: {0}", e.directorTecnico.ToString());

            return retorno.ToString();
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

            if(obj is Jugador)
            {
                if (obj == this)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
    }
}

