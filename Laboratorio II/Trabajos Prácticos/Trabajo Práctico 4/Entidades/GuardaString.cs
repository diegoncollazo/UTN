using System;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda el texto recibido por parametro en un archivo en el Escritorio,
        /// con el nombre especificado, si no existe lo crea y si ya existe solo lo agrega.
        /// </summary>
        /// <param name="texto">Texto a copiar en el archivo.</param>
        /// <param name="archivo">Nombre del archivo a Crear/Modificar.</param>
        /// <returns>Retorna TRUE si lograr guardarlo, FALSE en caso contrario.</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter streamWriter = null;
            bool retorno = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "\\" + archivo;
            try
            {
                if (File.Exists(path))
                
                    streamWriter = new StreamWriter(path, true);
                
                else
                
                    streamWriter = new StreamWriter(path);
                
                streamWriter.WriteLine(texto+"\n");
                retorno = true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (!(streamWriter is null))
                    streamWriter.Close();
            }
            return retorno;
        }
    }
}
