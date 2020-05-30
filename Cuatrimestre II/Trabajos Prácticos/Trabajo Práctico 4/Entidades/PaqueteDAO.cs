using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Metodos
        /// <summary>
        /// inserta un paquete a la base de datos 
        /// </summary>
        /// <param name="paquete">dato a ser guardado</param>
        /// <returns>true si pudo guardarlo, false si no pudo</returns>
        public static bool Insertar(Paquete paquete)
        {
            bool retorno = false;
            try
            {
                conexion.Open();
                comando = new SqlCommand(string.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES ('{0}','{1}','{2}')", paquete.DireccionEntrega, paquete.TrackingID, "Diego Collazo"), conexion);
                if (comando.ExecuteNonQuery() == 1)//verifica que alla editado la fila
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
        /// <summary>
        /// inicializa la conexion con la base de datos
        /// </summary>
        ///        
        static PaqueteDAO()
        {
            string conexionStr = @"Data Source=Multitask;Initial Catalog=correo-sp-2017; Integrated Security=True";
            conexion = new SqlConnection();
            conexion.ConnectionString = conexionStr;
        }
        #endregion
    }
}
