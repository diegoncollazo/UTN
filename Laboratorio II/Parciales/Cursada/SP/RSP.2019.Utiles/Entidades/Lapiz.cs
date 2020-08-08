using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Entidades
{
    public class Lapiz : Utiles, ISerializa, IDeserializa
    {
        public ConsoleColor color;
        public ETipoTrazo trazo;

        public override bool PreciosCuidados
        {
            get
            {
                return true;
            }
        }

        public string Path
        {
            get
            {
                return "Diego.Collazo.Lapiz.xml";
            }
        }

        public Lapiz() : this(ConsoleColor.Black, ETipoTrazo.Fino, "-", 0)
        {

        }

        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio) : base(marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append(base.ToString());
            retorno.AppendLine("Color: " + this.color);
            retorno.AppendLine("Trazo: " + this.trazo);
            retorno.AppendLine("Precios cuidados: " + this.PreciosCuidados);

            return retorno.ToString();
        }

        public bool Xml()
        {
            bool retorno = false;
            XmlSerializer serializer = new XmlSerializer(typeof(Lapiz));
            try
            {
                using (TextWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + this.Path))
                {
                    serializer.Serialize(writer, this);
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                //MessageBox.Show(error.Message, "Error al serializar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception(error.Message + " Error al serializar");
            }

            return retorno;
        }

        bool IDeserializa.Xml(out Lapiz lapiz)
        {
            bool retorno = false;
            lapiz = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Lapiz));

            try
            {
                using (TextReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + this.Path))
                {
                    lapiz = (Lapiz)serializer.Deserialize(reader);
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                // MessageBox.Show(error.Message, "Error al deserializar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception(error.Message + " Error al deserializar");
            }

            return retorno;
        }
    }
}
