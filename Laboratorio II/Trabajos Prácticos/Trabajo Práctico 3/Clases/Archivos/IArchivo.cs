using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {
        /// <summary>
        /// Firma para Metodo Guardar.
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar.</param>
        /// <param name="datos">Dato a guardar.</param>
        /// <returns>Retorna TRUE si logró grabar, FALSE en caso contrario.</returns>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Firma para Metodo Leer.
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer.</param>
        /// <param name="datos">Dato a recuperar.</param>
        /// <returns>Retorna TRUE si logró leer, FALSE en caso contrario.</returns>
        bool Leer(string archivo, out T datos);
    }
}