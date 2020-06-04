using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Universitario.
        /// </summary>
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase Universitario.
        /// </summary>
        public Universitario() : base()
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Universitario.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"> Nombre a ser cargado </param>
        /// <param name="apellido"> Apellido a ser cargado </param>
        /// <param name="dni"> DNI a ser cargado </param>
        /// <param name="nacionalidad"> Nacionalidad a ser cargada </param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Polimorfismo
        /// <summary>
        /// Verifica si esta instancia y un objeto especificado son iguales.
        /// </summary>
        /// <param name="obj">Instancia a comprobar.</param>
        /// <returns>Retorna TRUE si son del mismo tipo, mismo DNI y Legajo, de lo contrario FALSE.</returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == this.GetType() 
                && ((Universitario)obj).DNI == this.DNI || ((Universitario)obj).legajo == this.legajo;
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Verifica si dos instancias Universitario son iguales.
        /// </summary>
        /// <param name="pg1">Instancia a comparar.</param>
        /// <param name="pg2">Instancia a comparar.</param>
        /// <returns>Retorna TRUE si ambas instancia son iguales, de lo contrario FALSE.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }
        /// <summary>
        /// Verifica si dos instancias Universitario no son iguales.
        /// </summary>
        /// <param name="pg1">Instancia a comparar.</param>
        /// <param name="pg2">Instancia a comparar.</param>
        /// <returns>Retorna TRUE si ambas instancia no son iguales, de lo contrario FALSE.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1.Equals(pg2));
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra los datos cargados de la clase Universitario.
        /// </summary>
        /// <returns>Retorna un string con todos los datos de la clase.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.ToString());
            retorno.AppendFormat("\nLEGAJO NUMERO: {0}\n", this.legajo);
            return retorno.ToString();
        }
        /// <summary>
        /// Firma de método abstracto.
        /// </summary>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
