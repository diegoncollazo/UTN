using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics._2020
{
    /// <summary>
    /// Puede ser:
    /// Cualquier enumerado
    /// Cualquier tipo de valor (value type) que NO posea tipo de referencia
    /// Cualquier struct, que cumpla con lo anterior
    /// </summary>
    public class RestrictivaUnmanaged<T> where T : unmanaged
    {
        private T miAtributo;

        public override string ToString()
        {
            return this.miAtributo.GetType().Name;
        }

    }
}
