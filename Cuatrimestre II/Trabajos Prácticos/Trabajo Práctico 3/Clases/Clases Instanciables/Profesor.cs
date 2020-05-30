using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Profesor : Universitario
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Profesor.
        /// </summary>
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de clase. Inicializo atributos estaticos.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Profesor. Asigno al azar dos materias al Profesor.
        /// </summary>
        public Profesor() : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Profesor.
        /// </summary>
        /// <param name="id">ID del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">DNI del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Genera una clase aleatoria y la agrega a la clase del dia
        /// </summary>
        private void _randomClases()
        {
            Array arrayEclases = Enum.GetValues(typeof(Universidad.EClases));
            Universidad.EClases claseRandom = (Universidad.EClases)random.Next(arrayEclases.Length);
            this.clasesDelDia.Enqueue(claseRandom);
        }
        #endregion

        #region Polimorfismo
        /// <summary>
        /// Muestra los datos cargados de la clase Profesor.
        /// </summary>
        /// <returns>Retorna un string con todos los datos de la clase.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.MostrarDatos());
            retorno.Append(ParticiparEnClase());
            return retorno.ToString();
        }
        /// <summary>
        /// Muestra las materias que dicta el profesor.
        /// </summary>
        /// <returns>Retorna un string con las materias que dicta el profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in this.clasesDelDia)
                retorno.Append(item.ToString() + "\n");
            return retorno.ToString();
        }
        /// <summary>
        /// Convierte el valor de la instancia en un objeto string.
        /// </summary>
        /// <returns>Cadena cuyo valor es el mismo que el de la instancia.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Compara si un Profesor dicta determinada materia.
        /// </summary>
        /// <param name="i">Instancia de Profesor.</param>
        /// <param name="clase">Instancia de clase.</param>
        /// <returns>Retornara TRUE si el profesor dicta esa clase, FALSE caso contrario.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            //Recorro la Queue de clases del objeto Profesor.
            foreach (Universidad.EClases item in i.clasesDelDia)
                if (item == clase)
                    retorno = true;
            return retorno;
        }
        /// <summary>
        /// Compara si un Profesor no dicta determinada materia.
        /// </summary>
        /// <param name="i">Instancia de Profesor.</param>
        /// <param name="clase">Instancia de clase.</param>
        /// <returns>Retornara TRUE si el profesor no dicta esa clase, FALSE caso contrario.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
