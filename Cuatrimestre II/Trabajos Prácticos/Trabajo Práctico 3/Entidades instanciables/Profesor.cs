using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EClases = EntidadesInstanciables.Universidad.EClases;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estático, inicializo atributos estaticos.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }
        /// <summary>
        /// Constructor de instancia por defecto.
        /// </summary>
        public Profesor() 
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClase();
            this._randomClase();
        }
        /// <summary>
        /// Constructor de instancia con parametros.
        /// </summary>
        /// <param name="id">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">Documento</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClase();
            this._randomClase();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Genero una clase aletoria para el Profesor.
        /// </summary>
        private void _randomClase()
        {
            Array array = Enum.GetValues(typeof(EClases));
            clasesDelDia.Enqueue((EClases)array.GetValue(random.Next(array.Length)));
        }
        /// <summary>
        /// Devuelve todos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            //Datos base de la clase Universitario
            retorno.Append(base.MostrarDatos());
            retorno.Append(ParticiparEnClase());
            return retorno.ToString();
        }
        /// <summary>
        /// Devuelve las clases que dicta el Profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("\nClases del día:");
            foreach (EClases clase in this.clasesDelDia)
                retorno.AppendFormat("{0} ", clase);
            retorno.Append("\n");
            return retorno.ToString();
        }
        /// <summary>
        /// Devuelve los datos completos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        /// <summary>
        /// Chequea si el Profesor da esa Clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool retorno = false;
            foreach (EClases item in i.clasesDelDia)
                if (item == clase)
                    retorno = true;
            return retorno;
        }
        /// <summary>
        /// Chequea si el Profesor no da esa Clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
