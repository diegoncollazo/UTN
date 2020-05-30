using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos en un archivo XML serializando los datos.
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar.</param>
        /// <param name="datos">Dato a guardar.</param>
        /// <returns>Retorna TRUE si logró grabar, FALSE en caso contrario.</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamWriter guardar = new StreamWriter(archivo);
                serializer.Serialize(guardar, datos);
                guardar.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Lee los datos serializados desde un archivo XML.
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer.</param>
        /// <param name="datos">Datos de salida.</param>
        /// <returns>Retorna TRUE si logró leer, FALSE en caso contrario.</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamReader streamReader = new StreamReader(archivo);
                //Cuando hay out hay que definir el parametro o tira error
                datos = (T)serializer.Deserialize(streamReader);
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