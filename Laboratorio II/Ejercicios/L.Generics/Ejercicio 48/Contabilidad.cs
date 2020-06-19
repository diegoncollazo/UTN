using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_48
{
    //El tipo U deberá tener una restricción que indique que deberá tener un constructor por defecto.
    public class Contabilidad<T, U> where T : Documento where U : Documento, new()
    {
        private List<T> egresos;
        private List<U> ingresos;

        public List<T> Egresos
        {
            get 
            { 
                return egresos;
            }
            set
            { 
                egresos = value;
            }
        }
        public List<U> Ingresos
        {
            get 
            {
                return ingresos;
            }
            set 
            { 
                ingresos = value;
            }
        }
        public Contabilidad()
        {
            this.egresos = new List<T>();
            this.ingresos = new List<U>();
        }
        public static Contabilidad<T, U> operator +(Contabilidad<T, U> contabilidad, T egreso)
        {
            contabilidad.Egresos.Add(egreso);
            return contabilidad;
        }
        public static Contabilidad<T, U> operator +(Contabilidad<T, U> contabilidad, U ingreso)
        {
            contabilidad.Ingresos.Add(ingreso);
            return contabilidad;
        }
    }
}
