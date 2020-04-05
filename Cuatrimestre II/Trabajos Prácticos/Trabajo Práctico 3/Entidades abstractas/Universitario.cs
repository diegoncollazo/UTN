using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor con parametros [base] + [legajo]
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna todos los datos del Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.ToString());
            retorno.AppendFormat("\nLegajo: {0}", this.legajo.ToString());
            return retorno.ToString();
        }
        /// <summary>
        /// Sobreescribo el metodo Equals comparando DNI o Legajo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object objeto)
        {
            bool retorno = false;
            if (objeto.GetType() == this.GetType())//Verifico si son objetos de la misma clase
                if (((Universitario)objeto).Dni == this.Dni || ((Universitario)objeto).legajo == this.legajo)
                    retorno = true;
            return retorno;
        }
        /// <summary>
        /// Sobreescribo metodo [==] 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }
        /// <summary>
        /// Sobreescribo metodo [!=] 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Metodo abstracto y protegido
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
