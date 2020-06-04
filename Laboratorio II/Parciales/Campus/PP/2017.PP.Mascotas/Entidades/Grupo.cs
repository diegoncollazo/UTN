using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{


    public class Grupo
    {
        public enum TipoManada
        {
            Única,
            Mixta
        }

        private List<Mascota> mascotas;
        private string nombre;
        private static TipoManada tipo;

        static Grupo()
        {
            Grupo.tipo = TipoManada.Única;
        }
        private Grupo()
        {
            this.mascotas = new List<Mascota>();
        }
        public Grupo(string nombre) : this()
        {
            this.nombre = nombre;
        }
        public Grupo(string nombre, TipoManada tipo) : this(nombre)
        {
            Grupo.tipo = tipo;
        }

        public static implicit operator string(Grupo grupo)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Nombre: {0}\n", grupo.nombre);
            retorno.AppendFormat("Tipo de manada: {0}\n", Grupo.tipo.ToString());
            retorno.AppendFormat("Cantidad de mascotas: {0}\n\n", grupo.mascotas.Count);
            foreach(Mascota item in grupo.mascotas)
            {
                if (item is Perro)
                    retorno.AppendLine(((Perro)(item)).ToString());
                else if (item is Gato)
                    retorno.AppendLine(((Gato)(item)).ToString());
            }
            return retorno.ToString();
        }

        public static bool operator ==(Grupo grupo, Mascota mascota)
        {
            bool retorno = false;
            foreach (Mascota item in grupo.mascotas)
            {
                if (item is Gato && mascota is Gato)
                {
                    if ((Gato)mascota == (Gato)item)
                        retorno = true;
                }
                else if (item is Perro && mascota is Perro)
                {
                    if ((Perro)mascota == (Perro)item)
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
                grupo.mascotas.Add(mascota);
            return grupo;
        }
        public static Grupo operator -(Grupo grupo, Mascota mascota)
        {
            if (grupo == mascota)
                grupo.mascotas.Remove(mascota);
            return grupo;
        }
    }
}
