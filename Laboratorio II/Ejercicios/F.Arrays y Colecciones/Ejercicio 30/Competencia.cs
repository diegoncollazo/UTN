using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_30
{
    public class Competencia
    {
        public enum ETipoCompetencia
        {
            F1, MotoCross
        }
        private short cantidadCompetidores;
        private short cantidadVueltas;
        public List<VehiculoDeCarrera> competidores;
        private ETipoCompetencia tipo;
        private Competencia()
        {
            this.competidores = new List<VehiculoDeCarrera>();
        }
        public Competencia(short cantidadVueltas, short cantidadCompetidores, ETipoCompetencia tipo) : this()
        {
            this.cantidadVueltas = cantidadVueltas;
            this.cantidadCompetidores = cantidadCompetidores;
            this.tipo = tipo;
        }
        public string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("Competencia de {0}\n", this.tipo.ToString());
            retorno.AppendFormat("Vueltas: {0}\n", this.cantidadVueltas);
            retorno.AppendFormat("Competidores: {0} de {1}\n\n", this.competidores.Count, this.cantidadCompetidores);
            foreach (VehiculoDeCarrera item in this.competidores)
            {
                if (item is AutoF1)
                    retorno.AppendLine(((AutoF1)item).MostrarDatos());
                else if (item is MotoCross)
                    retorno.AppendLine(((MotoCross)item).MostrarDatos());
            }

            return retorno.ToString();
        }
        public static bool operator ==(Competencia carrera, VehiculoDeCarrera vehiculo)
        {
            bool retorno = false;
            // Verifico que el vehiculo se encuentre en la competencia.
            foreach (VehiculoDeCarrera item in carrera.competidores)
            {
                if (item is AutoF1 && vehiculo is AutoF1)
                    if ((AutoF1)(item) == (AutoF1)(vehiculo))
                    {
                        retorno = true;
                        break;
                    }
                    else if (item is MotoCross && vehiculo is MotoCross)
                        if ((MotoCross)(item) == (MotoCross)(vehiculo))
                        {
                            retorno = true;
                            break;
                        }
            }
            return retorno;
        }
        public static bool operator !=(Competencia carrera, VehiculoDeCarrera vehiculo)
        {
            return !(carrera == vehiculo);
        }
        public static bool operator +(Competencia carrera, VehiculoDeCarrera vehiculo)
        {
            bool retorno = false;
            if (carrera != vehiculo)
            {
                if (carrera.competidores.Count == 0)
                {
                    if (carrera.tipo == ETipoCompetencia.F1 && vehiculo is AutoF1)
                    {
                        Competencia.AgregarCompetidor(carrera, vehiculo);
                        retorno = true;
                    }
                    else if (carrera.tipo == ETipoCompetencia.MotoCross && vehiculo is MotoCross)
                    {
                        Competencia.AgregarCompetidor(carrera, vehiculo);
                        retorno = true;
                    }
                }
                else if (carrera.cantidadCompetidores > carrera.competidores.Count)
                {
                    foreach (VehiculoDeCarrera item in carrera.competidores)
                    {
                        if (carrera.tipo == ETipoCompetencia.F1 && vehiculo is AutoF1)
                        {
                            Competencia.AgregarCompetidor(carrera, vehiculo);
                            retorno = true;
                            break;
                        }
                        else if (carrera.tipo == ETipoCompetencia.MotoCross && vehiculo is MotoCross)
                        {
                            Competencia.AgregarCompetidor(carrera, vehiculo);
                            retorno = true;
                            break;
                        }
                    }
                }
            }



            return retorno;
        }
        private static void AgregarCompetidor(Competencia carrera, VehiculoDeCarrera vehiculo)
        {
            carrera.competidores.Add(vehiculo);
            vehiculo.EnCompetencia = true;
            vehiculo.VueltasRestantes = carrera.cantidadVueltas;
            Random random = new Random();
            vehiculo.CantidadCumbustible = (short)(random.Next(15, 100));
        }
        public static bool operator -(Competencia carrera, VehiculoDeCarrera vehiculo)
        {
            bool retorno = false;
            foreach (VehiculoDeCarrera item in carrera.competidores)
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
