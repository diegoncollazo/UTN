using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EClases = EntidadesInstanciables.Universidad.EClases;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public EClases Clase
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
        /// 
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
        /// <summary>
        /// Constructor privado sin parametros. Inicializo la lista de Alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor público con parametros.
        /// </summary>
        /// <param name="clase">Clase</param>
        /// <param name="instructor">Profesor</param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Metódos
    /// <summary>
    ///             FINALIZAR
    /// </summary>
    /// <param name="jornada"></param>
    /// <returns></returns>
        public bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            string path = "";

            path = AppDomain.CurrentDomain.BaseDirectory + @"\miArchivo.txt";
            //StreamReader lectura = new StreamReader(path, true);

            if (path != "")
            {
                StreamWriter escritura = new StreamWriter(path, true);
                string valor = this.ToString(); //Paso el valor del texto, lo que se va a escribir a un atributo
                escritura.WriteLine("{0}", valor); //Una vez que recibe el valor lo copia en miArchivo.txt
                escritura.Close();//Una vez que termina de escribir o leer se tiene que cerrar
            }
            return retorno;
        }
        /// <summary>
        ///             FINALIZAR
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            

            return "";
        }
        /// <summary>
        /// Datos completos de la Jornada.
        /// </summary>
        /// <returns></returns>
        #endregion

        #region Sobreescritura de Metódos
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("*** Jornada ***");
            retorno.AppendFormat("Clase de {0}\n", this.Clase.ToString());
            retorno.AppendLine("\n*** Profesor ****");
            retorno.AppendLine(this.Instructor.ToString());
            retorno.AppendLine("*** Alumnos ***");
            foreach (Alumno item in this.Alumnos)
                retorno.AppendFormat("{0}\n\n",item.ToString());
            return retorno.ToString();
        }
        #endregion

        #region Sobreescritura de operadores
        /// <summary>
        /// 
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach(Alumno item in j.Alumnos)
                if (item == a)
                    retorno = true;
            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Sumo el Alumno a la Jornada, previo chequeo que no exista.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);
            //else
                //Arrojar Excepcion
            return j;
        }
        #endregion
    }
}
