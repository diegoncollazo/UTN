using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        /// <summary>
        /// Get obtiene la lista de paquetes, SET establece la lista de paquetes con el valor pasado
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructores
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// recorre el mockde paquetes y verifica los hilos. si esta activo los Finaliza.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
                if (item.IsAlive)
                    item.Abort();
        }
        /// <summary>
        /// devuelve un string con todos los datos de los paquetes en la lista de paquetes
        /// </summary>
        /// <param name="elementos">los elementos de la lista</param>
        /// <returns>string con los datos de los paquetes</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder retorno = new StringBuilder();
            List<Paquete> lista = (List<Paquete>)((Correo)elementos).paquetes;
            foreach (Paquete item in lista)
                retorno.AppendLine(string.Format("{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString()));
            return retorno.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// sobrecarga del operador + agrega un paquete a un correo siempre y cuando este no este en la lista
        /// </summary>
        /// <param name="correo">correo a agregar el elemento</param>
        /// <param name="paquete">elemento que se agregara al correo</param>
        /// <returns>devuelve el correo con o sin elemento agregado</returns>
        public static Correo operator +(Correo correo, Paquete paquete)
        {
            Thread hiloMock = new Thread(paquete.MockCicloVida);

            foreach (Paquete item in correo.Paquetes)//recorro la lista
                if (item == paquete)
                    throw new TrackingiDRepetidoException("El paquete " + item.TrackingID + " ya se encuentra en la lista");
            correo.Paquetes.Add(paquete);
            //Agrego el hilo al mock de paquetes
            correo.mockPaquetes.Add(hiloMock);
            //Corro el hilo
            hiloMock.Start();
            return correo;
        }
        #endregion
    }
}
