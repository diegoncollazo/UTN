using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Grupo
    {
        private List<Mascota> manada;
        private string nombre;
        private static ETipoManada tipo;

        public static ETipoManada Tipo
        {
            set
            {
                Grupo.tipo = value;
            }
        }
        static Grupo()
        {
            Grupo.tipo = ETipoManada.Unica;
        }       
        private Grupo()
        {
            this.manada = new List<Mascota>();
        }        
        public Grupo(string nombre) : this()
        {
            this.nombre = nombre;
        }        
        public Grupo(string nombre, ETipoManada tipo) : this(nombre)
        {
            Grupo.tipo = tipo;
        }
        public static implicit operator string(Grupo grupo)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Grupo: {0} - tipo: {1}\n", grupo.nombre, Grupo.tipo.ToString());
            retorno.AppendFormat("Integrantes: ({0})\n", grupo.manada.Count);
            foreach (Mascota item in grupo.manada)
            {
                if (item is Perro)
                    retorno.AppendLine(((Perro)item).ToString());
                else if (item is Gato)
                    retorno.AppendLine(((Gato)item).ToString());
            }
            return retorno.ToString();
        }

        public static bool operator ==(Grupo grupo, Mascota mascota)
        {
            bool retorno = false;
            foreach(Mascota item in grupo.manada)
            {
                if (item is Perro && ((Perro)item).Equals(mascota)) 
                {
                    retorno = true;
                    break;
                }
                else if (item is Gato && ((Gato)item).Equals(mascota))
                {
                    retorno = true;
                    break;
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
                grupo.manada.Add(mascota);
            else
            {
                if (mascota is Perro)
                    Console.WriteLine("Ya está '" + ((Perro)mascota).ToString() + "' en el grupo");
                else if (mascota is Gato)
                    Console.WriteLine("Ya está '" + ((Gato)mascota).ToString() + "' en el grupo");
            }
            return grupo;
        }        
        public static Grupo operator -(Grupo grupo, Mascota mascota)
        {
            if (grupo == mascota)
                grupo.manada.Remove(mascota);
            else
                if (mascota is Perro)
                    Console.WriteLine("No está el " + ((Perro)mascota).ToString() + " en el grupo.");
                else if (mascota is Gato)
                Console.WriteLine("No está el " + ((Gato)mascota).ToString() + " en el grupo.");
            return grupo;
        }
    }
}
