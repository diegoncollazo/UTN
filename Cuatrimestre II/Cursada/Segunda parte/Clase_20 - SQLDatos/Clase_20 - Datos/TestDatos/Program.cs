using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace TestDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Persona> personas = new List<Persona>();
            Persona persona = new Persona(1, "Sofia", "Salvatierra", 19);

            personas = accesoDatos.TraerTodo();

            foreach(Persona lista in personas)
            {
                Console.WriteLine(lista);
            }

            if(accesoDatos.AgregarPersona(persona) == true)
            {
                Console.WriteLine("Se pudo agregar correctamente");
            }

            Console.ReadKey();
        }
    }
}
