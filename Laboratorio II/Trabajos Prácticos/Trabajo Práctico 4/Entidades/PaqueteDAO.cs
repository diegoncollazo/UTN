using System;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estático por defecto.
        /// </summary>
        static PaqueteDAO()
        {
            // Cadena de conexion tomada de las propiedades del proyecto.
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando = new SqlCommand();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Agrega un nuevo registro a la base de datos.
        /// </summary>
        /// <param name="paquete">Paquete de correo a ser agregado.</param>
        /// <returns>Retorna TRUE si pudo agregarlo, FALSE en caso contrario.</returns>
        public static bool Insertar(Paquete paquete)
        {
            bool retorno = false;
            try
            {
                conexion.Open();
                comando = new SqlCommand(string.Format
                    ("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES ('{0}','{1}','{2}')",
                    paquete.DireccionEntrega,
                    paquete.TrackingID, "Diego Collazo"),
                    conexion
                    );
                // Verifica que haya editado la fila.
                if (comando.ExecuteNonQuery() == 1)
                    retorno = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (!(conexion is null))
                    conexion.Close();
            }
            return retorno;
        }
        #endregion
    }
}
