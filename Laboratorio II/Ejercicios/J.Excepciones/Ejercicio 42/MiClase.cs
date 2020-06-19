using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_42
{
    public class MiClase
    {
        private string nombre;

        public MiClase()
        {
            throw new UnaExcepcion();
        }
        // Primer constructor, lanzo la Excepcion
        public MiClase(string nombre)
        {
            try
            {
                MiClase.Estatico();
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Excepcion 1");
                new MiClase(e);
            }
        }
        //Segundo constructor
        public MiClase(Exception e)
        {
            try
            {
                MiClase objeto2 = new MiClase();
            }
            catch(Exception a)
            {
                Console.WriteLine("Excepcion 2");
            }
        }
        public static void Estatico()
        {
            throw new DivideByZeroException();
        }

    }
}
