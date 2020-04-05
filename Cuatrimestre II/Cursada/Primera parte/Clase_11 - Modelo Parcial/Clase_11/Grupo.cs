using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_11
{
    public class Grupo
    {
        private List<Mascota> _manada = new List<Mascota>();
        private string _nombre;
        private static ETipoManada _tipo; //Es estatico

        #region Set

        public static ETipoManada Tipo
        {
            set
            {
                Grupo._tipo = value;
            }
        }

        #endregion

        #region Constructores

        //Inicializa el tipo unica
        static Grupo()
        {
            Grupo._tipo = ETipoManada.Unica;
        }

        //Iniciaiza la lista
        private Grupo()
        {
            this._manada = new List<Mascota>();
        }

        //Inicializa el nombre
        public Grupo(string nombre) : this()
        {
            this._nombre = nombre;
        }

        //Recibe nombre y tipo
        public Grupo(string nombre, ETipoManada tipoManada) : this (nombre)
        {
            Grupo._tipo = tipoManada;
        }

        #endregion

        #region Sobrecarga de Operadores

        public static bool operator ==(Grupo grupo, Mascota mascota)
        {
            bool retorno = false;

            foreach(Mascota masc in grupo._manada)
            {
                if(masc == mascota)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Grupo grupo, Mascota mascota)
        {
            return !(grupo == mascota);
        }

        public static Grupo operator +(Grupo grupo, Mascota mascota)
        {
            if (grupo != mascota)
            {
                grupo._manada.Add(mascota);
            }

            else
            {
                Console.WriteLine("Ya esta el {0} en el grupo", mascota);
            }


            return grupo;

        }

        public static Grupo operator -(Grupo grupo, Mascota mascota)
        {
            if (grupo == mascota)
            {
                grupo._manada.Remove(mascota);
            }

            else
            {
                Console.WriteLine("No esta el {0} en el grupo", mascota);
            }

            return grupo;
        }

        public static implicit operator string(Grupo grupo)
        {
            string retorno = "";

            retorno = "Grupo: " + grupo._nombre + " - Tipo: " + Grupo._tipo + "\nIntegrantes: <" + grupo._manada.Count + ">\n" ;

            foreach (Mascota mascota in grupo._manada)
            {
                retorno += mascota.ToString() + "\n";
            }

            return retorno;
        }

        #endregion
    }
}
