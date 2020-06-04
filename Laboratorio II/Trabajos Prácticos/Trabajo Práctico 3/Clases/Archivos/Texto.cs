using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos en un archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar.</param>
        /// <param name="datos">Dato a guardar.</param>
        /// <returns>Retorna TRUE si logró grabar, FALSE en caso contrario.</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter writer = new StreamWriter(archivo);
                writer.Write(datos);
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Lee los datos desde un archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre del archivo.</param>
        /// <param name="datos">Datos de salida.</param>
        /// <returns>Retorna TRUE si logró leer, FALSE en caso contrario.</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader streamReader = new StreamReader(archivo);
                datos = streamReader.ReadToEnd();
                streamReader.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}