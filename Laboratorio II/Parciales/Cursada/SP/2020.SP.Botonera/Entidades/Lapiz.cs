using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    //Lapiz-> color:ConsoleColor(público); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; público); PreciosCuidados->true; 
    //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
    public class Lapiz : Utiles, ISerializa, IDeserializa
    {
 
        public ConsoleColor color;
        public ETipoTrazo trazo;
        //Asigno el valor TRUE a PreciosCuidados
        public override bool PreciosCuidados { get { return true; } }

        public string Path
        {
            get
            {
                return "diego.collazo.xml";
            }
        }

        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio )
            : base(marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append(base.ToString());
            retorno.AppendLine("Color: " + this.color.ToString());
            retorno.AppendLine("Trazo: " + this.trazo.ToString());

            return retorno.ToString();
        }

        public bool Xml()
        {
            bool retorno = false;

            try
            {
                // Obtengo el tipo Lapiz
                XmlSerializer serializer = new XmlSerializer(typeof(Lapiz));
                using (StreamWriter writer = new StreamWriter(Environment
                    .GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + this.Path))
                {
                    serializer.Serialize(writer, this);
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

            return retorno;
        }

        bool IDeserializa.Xml(out Lapiz lapiz)
        {
            bool retorno = false;
            lapiz = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Lapiz));
                using (StreamReader reader = new StreamReader(Environment
                    .GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + this.Path))
                {
                    lapiz = (Lapiz)serializer.Deserialize(reader);
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

            return retorno;
        }
    }
}
