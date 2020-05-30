using System.Text;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerado
        /// <summary>
        /// Enumerados de nacionalidad.
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Atributos de Persona.
        /// </summary>
        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de Lectura/Escritura de Apellido.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (!(this.ValidarNombreApellido(value) is null))
                    this.apellido = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura/Escritura de Nombre.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (!(this.ValidarNombreApellido(value) is null))
                    this.nombre = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura/Escritura de DNI.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad de Escritura de DNI.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad de Lectura/Escritura de Nacionalidad.
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
        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona.
        /// </summary>
        public Persona()
        {
            
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dni">DNI de la persona.</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, dni.ToString(), nacionalidad)
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dni">DNI de la persona.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
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
            retorno.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            retorno.AppendFormat("DNI: {0}\n", this.DNI);
            retorno.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad.ToString());
            return retorno.ToString();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida el numero de DNI según la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">Numero de DNI a validar.</param>
        /// <returns>Devuelve el DNI validado o lanza una excepción.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999 || nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
                return dato;
            else
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
        }
        /// <summary>
        /// Verifica que el DNI sea un dato válido.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">Numero de DNI de la persona.</param>
        /// <returns>Devuelve el DNI validado o lanza una excepción.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            Regex esNumero = new Regex("^[0-9]+?$");
            if (esNumero.IsMatch(dato) && int.TryParse(dato, out int auxDni))
                return ValidarDni(nacionalidad, auxDni);
            else
                throw new DniInvalidoException();
        }
        /// <summary>
        /// Valida que la cadena de caracteres sean datos válidos para Nombre o Apellido.
        /// </summary>
        /// <param name="dato">Cadena de caracteres a validar.</param>
        /// <returns>Devuelve la cadena de caracteres validada, o null caso contrario.</returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = null;
            Regex sonLetras = new Regex("^[a-z|A-Z]+?$");
            if (sonLetras.IsMatch(dato))
                retorno = dato;
            return retorno;
        }
        #endregion
    }
}
