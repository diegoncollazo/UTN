using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]

    public class Humano //: ISerializableXML
    {
        private int dni;
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }
        public override string ToString()
        {
            return "DNI: " + this.Dni;
        }
    }
}
