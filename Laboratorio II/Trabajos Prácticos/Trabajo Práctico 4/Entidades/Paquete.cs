using System;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Delegados
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region Enumerados
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
        #endregion 

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado informarEstado;
        #endregion

        #region Propiedades
        /// <summary>
        /// Get Obtiene el DireccionEntrega y SET establece el valor en el campo DireccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        /// <summary>
        /// Get Obtiene el TrackingID y SET establece el valor en el campo TrackingID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        /// <summary>
        /// Get Obtiene el estado y SET establece el valor en el campo Estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto. Inicializa la dirección de entrega y el ID de tracking.
        /// </summary>
        /// <param name="direccionEntrega">Dirección de entrega.</param>
        /// <param name="trakingID">Tracking ID de la entrega.</param>
        public Paquete(string direccionEntrega, string trakingID)
        {
            this.TrackingID = trakingID;
            this.DireccionEntrega = direccionEntrega;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// simula un tiempo de envio de 4segundo y va cambiando el estado hasta llegar a Entregado
        /// invoca a informar estado para actualizar el estado del formulario
        /// por ultimo lo agrega a la base de datos
        /// </summary>
        public void MockCicloVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);

                if (this.Estado != EEstado.Entregado && this.Estado != EEstado.EnViaje)
                {
                    this.Estado = EEstado.EnViaje;

                }
                else if (this.Estado != EEstado.Entregado && this.Estado == EEstado.EnViaje)
                {
                    this.estado = EEstado.Entregado;
                }
                this.informarEstado.Invoke(null,null);

                if (this.estado == EEstado.Entregado)
                {
                    try
                    {
                        PaqueteDAO.Insertar(this);
                    }
                    catch
                    {

                    }
                }
            }

        }
        /// <summary>
        /// Muestras los datos del elemento
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete paquete = (Paquete)elemento;
            return string.Format("{0} para {1}\n", paquete.TrackingID, paquete.DireccionEntrega);

        }
        /// <summary>
        /// muestra los datos del elemento usando metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// compara dos paquetes, si tienen el mismo TrackingID son iguales.
        /// </summary>
        /// <param name="paqueteUno">paquete a comparaar</param>
        /// <param name="paqueteDos">paquete contra que comparar</param>
        /// <returns>true si son iguales, false si no lo son</returns>
        public static bool operator ==(Paquete paqueteUno, Paquete paqueteDos)
        {
            return paqueteUno.TrackingID == paqueteDos.TrackingID;
        }
        /// <summary>
        /// verifica si dos paquetes son distintos
        /// </summary>
        /// <param name="paqueteUno">paquete a comparaar</param>
        /// <param name="paqueteDos">paquete contra que comparar</param>
        /// <returns>true si son Distintos, false si no lo son</returns>
        public static bool operator !=(Paquete paqueteUno, Paquete paqueteDos)
        {
            return !(paqueteUno == paqueteDos);
        }
        #endregion
    }
}
