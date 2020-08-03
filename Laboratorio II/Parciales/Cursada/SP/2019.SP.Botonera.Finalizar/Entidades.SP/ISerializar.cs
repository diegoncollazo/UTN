using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public interface ISerializar
    {
        //ISerializar -> Xml(string):bool
        bool Xml(string archivo);
    }
}
