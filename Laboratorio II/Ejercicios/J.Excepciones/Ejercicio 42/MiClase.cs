using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_42
{
    public class MiClase
    {
        private readonly string objeto;

        public MiClase()
        {
            try
            {
                MiClase.Estatico();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Excepcion 1");
                throw e;
            }
        }
        // Primer constructor, lanzo la Excepcion
        public MiClase(string objeto)
        {
            try
            {
                new MiClase();
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Excepcion 2");
                throw new UnaExcepcion("Excepcion 2 enviada a UnaExcepcion");
            }
        }
        public static void Estatico()
        {
            throw new DivideByZeroException();
        }

    }
}
