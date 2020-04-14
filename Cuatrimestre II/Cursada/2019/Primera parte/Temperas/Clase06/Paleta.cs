using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase06
{
    public class Paleta
    {
        //Atributos
        private Tempera[] _temperas;//Como un vector
        private int _cantidadTemperas;//La cantidad maxima

        private Paleta(int cantidad)
        {
            this._temperas = new Tempera[cantidad];//Como es un array, instancio Tempera.
            this._cantidadTemperas = cantidad;//Cantidad maxima de temperas.
        }

        private Paleta() : this(0)//Cantidad maxima 5
        {

        }

        //Getter & Setter para cada tempera del array [con índice].
        private Tempera[] myTempera; //Definimos un set y get llamado myTempera

        public Tempera[] myTemperas
        {
            get { return this._temperas; }
            set { this._temperas = value; }
        }
        //Constructor
        //Generar sobrecarga del implicit Paleta
        public static implicit operator Paleta(int cantidad) //Se definiria paleta(cantidadPasada)
        {
            Paleta paleta = new Paleta(cantidad); //Creamos nueva paleta con los enteros que le pasamos y retornamos esa paleta creada
            return paleta;
        }
        //Mostrar paleta con todas las temperas.
        private string Mostrar()
        {
            string aux = "";
            foreach (Tempera tempera in this._temperas) //Con el foreach, en el auxilar se le almacena las this.temperas
            {
                aux = aux + ""+ Tempera.Mostrar(tempera); //Se van cargando todas y se van mostrando
            }
            return "Cantidad " + this._cantidadTemperas.ToString() + "-" + aux; //Retornamos la cantidad maxima y las temperas cargadas
        }
        //Mostrar paleta de manera explicita.
        public static explicit operator string(Paleta paleta)//Nos muestra la paleta que le pasamos como parametro
        {
            return paleta.Mostrar(); //Reutilizamos codigo
        }

        //Operadores
        //Operador Igual [==]
        public static bool operator ==(Paleta paleta, Tempera tempera)
        {//Verificamos que la tempera que pasamos este en la paleta.
            bool retorno = false;
            for (int i = 0; i < paleta._cantidadTemperas; i++)
            {//Recorro la cantidad maxima de paletas.
                if (paleta._temperas[i] == tempera)
                {//Si coincide la tempera que esta en la paleta con la tempera pasada devuelve true
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        //Operador Distinto [!=]
        public static bool operator !=(Paleta paleta, Tempera tempera)
        {
            return !(paleta == tempera); 
        }

        //Buscar indice para agregar una tempera.
        private int ObtenerIndice()
        {
            int indice = -1; //Declaramos una variable índice que devuelve -1 si no funciona.
            int i = 0;
            foreach (Tempera t in _temperas)//Recorremos todas las temperas y tomamos el valor en t
            {
                if (object.Equals(t, null))//Buscamos el primer null en el array.
                {
                    indice = i;//Asigno el índice encontrado y lo retorno.
                    break; //Corto la busqueda.
                }
                i++;//Incremento índice.
            }
            return indice;

        }
        //Operadores
        //Operador Suma [+] - Agrego una tempera a la paleta.
        public static Paleta operator +(Paleta paleta, Tempera tempera)
        {
            if (!(paleta == tempera))//Agrego tempera solamente si ya no se encuentra en la paleta [!false].
            {//Busco lugar vacío para agregar la tempera.
                paleta._temperas[paleta.ObtenerIndice()] = tempera;
            }
            return paleta; //Retornamos la paleta cargada.
        }
        //Operador Resta [-] - Quito una tempera a la paleta.
        public static Paleta operator -(Paleta paleta, Tempera tempera)
        {
            int i = 0;
            foreach (Tempera t in paleta._temperas)
            {//Recorro las temperas en la paleta.
                if(t == tempera)
                {
                    paleta._temperas[i] = null;//Pongo en null [sin borrar] la paleta encontrada.
                    break;
                }
                i++;
            }
            return paleta; //Retornamos la peleta cargada
        }
    }
}
