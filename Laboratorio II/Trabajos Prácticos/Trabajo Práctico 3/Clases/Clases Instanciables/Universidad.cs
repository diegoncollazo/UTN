using System;
using System.Collections.Generic;
using System.Text;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Enumerados
        /// <summary>
        /// Enumerado de los tipos de materias.
        /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Atributos de la clase Universidad.
        /// </summary>
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de Lectura/Escritura de la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura/Escritura de la lista de profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura/Escritura de la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de Lectura/Escritura de una jornada determinada por índice.
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];

            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Universidad. Inicializa las listas.
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornada = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos cargados de la clase Universidad.
        /// </summary>
        /// <param name="uni">Instancia de Universidad.</param>
        /// <returns>Retorna un string con todos los datos de la clase.</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder retorno = new StringBuilder();
            foreach (Jornada item in uni.Jornada)
                retorno.Append(item.ToString());
            return retorno.ToString();
        }
        /// <summary>
        /// Guarda los datos en un archivo XML serializando los datos.
        /// </summary>
        /// <param name="uni">Clase a serializar.</param>
        /// <returns>Devuelve TRUE si logró grabar, FALSE en caso contrario.</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", uni);
        }
        /// <summary>
        /// Lee los datos de un archivo XML serializado.
        /// </summary>
        /// <returns>Devuelve una instancia de Universidad.</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out Universidad universidad);
            return universidad;
        }
        #endregion

        #region Polimorfismo
        /// <summary>
        /// Convierte el valor de la instancia en un objeto string.
        /// </summary>
        /// <returns>Cadena cuyo valor es el mismo que el de la instancia.</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Verifica si el Alumno se en encuentra en la Universidad.
        /// </summary>
        /// <param name="g">Instancia de Universidad.</param>
        /// <param name="a">Instancia de Alumno.</param>
        /// <returns>Devuelve TRUE si el alumno se encuentra en la universidad, FALSE caso contrario.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in g.alumnos)
                if (item == a)
                {
                    retorno = true;
                    break;
                }   
            return retorno;
        }
        /// <summary>
        /// Verifica si el Alumno no se en encuentra en la Universidad.
        /// </summary>
        /// <param name="g">Instancia de Universidad.</param>
        /// <param name="a">Instancia de Alumno.</param>
        /// <returns>Devuelve TRUE si el alumno no se encuentra en la universidad, FALSE caso contrario.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Verifica si el Profesor dicta clases en la Universidad.
        /// </summary>
        /// <param name="g">Instancia de Universidad.</param>
        /// <param name="i">Instancia de Profesor.</param>
        /// <returns>Devuelve TRUE si el profesor dicta clases en la universidad, FALSE caso contrario.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor item in g.profesores)
                if (item == i)
                {
                    retorno = true;
                    break;
                }
            return retorno;
        }
        /// <summary>
        /// Verifica si el Profesor no dicta clases en la Universidad.
        /// </summary>
        /// <param name="g">Instancia de Universidad.</param>
        /// <param name="i">Instancia de Profesor.</param>
        /// <returns>Devuelve TRUE si el profesor no dicta clases en la universidad, FALSE caso contrario.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Verifica si un Profesor puede dictar determinada Clase.
        /// </summary>
        /// <param name="u">Instancia de Universidad.</param>
        /// <param name="clase">Instancia de Clase.</param>
        /// <returns>Devuelve un Profesor si puede dictar esa materia en la universidad, caso contrario lanza una excepción.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
                if (item == clase)
                    return item;
            throw new SinProfesorException();
        }
        /// <summary>
        /// Verifica si un Profesor no puede dictar determinada Clase.
        /// </summary>
        /// <param name="u">Instancia de Universidad.</param>
        /// <param name="clase">Instancia de Clase.</param>
        /// <returns>Devuelve null si no puede dictar esa materia en la universidad, caso contrario devuelve un Profesor.</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            foreach (Profesor item in u.profesores)
                if (item != clase)
                    retorno = item;
            return retorno;
        }
        /// <summary>
        /// Agrega una Clase a la Universidad.
        /// </summary>
        /// <param name="g">Instancia de Universidad.</param>
        /// <param name="clase">Instancia de Clase</param>
        /// <returns>Devuelvo una universidad si se encuentra instructor para esa clase, caso contrario
        /// lanzo una excepción.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            //Genero un objeto Profesor = null
            Profesor profesor;
            try
            {
                //Busca un profesor para esa clase
                profesor = g == clase;
            }
            catch (Exception)
            {
                throw new SinProfesorException();
            }
            //Genero Jornada con Clase
            Jornada jornada = new Jornada(clase, profesor);
            //Agrego Alumno(s) a Jornada
            foreach (Alumno item in g.Alumnos)
                if (item == clase)
                    jornada += item;
            g.Jornada.Add(jornada);
            return g;
        }
        /// <summary>
        /// Agrega un Alumno a la Universidad.
        /// </summary>
        /// <param name="u">Instancia de Universidad.</param>
        /// <param name="a">Instancia de Alumno.</param>
        /// <returns>Devuelvo una Universidad con el Alumno cargado, caso contrario lanzo una excepción.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (!(u == a))
                u.alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return u;
        }
        /// <summary>
        /// Agrega un Profesor a la Universidad.
        /// </summary>
        /// <param name="universidad">Instancia de Universidad.</param>
        /// <param name="instructor">Instancia de Profesor.</param>
        /// <returns>Devuelvo una Universidad con o sin el Profesor cargado.</returns>
        public static Universidad operator +(Universidad universidad, Profesor instructor)
        {
            if (universidad != instructor)
                universidad.profesores.Add(instructor);
            return universidad;
        }
        #endregion
    }
}
