using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace TestDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Persona> personas = new List<Persona>();
            Persona persona = new Persona(16, "Sofia", "Salvatierra", 89);

            #region "Datos cargados"
            //Console.WriteLine("DATOS CARGADOS\n");

            //personas = accesoDatos.TraerTodo();

            //foreach(Persona lista in personas)
            //{
            //    Console.WriteLine(lista);
            //}
            #endregion

            #region "Agregar persona"
            //Console.WriteLine("\n\nAGREGAR PERSONA\n");

            ////accesoDatos.AgregarPersona(persona);
            //personas = accesoDatos.TraerTodo();

            //foreach (Persona lista in personas)
            //{
            //    Console.WriteLine(lista);
            //}
            #endregion

            #region "Modificar persona"
            //Console.WriteLine("\n\nMODIFICAR PERSONA\n");

            //accesoDatos.ModificarPersona(persona);
            //personas = accesoDatos.TraerTodo();

            //foreach (Persona lista in personas)
            //{
            //    Console.WriteLine(lista);
            //}
            #endregion

            #region "Eliminar persona"
            //Console.WriteLine("\n\nELIMINAR PERSONA\n");

            //accesoDatos.EliminarPersona(14);
            //personas = accesoDatos.TraerTodo();

            //foreach (Persona lista in personas)
            //{
            //    Console.WriteLine(lista);
            //}
            #endregion

            #region "Tabla"
            DataTable tabla = new DataTable("Personas");

            //tabla = accesoDatos.TraerTablaPersona();

            //foreach (DataRow fila in tabla.Rows)
            //{
            //    Console.WriteLine(fila[0].ToString() + fila["nombre"] + fila["apellido"] + fila["edad"]);
            //}

            //tabla.WriteXmlSchema("Personas_Esquema.xml"); //Lo devuelve en formato XML

            //tabla.WriteXml("Personas_Datos.xml"); //Muestra los datos

            tabla.ReadXmlSchema("Personas_Esquema.xml");
            tabla.ReadXml("Personas_Datos.xml");
            #endregion

            Console.ReadKey();
        }
    }
}
