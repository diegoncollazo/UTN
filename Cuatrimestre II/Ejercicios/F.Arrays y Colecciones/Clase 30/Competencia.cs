using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_30
{
    public class Competencia
    {
        private short cantidadCompetidores;
        private short cantidadVueltas;
        private List<AutoF1> competidores;

        private Competencia()
        {
            this.competidores = new List<AutoF1>();
        }
        public Competencia(short cantidadVueltas, short cantidadCompetidores) : this()
        {
            this.cantidadVueltas = cantidadVueltas;
            this.cantidadCompetidores = cantidadCompetidores;
        }

        public string MostrarDatos()
        {
            return "";
        }

        public static bool operator ==(Competencia c, AutoF1 a)
        {
            bool retorno = false;
            foreach (AutoF1 item in c.competidores)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator !=(Competencia c, AutoF1 a)
        {
            return !(c == a);
        }
        public static bool operator +(Competencia c, AutoF1 a)
        {
            bool retorno = false;
            foreach (AutoF1 item in c.competidores)
            {
                if (item != a)
                {
                    if (c.competidores.Count >= c.cantidadCompetidores)
                    {
                        c.competidores.Add(a);
                        a.EnCompetencia = true;
                        a.VueltasRestantes = c.cantidadVueltas;
                        Random random = new Random();
                        a.CantidadCumbustible = (short)(random.Next(15, 100));
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        public static bool operator -(Competencia c, AutoF1 a)
        {
            bool retorno = false;
            foreach (AutoF1 item in c.competidores)
            {
                if (item == a)
                {
                    c.competidores.Remove(a);
                    a.EnCompetencia = false;
                    a.VueltasRestantes = 0;
                    a.CantidadCumbustible = 0;
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

    }
}
