using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface ISerializableXML
    {
        bool SerializarXML();

        Humano DeserializarXML();

        string Path { get; set; }
    }
}
