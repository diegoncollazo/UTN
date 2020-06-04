using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Jornada.
        /// </summary>
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
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
        /// Propiedad de Lectura/Escritura de las materias de los alumnos.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura/Escritura del instructor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores
        //// <summary>
        /// Inicializa una nueva instancia de la clase Jornada. Inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Jornada.
        /// </summary>
        /// <param name="clase">Materia para la jornada.</param>
        /// <param name="instructor">Profesor para la jornada.</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar.</param>
        /// <param name="datos">Dato a guardar.</param>
        /// <returns>Retorna TRUE si logró grabar, FALSE en caso contrario.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt";
            return texto.Guardar(path, jornada.ToString());
        }
        /// <summary>
        /// Lee los datos de la Jornada desde un archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre del archivo.</param>
        /// <param name="datos">Datos de salida.</param>
        /// <returns>Retorna TRUE si logró leer, FALSE en caso contrario.</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            if (!(texto.Leer("Jornada.txt", out string retorno)))
                retorno = null;
            return retorno;
        }
        #endregion

        #region Polimorfismo
        /// <summary>
        /// Convierte el valor de la instancia en un objeto string.
        /// </summary>
        /// <returns>Cadena cuyo valor es el mismo que el de la instancia.</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("JORNADA: \n");
            retorno.Append("CLASE DE " + this.Clase);
            retorno.AppendLine(" POR " + this.Instructor);
            foreach (Alumno item in this.Alumnos)
                retorno.AppendLine(item.ToString());
            return retorno.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Compara si un Alumno se encuentra en Jornada.
        /// </summary>
        /// <param name="j">Instancia de Jornada</param>
        /// <param name="a">Instancia de Alumno.</param>
        /// <returns>Retornara TRUE si un alumno se encuentra en esa jornada, caso contrario FALSE.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in j.alumnos)
                if (item == a)
                    retorno = true;
            return retorno;
        }
        /// <summary>
        /// Compara si un Alumno no se encuentra en Jornada.
        /// </summary>
        /// <param name="j">Instancia de Jornada</param>
        /// <param name="a">Instancia de Alumno.</param>
        /// <returns>Retornara TRUE si un alumno no se encuentra en esa jornada, caso contrario FALSE.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Añade al alumno a la jornada si previamente no se encuentra cargado.
        /// </summary>
        /// <param name="j">Instancia de Jornada</param>
        /// <param name="a">Instancia de Alumno.</param>
        /// <returns>Retorna la jornada con el alumno agregado o lanza una excepción.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return j;
        }
        #endregion
    }
}
