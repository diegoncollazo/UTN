using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Xml.Serialization;
using System.IO;

namespace Consola
{
    class Serializar
    {
        static void Main(string[] args)
        {
            List<Humano> humanos = new List<Humano>();

            Humano humano = new Humano();
            humano.Dni = 26858171;
            Persona persona = new Persona("Collazo", "Diego");
            Alumno alumno = new Alumno();
            alumno.Legajo = 108105;
            alumno.Dni = humano.Dni;
            alumno.apellido = persona.apellido;
            alumno.nombre = persona.nombre;

            Profesor profesor = new Profesor();
            profesor.Titulo = "Técnico en Programación";
            profesor.Dni = humano.Dni;
            profesor.apellido = persona.apellido;
            profesor.nombre = persona.nombre;

            humanos.Add(alumno);
            humanos.Add(profesor);
            humanos.Add(humano);

            SerializarListaHumanos(humanos);

            //Console.WriteLine(humano.ToString());
            //Console.WriteLine(persona.ToString());
            //Console.WriteLine(alumno.ToString());
            //Console.WriteLine(profesor.ToString());

            //if (Consola.Program.SerializarAlumno(alumno))
            //    Console.WriteLine("Se puede serializar.");
            //else
            //    Console.WriteLine("No se puede serializar.");

            //alumno = DesSerializarAlumno();

            //if (alumno != null)
            //    Console.WriteLine(alumno.ToString());

            Console.ReadKey();
        }
        //Serializar Alumno
        public static bool SerializarAlumno(Alumno alumno)
        {
            bool retorno = true;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Alumno));
                StreamWriter sw = new StreamWriter("D:\\alumno.xml"); // Path.XML
                xml.Serialize(sw, alumno);
            }
            catch(Exception e)
            {
                string error = e.Message;
                retorno = false;
            }

            return retorno;
        }
        //Deserializar Alumno
        public static Alumno DesSerializarAlumno()
        {
            Alumno alumno = new Alumno(); 
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Alumno));
                StreamReader sw = new StreamReader("D:\\alumno.xml");
                alumno = (Alumno)xml.Deserialize(sw);
                sw.Close();
            }
            catch
            {
                Console.WriteLine("No se puedo abrir el archivo. BIS");
            }
            return alumno;
        }
        //Serializar Humano
        public static bool SerializarHumano(Humano humano)
        {
            bool retorno = true;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Humano));
                StreamWriter sw = new StreamWriter("D:\\humano.xml"); // Path.XML
                xml.Serialize(sw, humano);
            }
            catch (Exception e)
            {
                string error = e.Message;
                retorno = false;
            }

            return retorno;
        }
        //Deserializar Humano
        public static Humano DesSerializarHumano()
        {
            Humano humano = new Humano();
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Humano));
                StreamReader sw = new StreamReader("D:\\humano.xml");
                humano = (Humano)xml.Deserialize(sw);
                sw.Close();
            }
            catch
            {
                Console.WriteLine("No se puedo abrir el archivo.");
            }
            return humano;
        }
        //Serializar Lista Humanos
        public static bool SerializarListaHumanos(List<Humano> humanos)
        {
            bool retorno = true;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Humano>));
                StreamWriter sw = new StreamWriter("D:\\humanos.xml"); // Path.XML
                xml.Serialize(sw, humanos);
            }
            catch
            {
                Console.WriteLine("No se guardar el archivo.");
                retorno = false;
            }

            return retorno;
        }
    }
}
