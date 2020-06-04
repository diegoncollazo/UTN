using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics._2020
{
    public class RestrictivaVarios<T, U>
        where T : new()
        where U : T
    {
    }
}
