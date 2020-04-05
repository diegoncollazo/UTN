using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Atributos
        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad DNI [int] con validacion
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }

        }
        /// <summary>
        /// Propiedad DNI [string] con validacion
        /// </summary>
        public string StringDni
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad Nombre con validacion
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad Nombre con validacion
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        #endregion

        #region Constructores
        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this(nombre, apellido, null, nacionalidad)
        {

        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, dni.ToString(), nacionalidad)
        {

        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.StringDni = dni;
            this.Nacionalidad = nacionalidad;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Reescribo el ToString retornando datos completo de la persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Apellido: {0}", this.apellido);
            retorno.AppendFormat("\nNombre: {0}", this.nombre);
            retorno.AppendFormat("\nDNI: {0}", this.Dni);
            retorno.AppendFormat("\nNacionalidad: {0}", this.nacionalidad);
            return retorno.ToString();
        }
        /// <summary>
        /// Valido DNI segun nacionalidad.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato < 90000000)
                return dato;
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato < 100000000)
                return dato;
            else
                throw new DniInvalidoException("Numero de DNI no coincide con nacionalidad.");
        }
        /// <summary>
        /// Valido DNI segun nacionalidad.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            Regex regex = new Regex("^[0-9]+?$");
            if (regex.IsMatch(dato) && int.TryParse(dato, out int auxDni))
                return ValidarDni(nacionalidad, auxDni);
            else
                throw new DniInvalidoException("Formato incorrecto");
        }
        /// <summary>
        /// Validad cadena de caracteres Nombre/Apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = null;
            Regex regex = new Regex("^[a-z|A-Z]+?$");
            if (regex.IsMatch(dato))
                retorno = dato;
            return retorno;
        }
        #endregion
    }
}
