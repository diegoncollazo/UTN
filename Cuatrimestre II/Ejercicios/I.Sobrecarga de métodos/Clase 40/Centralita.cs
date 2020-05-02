using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Clase_41;

namespace Clase_37
{
    public class Centralita
    {
        //Atributos
        protected string razonSocial;
        private List<Llamada> listaDeLlamadas;
        //Propiedades
        public float GananciasPorLocal
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Local);
            }
        }
        public float GananciasPorProvincia
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Provincial);
            }
        }
        public float GananciasPorTotal
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Todas);
            }
        }
        public List<Llamada> Llamadas
        {
            get
            {
                return this.listaDeLlamadas;
            }
        }
        //Constructores
        public Centralita()
        {
            this.listaDeLlamadas = new List<Llamada>();
        }
        public Centralita(string nombre) : this()
        {
            this.razonSocial = nombre;
        }
        //Metodos
        private float CalcularGanancia(TipoLlamada tipo)
        {
            float retorno = new float();
            foreach(Llamada item in this.listaDeLlamadas)
            {
                switch (tipo)
                {
                    case TipoLlamada.Local:
                        if (item is Local)
                            retorno += ((Local)(item)).CostoLlamada;
                        break;
                    case TipoLlamada.Provincial:
                        if (item is Provincial)
                            retorno += ((Provincial)item).CostoLlamada;
                        break;
                    case TipoLlamada.Todas:
                        if (item is Local)
                            retorno += ((Local)(item)).CostoLlamada;
                        else if (item is Provincial)
                            retorno += ((Provincial)item).CostoLlamada;
                        break;
                }
            }
            return retorno;
        }
        //Ordenar
        public void OrdenarLlamadas()
        {
            this.listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }
        /* Terminar */
        private string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            foreach (Llamada item in this.Llamadas)
            {
                if (item is Local)
                    retorno.AppendLine(((Local)(item)).ToString());
                else if (item is Provincial)
                    retorno.AppendLine(((Provincial)(item)).ToString());
            }
            return retorno.ToString();
        }
        //Agregar Llamada
        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            this.listaDeLlamadas.Add(nuevaLlamada);
        }
        //Igual
        public static bool operator ==(Centralita centralita, Llamada llamada)
        {
            bool retorno = false;
            foreach (Llamada item in centralita.listaDeLlamadas)
                if (item == llamada)
                    retorno = true;
            return retorno;
        }
        //Distinto
        public static bool operator !=(Centralita centralita, Llamada llamada)
        {
            return !(centralita == llamada);
        }
        //Sumar
        public static Centralita operator +(Centralita centralita, Llamada llamada)
        {
            //try
            //{
                if (centralita != llamada)
                    centralita.listaDeLlamadas.Add(llamada);
            //    else
            //        throw new CentralitaException("¡No se pudo agregar la llamada!\n", "Clase", "Metodo");
            //}
            //catch(CentralitaException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            return centralita;
        }
        //ToString
        public override string ToString()
        {
            return Mostrar();
        }
    }
}
