using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_36;

namespace Clase_30
{
    public class Competencia
    {
        public enum ETipoCompetencia
        {
            F1, MotoCross
        }
        private short cantidadCompetidores;
        private short cantidadVueltas;
        public List<VehichuloDeCarrera> competidores;
        private ETipoCompetencia tipo;
        private Competencia()
        {
            this.competidores = new List<VehichuloDeCarrera>();
        }
        public Competencia(short cantidadVueltas, short cantidadCompetidores, ETipoCompetencia tipo) : this()
        {
            this.cantidadVueltas = cantidadVueltas;
            this.cantidadCompetidores = cantidadCompetidores;
            this.tipo = tipo;
        }

        public string MostrarDatos()
        {
            return ""; 
        }
        public static bool operator ==(Competencia carrera, VehichuloDeCarrera vehiculo)
        {
            bool retorno = false;
            foreach (VehichuloDeCarrera item in carrera.competidores)
            {
                if (item == vehiculo)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Competencia carrera, VehichuloDeCarrera vehiculo)
        {
            return !(carrera == vehiculo);
        }
        public static bool operator +(Competencia carrera, VehichuloDeCarrera vehiculo)
        {
            bool retorno = false;
            if (carrera.competidores.Count > carrera.cantidadCompetidores)
            {
                foreach (VehichuloDeCarrera item in carrera.competidores)
                {
                    if ((vehiculo is AutoF1 && (AutoF1)item != (AutoF1)vehiculo && carrera.tipo == ETipoCompetencia.F1) || (vehiculo is MotoCross && (MotoCross)item != (MotoCross)vehiculo && carrera.tipo == ETipoCompetencia.MotoCross))
                    {
                        carrera.competidores.Add(vehiculo);
                        vehiculo.EnCompetencia = true;
                        vehiculo.VueltasRestantes = carrera.cantidadVueltas;
                        Random random = new Random();
                        vehiculo.CantidadCumbustible = (short)(random.Next(15, 100));
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        public static bool operator -(Competencia carrera, VehichuloDeCarrera vehiculo)
        {
            bool retorno = false;
            foreach (VehichuloDeCarrera item in carrera.competidores)
            {
                if (item == vehiculo)
                {
                    carrera.competidores.Remove(vehiculo);
                    vehiculo.EnCompetencia = false;
                    vehiculo.VueltasRestantes = 0;
                    vehiculo.CantidadCumbustible = 0;
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

    }
}
