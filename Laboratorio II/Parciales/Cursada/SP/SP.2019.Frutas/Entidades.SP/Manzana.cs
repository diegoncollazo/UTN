using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    public class Manzana : Fruta, ISerializar, IDeserializar
    {
        protected string _provinciaOrigen;

        public string Nombre
        {
            get
            {
                return "Manzana";
            }
        }

        public string Provincia
        {
            get
            {
                return this._provinciaOrigen;
            }
            set
            {
                this._provinciaOrigen = value;
            }
        }

        public override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        public Manzana()
            : this("", 0, "")
        {
        }

        public Manzana(string color, double peso, string provinciaOrigen)
            : base(color, peso)
        {
            this.Provincia = provinciaOrigen;
        }

        protected override string FrutaToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(this.Nombre);
            datos.Append(base.FrutaToString());
            datos.AppendLine("Provincia de origen: " + this._provinciaOrigen);
            datos.AppendLine("Tiene carozo: " + this.TieneCarozo);

            return datos.ToString();
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }

        public bool Xml(string datos)
        {
            bool sePudo = false;

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Manzana));

                using (TextWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + datos))
                {
                    serializador.Serialize(escritor, this);
                    sePudo = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error al serializar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sePudo;
        }

        bool IDeserializar.Xml(string datos, out Fruta fruta)
        {
            bool sePudo = false;
            fruta = null;

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Manzana));

                using (TextReader lector = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + datos))
                {
                    fruta = (Fruta)serializador.Deserialize(lector);
                    sePudo = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error al deserializar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sePudo;
        }
    }
}
