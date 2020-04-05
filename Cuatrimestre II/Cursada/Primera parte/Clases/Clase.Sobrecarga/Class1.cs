using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase04_Entidades
{
    public class Cosa
    {
        public int entero;
        public string cadena;
        public DateTime fecha;

        #region Constructores
        public Cosa()
        {
            this.entero = 10;
            this.cadena = "sinvalor";
            this.fecha = DateTime.Now;
        }
        //Un parametro
        public Cosa(int unEntero) : this()
        {
            this.entero = unEntero;
        }
        //Dos parametros
        public Cosa(int unEntero, DateTime unaFecha) : this(unEntero)
        {
            this.fecha = unaFecha;
        }
        //Tres parametros
        public Cosa(int unEntero, DateTime unaFecha, string unaCadena) : this(unEntero, unaFecha)
        {
            this.cadena = unaCadena;
        }
        #endregion
        
        //Retorna el objeto en STRING
        public string Mostrar()
        {
            return this.cadena + "-" + this.entero.ToString() + "-" + this.fecha.ToString();
        }

        //Retorna el objeto que se pasa como parametro en STRING
        public static string Mostrar(Cosa miCosa)
        {
            return miCosa.Mostrar();
        }

        public void EstablecerValor(int parametro)
        {
            this.entero = parametro;
        }

        public void EstablecerValor(string parametro)
        {
            this.cadena = parametro;
        }

        public void EstablecerValor(DateTime parametro)
        {
            this.fecha = parametro;
        }
    }
}
