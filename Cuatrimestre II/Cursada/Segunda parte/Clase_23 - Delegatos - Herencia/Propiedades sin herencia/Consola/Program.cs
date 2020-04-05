using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Alumnos;
using Entidades.Externa;

namespace Consola
{
  class Program
  {
    static void Main(string[] args)
    {
        Persona persona = new Persona("Diego", "Collazo", 37, Entidades.Alumnos.ESexo.Masculino);

      

      Console.WriteLine(persona.ToString());
      Console.ReadKey();
    }
  }
}
