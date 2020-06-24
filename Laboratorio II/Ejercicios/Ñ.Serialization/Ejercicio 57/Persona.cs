using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Ejercicio_57
{
    public class Persona
    {
        private string nombre;
        private string apellido;

        public Persona()
        {

        }

        public Persona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }
        public static bool Guardar(string xml, Persona persona)
        {
            bool retorno = false;
            XmlTextWriter writer = new XmlTextWriter(xml, Encoding.UTF8);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Persona));
                serializer.Serialize(writer, persona);
                retorno = true;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            finally
            {
                writer.Close();
            }
            return retorno;
        }

        public static Persona Leer(string xml)
        {
            XmlTextReader reader = new XmlTextReader(xml);
            Persona persona;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Persona));

                persona = new Persona();

                persona = (Persona)serializer.Deserialize(reader);

                return persona;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                reader.Close();
            }
        }
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("\n");
            retorno.AppendFormat("Apellido: {0}\n", this.apellido);
            retorno.AppendFormat("Nombre: {0}\n", this.nombre);
            return retorno.ToString();
        }
    }
}
