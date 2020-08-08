using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    //Zapato-> tipo:string (público); marca:string; (público); precio:float (público); 
    //ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
    public class Zapato : Objetos, ISerializa, IDeserializa
    {
        public string Path
        {
            get
            {
                return "Diego.Collazo.Lapiz.xml";
            }
        }
        public Zapato() : base(string.Empty, string.Empty, 0)
        {

        }

        public Zapato(string tipo, string marca, float precio) : base(tipo, marca, precio)
        {

        }
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append(base.ToString());

            return retorno.ToString();
        }

        public bool Xml()
        {
            bool retorno = false;
            XmlSerializer serializer = new XmlSerializer(typeof(Zapato));
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

        bool IDeserializa.Xml(out Zapato zapato)
        {
            bool retorno = false;
            zapato = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Zapato));

            try
            {
                using (TextReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + this.Path))
                {
                    zapato = (Zapato)serializer.Deserialize(reader);
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
